# Android Manifest Merge Tool (am_merge.rb)
# Copyright (c) 2012 DeNA. All rights reserved.

require "getoptlong"
require "rexml/document"
require "tempfile"
include REXML
################################################################################
module AM_MERGE
    MIN_SDK = 7
    MBG_NAMESPACE_ATTRIB_NAME = "xmlns:mbg"
    MBG_NAMESPACE_ATTRIB_VALUE = "http://mobage.com/namespaces/android/manifest"

end
################################################################################
def usage()
    print "ruby am_merge.rb -o <path_to_merged_android_manifest_file> <path_to_minimized_android_manifest_file> <path_to_android_manifest_file>\n"
end
################################################################################
def split_xpath(xpath)
    xp = ""
    comps = xpath.split("/").map{|comp|
        (comp.length > 0) ? comp : nil
    }
    comps.compact!
    comps.each{|comp|
        xp += "/" + comp.split("[")[0]
    }
    xp
end
################################################################################
def append_attributes(elem, packageA = nil, packageB = nil)
    out = ""
    elem.attributes.each{|name, value|
        if !packageA.nil? and !packageB.nil? and packageA.length > 0 and packageB.length > 0
            newValue = value.sub(packageA, packageB)
            if !newValue.nil? and newValue.length > 0
                out += " " + name + "=\"" + newValue + "\""
            else
                # no subsitutions took place
                out += " " + name + "=\"" + value + "\""
            end
        else
            # we just append this without worrying what it is
            out += " " + name + "=\"" + value + "\""
        end
    }
    out
end
################################################################################
def compare_attributes(a, b)
    attribs = {}
    a.attributes.each{|name, value|
        if name.start_with?("mbg:")
            # these attributes are NOT compared
        else
            attribs[name] = [value, true, false]
        end
    }
    b.attributes.each{|name, value|
        if name.start_with?("mbg:")
            # these attributes are NOT compared
        else
            if attribs.has_key?(name)
                attribs[name][2] = (attribs[name][0] == value) ? true : false
            else
                attribs[name] = [value, false, true]
            end
        end
    }
    allSame = true
    attribs.keys.each{|key|
        allSame &= attribs[key][1] == attribs[key][2]
    }
    allSame
end
################################################################################
class XMLElem
    attr_accessor :src, :elem, :children
    def initialize(src, elem)
        @src = src
        @elem = elem
        @children = []
    end
    def ancestor?(src, elem)
        isAncestor = true
        myComps = @elem.xpath.split("/")
        myComps.map!{|comp|
            (comp.length > 0) ? comp : nil
        }
        myComps.compact!
        myComps.map!{|comp|
            if comp.eql?("manifest") or comp.eql?("application")
                comp
            else
                comp + @src
            end
        }
        comps = elem.xpath.split("/")
        comps.map!{|comp|
            (comp.length > 0) ? comp : nil
        }
        comps.compact!
        comps.map!{|comp|
            if comp.eql?("manifest") or comp.eql?("application")
                comp
            else
                comp + src
            end
        }
        if myComps.length <= comps.length
            for i in 0..(myComps.length-1)
                if myComps[i].eql?(comps[i])
                    isAncestor &= true
                else
                    isAncestor &= false
                end
            end
        else
            isAncestor = false
        end
        isAncestor
    end
end
################################################################################
class XMLSerializer
    attr_reader :outputXML
    def initialize(xmlElem, packageA = nil, packageB = nil)
        @outputXML = ""
        @packageA = packageA
        @packageB = packageB
        _serialize(xmlElem, 0)
    end

    private

    def _serialize(xmlElem, indentLevel)
        indent = ""
        for i in 0..(indentLevel-1)
            indent += "\t"
        end

        containsMBGNamespace = false
        if xmlElem.elem.name == "manifest"
            xmlElem.elem.attributes.each{|name, value|
                if name == AM_MERGE::MBG_NAMESPACE_ATTRIB_NAME.to_s
                    containsMBGNamespace = true
                end
            }
        end

        @outputXML += indent + "<" + xmlElem.elem.name
        @outputXML += append_attributes(xmlElem.elem, @packageA, @packageB)

        if xmlElem.elem.name == "manifest" and !containsMBGNamespace
            @outputXML += " #{AM_MERGE::MBG_NAMESPACE_ATTRIB_NAME}=\"#{AM_MERGE::MBG_NAMESPACE_ATTRIB_VALUE}\""
        end

        if xmlElem.children.length == 0
            @outputXML += "/>\n"
        else
            @outputXML += ">\n"
            xmlElem.children.each{|child|
                _serialize(child, indentLevel+1)
            }
            @outputXML += indent + "</" + xmlElem.elem.name + ">\n"
        end
    end
end
################################################################################
def insert_elem(node, src, elem)
    # is the node an ancestor of the elem
    if node.ancestor?(src, elem)
        #search the node's children, to see if they are an ancestor too
        childAncestor = nil
        node.children.each{|child|
            if child.ancestor?(src, elem)
                childAncestor = child
            end
            break if !childAncestor.nil?
        }
        if childAncestor.nil?
            # the node is the parent
            node.children.push(XMLElem.new(src, elem))
        else
            insert_elem(childAncestor, src, elem)
        end
    else
        #print "This is probably bad!\n"
    end
end
################################################################################
def main()
    outputFilename = nil
    opts = GetoptLong.new(["--output", "-o", GetoptLong::REQUIRED_ARGUMENT])
    opts.each do |opt, arg|
        case opt
        when "--output"
            outputFilename = arg
        end
    end
    if !outputFilename.nil? and ARGV.length == 2 and File.exist?(ARGV[0]) and File.exist?(ARGV[1])
        aDoc = REXML::Document.new(File.open(ARGV[0]))
        bDoc = REXML::Document.new(File.open(ARGV[1]))
        aPaths = []
        bPaths = []
        # Minimize A
        REXML::XPath.match(aDoc, "//*").each{|elem|
            if elem.has_attributes?
                if !elem.attributes["mbg:gameNeedsToIncludeThis"].nil? and elem.attributes["mbg:gameNeedsToIncludeThis"] == "true"
                    # Add this path
                    if !aPaths.include?(elem.xpath)
                        aPaths.push(elem.xpath)
                    end
                elsif !elem.attributes["mbg:gameNeedsToIncludeThisAndChildren"].nil? and elem.attributes["mbg:gameNeedsToIncludeThisAndChildren"] == "true"
                    # Add this path, and all its children
                    if !aPaths.include?(elem.xpath)
                        aPaths.push(elem.xpath)
                    end
                    REXML::XPath.match(aDoc, elem.xpath + "/descendant::*").each{|child|
                        if !aPaths.include?(child.xpath)
                            aPaths.push(child.xpath)
                        end
                    }
                else
                    # This path is not to be added
                end
            end
        }
        # Get the package name of B
        packageB = nil
        manifestB = REXML::XPath.match(bDoc, "/manifest")
        if !manifestB.nil? and manifestB.length == 1 and !manifestB[0].attributes["package"].nil?
            packageB = manifestB[0].attributes["package"]
        else
            puts "### ERROR ### The base manifest[#{ARGV[1]}] does not specify a package; it needs to."
            exit
        end
        # Get the package name of A
        packageA = nil
        manifestA = REXML::XPath.match(aDoc, "/manifest")
        if !manifestA.nil? and manifestA.length == 1 and !manifestA[0].attributes["package"].nil?
            packageA = manifestA[0].attributes["package"]
        else
            puts "### ERROR ### The merge manifest[#{ARGV[0]}] does not specify a package; it needs to."
            exit
        end

        aHasValidUsesSDK = false
        bHasValidUsesSDK = false
        # Check uses-sdk of A
        aUsesSDK = REXML::XPath.match(aDoc, "/manifest/uses-sdk")
        if !aUsesSDK.nil? and aUsesSDK.length == 1 and !aUsesSDK[0].attributes["android:minSdkVersion"].nil? and aUsesSDK[0].attributes["android:minSdkVersion"].to_i >= AM_MERGE::MIN_SDK
            aHasValidUsesSDK = true
        end
        # Check uses-sdk of B
        bUsesSDK = REXML::XPath.match(bDoc, "/manifest/uses-sdk")
        if !bUsesSDK.nil? and bUsesSDK.length == 1
            if (bUsesSDK[0].attributes["mbg:gameNeedsToIncludeThisAndChildren"].nil? and
                    bUsesSDK[0].attributes["mbg:managedByNDKDoNotEdit"].nil? and
                    !bUsesSDK[0].attributes["android:minSdkVersion"].nil? and
                    bUsesSDK[0].attributes["android:minSdkVersion"].to_i >= AM_MERGE::MIN_SDK)
                bHasValidUsesSDK = true
            end
        end
        if !aHasValidUsesSDK and !bHasValidUsesSDK
            puts "### ERROR ### Both manifests you have specified have a 'uses-sdk' element with a missing or invalid 'android:minSdkVersion' attribute value. The minimum allowed is #{AM_MERGE::MIN_SDK}."
            exit
        elsif aHasValidUsesSDK == false and bHasValidUsesSDK == true
            puts "### WARNING ### The merge manifest[#{ARGV[0]}] that you are trying to merge into base manifest[#{ARGV[1]}] has a 'uses-sdk' element with a missing or invalid 'android:minSdkVersion' attribute value. The minimum allowed is #{AM_MERGE::MIN_SDK}."
        elsif aHasValidUsesSDK == true and bHasValidUsesSDK == false
            puts "### WARNING ### The base manifest[#{ARGV[1]}] has a 'uses-sdk' element with a missing or invalid 'android:minSdkVersion' attribute value; the merge manifest[#{ARGV[0]}] 'uses-sdk' element will be used."
        end

        # Get all xpaths of B
        REXML::XPath.match(bDoc, "//*").each{|elem|
            if !bPaths.include?(elem.xpath)
                bPaths.push(elem.xpath)
            end
        }
        # Remove mbg:gameNeedsToIncludeThisAndChildren from B
        REXML::XPath.match(bDoc, "//*").each{|elem|
            if (!elem.attributes["mbg:gameNeedsToIncludeThisAndChildren"].nil? and elem.attributes["mbg:gameNeedsToIncludeThisAndChildren"] == "true") or
                    (!elem.attributes["mbg:managedByNDKDoNotEdit"].nil? and elem.attributes["mbg:managedByNDKDoNotEdit"] == "true")
                # This element, and all its children, need to be removed from B
                bPaths.delete(elem.xpath)
                REXML::XPath.match(bDoc, elem.xpath + "/descendant::*").each{|child|
                    bPaths.delete(child.xpath)
                }
            end
        }
        mergePaths = []
        # Select paths to merge A into B
        aPaths.each{|aPath|
            aElem = REXML::XPath.match(aDoc, aPath)[0]
            splitAPath = split_xpath(aPath)
            if splitAPath.eql?("/manifest") or splitAPath.eql?("/manifest/application") or (splitAPath.eql?("/manifest/uses-sdk") and bHasValidUsesSDK)
                # don't even bother with /manifest or /manifest/application
                # additionally, if B already has a valid usesSDK, don't bother with /manifest/uses-sdk either.
            else
                okToMergeA = true
                # find places in B, where it may be in conflict with A
                bPaths.each{|bPath|
                    splitBPath = split_xpath(bPath)
                    if splitAPath == splitBPath
                        bElem = REXML::XPath.match(bDoc, bPath)[0]
                        parentSame = true
                        parentA = aElem.parent
                        parentB = bElem.parent
                        begin
                            if (parentA.name == parentB.name and compare_attributes(parentA, parentB)) or (parentA.name == "manifest" and parentB.name == "manifest") or (parentA.name == "application" and parentB.name == "application")
                                # yes, the parents are the same
                            else
                                parentSame = false
                            end
                            parentA = parentA.parent
                            parentB = parentB.parent
                        end while (!parentA.nil? and !parentB.nil?) and parentSame == true
                        if parentSame == true
                            #the parents are the same, maybe we shuold NOT merge
                            okToMergeA &= !compare_attributes(aElem, bElem)
                        else
                            # the parents aren't the same, it's OK to merge
                            okToMergeA &= true
                        end
                    end
                }
                if okToMergeA
                    if !mergePaths.include?(aPath)
                        mergePaths.push(aPath)
                    end
                end
            end
        }
        # Lets merge everything together and save!
        # Create a root that is Bs manifest
        manifest = XMLElem.new("B", REXML::XPath.match(bDoc, "/manifest")[0])
        # Make Bs application a child of the manifest
        manifest.children.push(XMLElem.new("B", REXML::XPath.match(bDoc, "/manifest/application")[0]))
        bPaths.delete("/manifest")
        bPaths.delete("/manifest/application")
        bPaths.each{|path|
            elem = REXML::XPath.match(bDoc, path)[0]
            if bHasValidUsesSDK == false and elem.name == "uses-sdk"
                # We cannot include this.
            else
                insert_elem(manifest, "B", elem)
            end
        }
        mergePaths.each{|path|
            elem = REXML::XPath.match(aDoc, path)[0]
            insert_elem(manifest, "A", elem)
        }
        outputXML = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n"
        outputXML += XMLSerializer.new(manifest, packageA, packageB).outputXML
        File.open(outputFilename, "w+"){|f|
            f.write(outputXML)
        }
        print "Wrote [" + outputXML.length.to_s + "] bytes to [" + outputFilename + "]\n"
    else
        usage()
    end
end
################################################################################
begin
    if __FILE__ == $0
        main()
    end
end
################################################################################

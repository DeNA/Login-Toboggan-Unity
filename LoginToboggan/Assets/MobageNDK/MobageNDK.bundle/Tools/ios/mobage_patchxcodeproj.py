#!/usr/bin/env python
# encoding: utf-8
#
# mobage_patchxcodeproj.py
# Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
#

import logging
import os
import plistlib
import sys
import re
import json
from optparse import OptionParser

from Pbxproj import Pbxproj

def patchInfoPlist(xcodePath,facebookJSON,appID,bundleID,plistExtrasJSON):
	plistPath = os.path.join(os.path.dirname(xcodePath),"Info.plist")
	#print plistPath
	infoPlist = plistlib.readPlist(plistPath)
	#print infoPlist
	
	infoPlist["CFBundleIdentifier"] = bundleID;
	infoPlist["CFBundleLocalizations"] = ["en","fr","de","it","es"]
	lowerAppID = appID.lower().replace("-","")
	
	if facebookJSON is not None:
		logging.info("FacebookJSON")
		logging.info(facebookJSON);
		facebookData = json.loads(facebookJSON)
		for key, value in facebookData.iteritems():
			logging.info("Processing FacebookJSON")
			logging.info(key)
			logging.info("=")
			logging.info(value)
			if key == "FacebookAppID":
				if infoPlist.has_key("CFBundleURLTypes") is False:
					infoPlist["CFBundleURLTypes"] = []
				if value == "180566588646375":
					infoPlist["CFBundleURLTypes"].append({"CFBundleURLSchemes":["fb"+value+lowerAppID]})
				else:
					infoPlist["CFBundleURLTypes"].append({"CFBundleURLSchemes":["fb"+value]})
				infoPlist["FacebookAppID"] = value
			elif key == "useFacebookFramework":
				logging.info("Use Facebook Framework")
				logging.info(value)
			elif value == "":
				logging.info("Key:")
				logging.info(key)
				logging.info(" has no value")
			elif value.lower() == "true" or value.lower() == "yes":
				infoPlist[key] = "YES"
			elif value.lower() == "false" or value.lower() == "no":
				infoPlist[key] = "NO"
			else: 
				infoPlist[key] = value
			
	if plistExtrasJSON is not None:
		logging.info("plistExtrasJSON")
		logging.info(plistExtrasJSON);
		plistExtrasData = json.loads(plistExtrasJSON)
		for key, value in plistExtrasData.iteritems():
			logging.info("Processing plistExtrasJSON");
			logging.info(key)
			logging.info("=")
			logging.info(value)
			if value == "":
				logging.info("Key:")
				logging.info(key)
				logging.info(" has no value")
			elif value.lower() == "true" or value.lower() == "yes":
				infoPlist[key] = "YES"
			elif value.lower() == "false" or value.lower() == "no":
				infoPlist[key] = "NO"
			else:
				infoPlist[key] = value
			
	#print infoPlist	
	plistlib.writePlist(infoPlist, plistPath)

def patchFrameworkSearchPaths(content):
	outputLines = list()
	for line in content:
		outputLines.append(line)
		if "CODE_SIGN_IDENTITY" in line:
			outputLines.append("\t\t\t\tFRAMEWORK_SEARCH_PATHS = \"$(SRCROOT)/**\";\n")
	return outputLines

def prepatchLinkerFlags(content):
	#print "Prepatching Linker Flags"
	outputLines = list()
	for line in content:
		if "OTHER_LDFLAGS = \"\";" in line:
			outputLines.append("\t\t\t\tOTHER_LDFLAGS = (\n")
			outputLines.append("\t\t\t\t\t\"-fobjc-arc\",\n")
			outputLines.append("\t\t\t\t);\n")
		elif "OTHER_LDFLAGS = \"-Wl,-S,-x\";" in line:
			outputLines.append("\t\t\t\tOTHER_LDFLAGS = (\n")
			outputLines.append("\t\t\t\t\t\"-Wl\",\n")
			outputLines.append("\t\t\t\t\t\"-S\",\n")
			outputLines.append("\t\t\t\t\t\"-x\",\n")
			outputLines.append("\t\t\t\t\t\"-fobjc-arc\",\n")
			outputLines.append("\t\t\t\t);\n")
		else:
			outputLines.append(line)
			
	return outputLines

# Strip old #import lines
# Add MobageAdTrack interface declaration and make a class method call so that Xcode/Unity does not strip ATL
def patchMainForAdTracking(projpath):
	mainPath = os.path.dirname(projpath)+"/Classes/main.mm"
	with open(mainPath) as f:
		inputLines = f.readlines()

	prevLines = ["#import <MobageAdTracking/MobageAdTracking.h>", "#import <MobageAdTracking/MobageAdTrack.h>"]
	declLine  = "@interface MobageAdTrack : NSObject; -(void)__atl_unity_dummy_method; @end\n"
	outputLines = []

	def checkSkip(line):
		for prevLine in prevLines:
			if prevLine in line:
				print "matched prev"
				return True
		if declLine in line:
			return True
		return False

	for line in inputLines:
		if checkSkip(line):
			continue
		if "UIApplicationMain" in line:
			outputLines.append("\t[MobageAdTrack class];\n")
		if "int main(int argc, char* argv[])" in line:
			outputLines.append(declLine)
		if "int main(int argc, char *argv[])" in line:
			outputLines.append(declLine)
		outputLines.append(line)

	with open(mainPath,"w") as f:
		f.writelines(outputLines)

def patchMainForInstallTracking(projpath):
	mainPath = os.path.dirname(projpath)+"/Classes/main.mm"
	with open(mainPath) as f:
		inputLines = f.readlines()
	
	outputLines = list("#import <MobageInstallTracking/MobageInstallTracking.h>\n")
	for line in inputLines:
		if "UIApplicationMain" in line:
			outputLines.append("\t[MobageInstallTrack class];\n")
		outputLines.append(line)
	
	with open(mainPath,"w") as f:
		f.writelines(outputLines)
		

def prepatchProject(projpath,facebookJSON,appID,bundleID,plistExtrasJSON):
	patchInfoPlist(projpath,facebookJSON,appID,bundleID,plistExtrasJSON)
	
	with open(projpath+"/project.pbxproj") as f:
	    content = f.readlines()
	
	content = patchFrameworkSearchPaths(content)
	content = prepatchLinkerFlags(content)
		
	with open(projpath+"/project.pbxproj","w") as f:
		f.writelines(content)
	
def getTargets(pbxProject):
	targets = [];
	return pbxProject.get_project_target()
					
def main():
	usage = ''''''
	parser = OptionParser(usage = usage)
	
	parser.add_option("-p", "--project", dest="projects",
	      help="Add the given modules to this project", action="append")
	parser.add_option("-v", "--version", dest="version", help="Unity Versions");
	parser.add_option("-t", "--trackInstalls",
                  action="store_true", dest="shouldLinkInstallTracking", default=False,
                  help="Add InstallTracking Library to the child Xcode project")
	parser.add_option("-f", "--facebook", dest="facebookJSON")
	parser.add_option("--bundleID", dest="bundleID")
	parser.add_option("-a", "--appID", dest="appID")
	parser.add_option("-e", dest="plistExtrasJSON")
	parser.add_option("-d", dest="dwarf", default=False, action="store_true")
	(options, args) = parser.parse_args()
	
	logging.basicConfig(level=logging.DEBUG)
			
	systemFrameworks = ["CoreTelephony","StoreKit","Security","MessageUI","Twitter"]
	systemFrameworksWeak = ["AdSupport","Social","Accounts"] # ["Twitter"]
	
	logging.info(options.projects);
	logging.info(args)
	if options.projects is not None:
#		if options.version[0].startswith('4'): 
		#	For Unity 4 they removed the Unity-iPhone-simulator targets
#			targets = ["Unity-iPhone"]	
#		else :
		#	For Unity 3	
#			targets = ["Unity-iPhone","Unity-iPhone-simulator"]
			
			
		logging.info(options)
		logging.info(options.appID)
		logging.info(options.bundleID)
		prepatchProject(options.projects[0],options.facebookJSON,options.appID,options.bundleID,options.plistExtrasJSON)
		
		baseProj = Pbxproj.get_pbxproj_by_name(options.projects[0],xcode_version = None)
		targets = getTargets(baseProj)
		logging.info("Targets: ")
		logging.info(targets)
		logging.info("End Targets")
		baseProj.add_group('Mobage')
		
		# Framework
		framework = "MobageNDK.framework"
		fhash_base = baseProj.get_hash_base(framework)
		ffileref_hash = baseProj.add_filereference(framework, 'frameworks', fhash_base+'0', framework, 'SOURCE_ROOT')
		baseProj.add_file_to_group(framework, ffileref_hash, "Mobage")
		
#		Facebook Framework being removed for 2.5
#		if  options.facebookJSON is not None:
			# Facebook Framework
#			facebookFramework = "FacebookSDK.framework"
#			facebookhash_base = baseProj.get_hash_base(facebookFramework)
#			facebookfileref_hash = baseProj.add_filereference(facebookFramework, 'frameworks', facebookhash_base+'0', facebookFramework, 'SOURCE_ROOT')
#			baseProj.add_file_to_group(facebookFramework, facebookfileref_hash, "Mobage")
		
		# Install Tracking (optional) Framework
		adTrackingFramework = "MobageAdTracking.framework"
		adTrackingPath = os.path.join(os.path.dirname(options.projects[0]),adTrackingFramework)
		adTrackingPlist = "MBAdTracking.plist"
		adTrackingPlistPath = os.path.join(os.path.dirname(options.projects[0]),adTrackingPlist)
		installTrackingFramework = "MobageInstallTracking.framework"
		installTrackingPath = os.path.join(os.path.dirname(options.projects[0]),installTrackingFramework)
		installTrackingPlist = "MBInstallTracking.plist"
		installTrackingPlistPath = os.path.join(os.path.dirname(options.projects[0]),installTrackingPlist)
		needsInstallTracking = options.shouldLinkInstallTracking
		ihash_base = None
		ifileref_hash = None
		isettingshash_base = None
		isettingsfileref_hash = None
		logging.info(adTrackingPath)
		logging.info(adTrackingPlistPath)
		logging.info(installTrackingPath)
		logging.info(installTrackingPlistPath)
		logging.info(needsInstallTracking)
		
		if needsInstallTracking:
			if os.path.exists(adTrackingPath):
				patchMainForAdTracking(options.projects[0])
				ihash_base = baseProj.get_hash_base(adTrackingFramework)
				ifileref_hash = baseProj.add_filereference(adTrackingFramework,'frameworks',ihash_base+'0',adTrackingFramework,'SOURCE_ROOT')
				baseProj.add_file_to_group(adTrackingFramework,ifileref_hash, "Mobage")
				isettingshash_base = baseProj.get_hash_base(adTrackingPlist)
				isettingsfileref_hash = baseProj.add_filereference(adTrackingPlist,"text.plist.xml",isettingshash_base+'0',adTrackingPlist,'SOURCE_ROOT')
				baseProj.add_file_to_group(adTrackingPlist,isettingsfileref_hash, "Mobage")
			elif os.path.exists(installTrackingPath):	
				patchMainForInstallTracking(options.projects[0])
				ihash_base = baseProj.get_hash_base(installTrackingFramework)
				ifileref_hash = baseProj.add_filereference(installTrackingFramework,'frameworks',ihash_base+'0',installTrackingFramework,'SOURCE_ROOT')
				baseProj.add_file_to_group(installTrackingFramework,ifileref_hash, "Mobage")
				isettingshash_base = baseProj.get_hash_base(installTrackingPlist)
				isettingsfileref_hash = baseProj.add_filereference(installTrackingPlist,"text.plist.xml",isettingshash_base+'0',installTrackingPlist,'SOURCE_ROOT')
				baseProj.add_file_to_group(installTrackingPlist,isettingsfileref_hash, "Mobage")
			else:
				logging.info("AdTracking library not found")
				
		# Bundle
		resourceBundle = "NDKResources.bundle"
		rhash_base = baseProj.get_hash_base(resourceBundle)
		rfileref_hash = baseProj.add_filereference(resourceBundle, 'plug-in', rhash_base+'0', framework+"/Versions/A/Resources/"+resourceBundle, 'SOURCE_ROOT')
		
		baseProj.add_file_to_group(framework, rfileref_hash, "Mobage")
		
		settingsBundle = "Settings.bundle"
		shash_base = baseProj.get_hash_base(settingsBundle)
		sfileref_hash = baseProj.add_filereference(settingsBundle, 'plug-in', shash_base+'0', "Resources/"+settingsBundle,'SOURCE_ROOT')
		baseProj.add_file_to_group(settingsBundle, sfileref_hash, "Mobage")
		
		# Entitlements
		
		mobageNDKEntitlements = "MobageNDK.entitlements"
		mNDKEnthash_base = baseProj.get_hash_base(mobageNDKEntitlements)
		mNDKEntref_hash = baseProj.add_filereference(mobageNDKEntitlements, 'plug-in', mNDKEnthash_base+'0', "Resources/"+mobageNDKEntitlements,'SOURCE_ROOT')
		baseProj.add_file_to_group(mobageNDKEntitlements, mNDKEntref_hash, "Mobage")
		
		for target in targets:
			#print "Modifying Target: "+target
			name = options.projects[0]+":"+target
			project = Pbxproj.get_pbxproj_by_name(name, xcode_version = None)
			
			libfile_hash = project.add_buildfile(framework, ffileref_hash, fhash_base+'1')
			resources_hash = project.add_buildfile(resourceBundle, rfileref_hash, rhash_base+'1')
			settings_hash = project.add_buildfile(settingsBundle, sfileref_hash, shash_base+'1')	
			mNDKEnt_hash = project.add_buildfile(mobageNDKEntitlements, mNDKEntref_hash, mNDKEnthash_base+'1')
				
				
			project.add_file_to_phase(framework,libfile_hash,project._frameworks_guid, "Frameworks")
			project.add_file_to_phase(resourceBundle,resources_hash,project._resources_guid,"Resources")
			project.add_file_to_phase(settingsBundle,settings_hash,project._resources_guid,"Resources")
			project.add_file_to_phase(mobageNDKEntitlements, mNDKEnt_hash,project._resources_guid,"Resources")
			
#			Facebook framework removed from 2.5
#			if  options.facebookJSON is not None:
#				libfacebook_hash = project.add_buildfile(facebookFramework,facebookfileref_hash, facebookhash_base+'1')
#				project.add_file_to_phase(facebookFramework,libfacebook_hash,project._frameworks_guid, "Frameworks")
			
			
			if needsInstallTracking:
				ilibfile_hash = project.add_buildfile(installTrackingFramework, ifileref_hash, ihash_base+'1')
				project.add_file_to_phase(installTrackingFramework,ilibfile_hash,project._frameworks_guid, "Frameworks")
				isettings_hash = project.add_buildfile(installTrackingPlist, isettingsfileref_hash, isettingshash_base+'1')
				project.add_file_to_phase(installTrackingPlist,isettings_hash,project._resources_guid,"Resources")
			
			project.add_lib('libsqlite3.dylib')
			for fname in systemFrameworks:
				project.add_framework(fname+".framework")
			for fname in systemFrameworksWeak:
				project.add_framework(fname+".framework", True)
				
			for configuration in project.configurations:
				subconfig = configuration[1]
				#print(str(subconfig))
				if options.dwarf:
					project.add_build_setting(subconfig, 'DEBUG_INFORMATION_FORMAT', 'dwarf')
				
				project.add_build_setting(subconfig, 'OTHER_LDFLAGS', '-ObjC')
				project.add_build_setting(subconfig, 'OTHER_LDFLAGS', '"-fobjc-arc"')
				project.add_build_setting(subconfig, 'OTHER_LDFLAGS', '-all_load')
				project.add_build_setting(subconfig, 'CODE_SIGN_ENTITLEMENTS', 'Resources/MobageNDK.entitlements')
	else:
		return "Expecting a project to modify!"

if __name__ == "__main__":
	sys.exit(main())

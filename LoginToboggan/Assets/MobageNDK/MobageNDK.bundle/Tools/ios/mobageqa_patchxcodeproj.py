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
from optparse import OptionParser

from Pbxproj import Pbxproj

def getTargets(pbxProject):
	targets = [];
	return pbxProject.get_project_target()

def main():
	usage = ''''''
	parser = OptionParser(usage = usage)
	
	parser.add_option("-p", "--project", dest="projects",
	      help="Add the given modules to this project", action="append")
	(options, args) = parser.parse_args()
	
	logging.basicConfig(level=logging.DEBUG)
			
	logging.info(options.projects);
	logging.info(args);
	if options.projects is not None:
		logging.info(options);
		
		baseProj = Pbxproj.get_pbxproj_by_name(options.projects[0],xcode_version = None)
		
		# iPhone_target
		iphonetarget_m = "iPhone_target2AppDelegate.m"
		iphonetarget_m_hash_base = baseProj.get_hash_base(iphonetarget_m)
		iphonetarget_m_fileref_hash = baseProj.add_filereference(iphonetarget_m, 'Sources', iphonetarget_m_hash_base+'0', "Classes/"+iphonetarget_m, 'SOURCE_ROOT')
		baseProj.add_file_to_group(iphonetarget_m, iphonetarget_m_fileref_hash, "Classes")
		
		iphonetarget_h = "iPhone_target2AppDelegate.h"
		iphonetarget_h_hash_base = baseProj.get_hash_base(iphonetarget_h)
		iphonetarget_h_fileref_hash = baseProj.add_filereference(iphonetarget_h, 'Sources', iphonetarget_h_hash_base+'0', "Classes/"+iphonetarget_h, 'SOURCE_ROOT')
		baseProj.add_file_to_group(iphonetarget_h, iphonetarget_h_fileref_hash, "Classes")
	
		targets = getTargets(baseProj)
	
		for target in targets:
			#print "Modifying Target: "+target
			name = options.projects[0]+":"+target
			project = Pbxproj.get_pbxproj_by_name(name, xcode_version = None)
			iphonetarget_m_hash = project.add_buildfile(iphonetarget_m, iphonetarget_m_fileref_hash, iphonetarget_m_hash_base+'1');
			iphonetarget_h_hash = project.add_buildfile(iphonetarget_h, iphonetarget_h_fileref_hash, iphonetarget_h_hash_base+'1');
			
			project.add_file_to_phase(iphonetarget_m, iphonetarget_m_hash,project._sources_guid,"Sources")
			project.add_file_to_phase(iphonetarget_h, iphonetarget_h_hash,project._sources_guid,"Sources")
			
	else:
		return "Expecting a project to modify!"

if __name__ == "__main__":
	sys.exit(main())

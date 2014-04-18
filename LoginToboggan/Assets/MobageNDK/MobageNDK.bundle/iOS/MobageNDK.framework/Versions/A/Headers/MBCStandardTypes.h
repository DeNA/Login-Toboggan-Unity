//
//  MBCStandardTypes.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCSTANDARDTYPES_H_
#define MBCSTANDARDTYPES_H_

#include "MBCUtils.h"

#ifdef __cplusplus
extern "C" {
#endif
	#include "MBCError.h"
	
	/**
	 * Provides information about the result of a request.
	 * @region Common
	 */
	typedef enum {
		/*
		
		 */
		MBCSimpleAPIStatusSuccess = 0, 
		/*
		
		 */
		MBCSimpleAPIStatusError = 1
	} MBCSimpleAPIStatus;
	#define MBCCToNativeSimpleAPIStatus(status) ((MBSimpleAPIStatus)status)
	#define MBCNativeToCSimpleAPIStatus(status) ((MBCSimpleAPIStatus)status)
	
	/**
	 * Provides information about the results of displaying a UI element that collects user input (for example, the Mobage Friend Picker).
 * The user can dismiss the UI element without providing input.
	 * @region Common
	 */
	typedef enum {
		/*
		
		 */
		MBCDismissableAPIStatusSuccess = 0, 
		/*
		
		 */
		MBCDismissableAPIStatusError = 1, 
		/*
		
		 */
		MBCDismissableAPIStatusDismiss = 2
	} MBCDismissableAPIStatus;
	#define MBCCToNativeDismissableAPIStatus(status) ((MBDismissableAPIStatus)status)
	#define MBCNativeToCDismissableAPIStatus(status) ((MBCDismissableAPIStatus)status)
	
	/**
	 * Provides information about the results of a request that the user can cancel (for example, creating a Bank transaction).
	 * @region Common
	 */
	typedef enum {
		/*
		
		 */
		MBCCancelableAPIStatusSuccess = 0, 
		/*
		
		 */
		MBCCancelableAPIStatusError = 1, 
		/*
		
		 */
		MBCCancelableAPIStatusCancel = 2
	} MBCCancelableAPIStatus;
	#define MBCCToNativeCancelableAPIStatus(status) ((MBCancelableAPIStatus)status)
	#define MBCNativeToCCancelableAPIStatus(status) ((MBCCancelableAPIStatus)status)
	
	
	#include "MBCString.h"
	
	MBCArrayForType(Double,double);
	MBCArrayForType(Integer,int);
	MBCArrayForType(Bool,bool);
	
#ifdef __cplusplus
}
#endif

#endif

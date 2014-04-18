//
//  MBInterfaceEnums.h
//
//  Created by Frederic Barthelemy on 6/27/12.
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//


#ifndef MBINTERFACEENUMS_H_
#define MBINTERFACEENUMS_H_

#ifdef __cplusplus
extern "C" {
#endif

/*
 * Provides information about the result of a request.
 */
typedef enum {
	/*
	
	 */
	MBSimpleAPIStatusSuccess = 0, 
	/*
	
	 */
	MBSimpleAPIStatusError = 1
} MBSimpleAPIStatus;

/*
 * Provides information about the results of displaying a UI element that collects user input (for example, the Mobage Friend Picker).
 * The user can dismiss the UI element without providing input.
 */
typedef enum {
	/*
	
	 */
	MBDismissableAPIStatusSuccess = 0, 
	/*
	
	 */
	MBDismissableAPIStatusError = 1, 
	/*
	
	 */
	MBDismissableAPIStatusDismiss = 2
} MBDismissableAPIStatus;

/*
 * Provides information about the results of a request that the user can cancel (for example, creating a Bank transaction).
 */
typedef enum {
	/*
	
	 */
	MBCancelableAPIStatusSuccess = 0, 
	/*
	
	 */
	MBCancelableAPIStatusError = 1, 
	/*
	
	 */
	MBCancelableAPIStatusCancel = 2
} MBCancelableAPIStatus;


#ifdef __cplusplus
}
#endif

#endif

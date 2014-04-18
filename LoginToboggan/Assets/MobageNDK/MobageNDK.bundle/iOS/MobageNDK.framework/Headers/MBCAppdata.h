//
//  MBCAppdata.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCAPPDATA_H_
#define MBCAPPDATA_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark - Notifications
	// Has None!
	
	#pragma mark - Method Callbacks!
	/**
	 * MBCAppdata_deleteEntriesForKeysCallback
	 * @description 	 * Callback for deleting key-value pairs.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCString_Array * deletedKeys A list of keys that were deleted, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.			AUTORELEASED
	 */
	typedef void (*MBCAppdata_deleteEntriesForKeysCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCString_Array * deletedKeys,
				
				void * context
																);
	/**
	 * MBCAppdata_getEntriesForKeysCallback
	 * @description 	 * Callback for retrieving key-value pairs.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCString_Array * keys The keys that were retrieved, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.			AUTORELEASED
	 * @cb-param MBCString_Array * values The values that were retrieved, with each value represented as a <c>String</c>, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCAppdata_getEntriesForKeysCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCString_Array * keys,
				/*AUTORELEASED*/ MBCString_Array * values,
				
				void * context
																);
	/**
	 * MBCAppdata_updateEntriesCallback
	 * @description 	 * Callback for creating or updating key/value pairs.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCString_Array * updatedKeys The keys that were created or updated, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.			AUTORELEASED
	 */
	typedef void (*MBCAppdata_updateEntriesCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCString_Array * updatedKeys,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCAppdata_deleteEntriesForKeys
	 * @function
	 * @public
	 * @description 	 * Delete one or more key/value pairs.
	 *
	 * @param MBCString_Array *  theKeys The keys to delete. Each key name must be a <c>String</c>.			AUTORELEASED
	 * @cb DeleteEntriesForKeysOnCompleteCallback  onComplete 
		 * Callback for deleting key-value pairs.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCString_Array * deletedKeys A list of keys that were deleted, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCAppdata_deleteEntriesForKeys(
										MBCString_Array *  theKeys,
										MBCAppdata_deleteEntriesForKeysCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCAppdata_getEntriesForKeys
	 * @function
	 * @public
	 * @description 	 * Retrieve one or more key/value pairs.
	 *
	 * @param MBCString_Array *  theKeys The keys to retrieve. Each key name must be a <c>String</c>.			AUTORELEASED
	 * @cb GetEntriesForKeysOnCompleteCallback  onComplete 
		 * Callback for retrieving key-value pairs.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCString_Array * keys The keys that were retrieved, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.			AUTORELEASED
	 * @cb-param MBCString_Array * values The values that were retrieved, with each value represented as a <c>String</c>, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCAppdata_getEntriesForKeys(
										MBCString_Array *  theKeys,
										MBCAppdata_getEntriesForKeysCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCAppdata_updateEntries
	 * @function
	 * @public
	 * @description 	 * Create or update one or more key/value pairs.
	 *
	 * @param MBCString_Array *  theKeys The keys to create or update. Each key name must be a <c>String</c>.			AUTORELEASED
	 * @param MBCString_Array *  theValues The values for each key. Each value must be a <c>String</c>.			AUTORELEASED
	 * @cb UpdateEntriesOnCompleteCallback  onComplete 
		 * Callback for creating or updating key/value pairs.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCString_Array * updatedKeys The keys that were created or updated, with each key represented as a <c>String</c>, or <c>null</c> if the request did not succeed. <strong>Note</strong>: The keys may not be in the same order as the list of keys in the request.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCAppdata_updateEntries(
										MBCString_Array *  theKeys,
										MBCString_Array *  theValues,
										MBCAppdata_updateEntriesCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCAPPDATA_H_ */


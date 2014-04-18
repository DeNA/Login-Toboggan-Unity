//
//  MBCBankInventory.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCBANKINVENTORY_H_
#define MBCBANKINVENTORY_H_

#include "MBCStandardTypes.h"
#include "MBCError.h"
#include "MBCItemData.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark - Notifications
	// Has None!
	
	#pragma mark - Method Callbacks!
	/**
	 * MBCBankInventory_getItemForIdCallback
	 * @description 	 * Callback for retrieving information about a virtual item.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCItemData * itemData Information about the virtual item, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankInventory_getItemForIdCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCItemData * itemData,
				
				void * context
																);
	/**
	 * MBCBankInventory_getItemsForIdsCallback
	 * @description 	 * Callback for retrieving information about multiple virtual items.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCItemData_Array * items Information about the virtual items, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 */
	typedef void (*MBCBankInventory_getItemsForIdsCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				/*AUTORELEASED*/ MBCItemData_Array * items,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCBankInventory_getItemForId
	 * @function
	 * @public
	 * @description 	 * Retrieve information about a virtual item.
	 *
	 * @param const char *  itemId The item's unique ID.			AUTORELEASED
	 * @cb GetItemForIdOnCompleteCallback  onComplete 
		 * Callback for retrieving information about a virtual item.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCItemData * itemData Information about the virtual item, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankInventory_getItemForId(
										const char *  itemId,
										MBCBankInventory_getItemForIdCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
	/**
	 * MBCBankInventory_getItemsForIds
	 * @function
	 * @public
	 * @description 	 * Retrieve information about the virtual items with the specified item IDs.
	 *
	 * @param MBCString_Array *  itemIds The IDs of the virtual items.			AUTORELEASED
	 * @cb GetItemsForIdsOnCompleteCallback  onComplete 
		 * Callback for retrieving information about multiple virtual items.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param MBCItemData_Array * items Information about the virtual items, or <c>null</c> if the request did not succeed.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCBankInventory_getItemsForIds(
										MBCString_Array *  itemIds,
										MBCBankInventory_getItemsForIdsCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCBANKINVENTORY_H_ */


//
//  MBCTransaction.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCTRANSACTION_H_
#define MBCTRANSACTION_H_

#include "MBCStandardTypes.h"
#include "MBCBillingItem.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields
/**
 * Enumeration for transaction states.
 * @region Common
 */
typedef enum {
	/**
	 *
	 * The transaction is new.
	 */
	MBCTransactionStateNew = 0, 
	/**
	 *
	 * The transaction has been authorized and is ready to be opened.
	 */
	MBCTransactionStateAuthorized = 1, 
	/**
	 *
	 * The transaction has been canceled.
	 */
	MBCTransactionStateCanceled = 2, 
	/**
	 *
	 * The transaction has been opened, and the user's funds have been placed into escrow.
	 */
	MBCTransactionStateOpen = 3, 
	/**
	 *
	 * The transaction has been closed, and the user's funds have been captured.
	 */
	MBCTransactionStateClosed = 4, 
	/**

	 */
	MBCTransactionStateSame = 5, 
	/**

	 */
	MBCTransactionStateInvalid = 6
} MBCTransactionState;
#define IsMBCTransactionState(intFlag) (!((intFlag < 0) || (intFlag > 6)))

	#pragma mark Structs
	typedef struct {
		volatile int32_t __CAPI_REFCOUNT; // VERY INTERNAL
		void * __CAPI_NATIVEREF; // ALSO VERY INTERNAL
		
		MBC_Common_IsActive(const char * uid);
		MBC_Common_IsActive(const char * transactionId);
		MBC_Common_IsActive(MBCBillingItem_Array * items);
		MBC_Common_IsActive(const char * comment);
		MBC_Common_IsActive(MBCTransactionState state);
		MBC_Common_IsActive(const char * published);
		MBC_Common_IsActive(const char * updated);
	}  MBCTransaction;
	
	MBCArrayForType(Transaction,MBCTransaction *);
	
	#pragma mark - Retain/Release (produces type-specific MBCRetain & MBCRelease)
	MBCRetainPrototype(Transaction);
	MBCRetainPrototype(Transaction_Array);
	MBCReleasePrototype(Transaction);
	MBCReleasePrototype(Transaction_Array);
	
	#pragma mark - Constructors
	/**
	 * Constructors return objects with a REFCOUNT of 1, you must call MBCRelease when you're done!
	 */
	MBCTransaction * MBCConstructTransaction(void * __CAPI_NATIVEREF);
	MBCTransaction_Array * MBCConstructTransaction_Array(void * __CAPI_NATIVEREF);
	
	MBCTransaction * MBCCopyConstructTransaction(MBCTransaction * foreignObject, bool shouldDeepCopy); // Copies object into C address-space
	MBCTransaction_Array * MBCCopyConstructTransaction_Array(MBCTransaction_Array * foreignObject, bool shouldCopyElements); // Copies object array into C address-space
	
	/**
	 * @private
	 * Fills a previously allocated struct (Internal)
	 */
	void MBCFillStructTransaction(void * structObj, void * __CAPI_NATIVEREF);
	void MBCFillStructTransaction_Array(void *structObj, void * __CAPI_NATIVEREF); 
	
	#pragma mark - Notifications
	// Has None!
	
	#pragma mark - Method Callbacks!
	
	#pragma mark - Static Methods
	// None!
	#pragma mark - Instance Methods
	// None!


#ifdef __cplusplus
}
#endif

#endif /* MBCTRANSACTION_H_ */


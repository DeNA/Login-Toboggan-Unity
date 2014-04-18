//
//  MBTransaction.h
//  mobage-ndk
//
//  Created by Andy Block on 3/15/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#import <Foundation/Foundation.h>
#import "MBDataModel.h"

/**
 * @file MBTransaction.h
 * Model for information about a Bank transaction.
 * @since 1.5
 */

/**
 * Enumeration for transaction states.
 * @since 1.5
 */
typedef enum {
    /**
     * The transaction is new.
     * @since 1.5
     */
	kMBTransactionStateNew = 0,
	MBTransactionStateNew = 0,
    /**
     * The transaction has been authorized and is ready to be opened.
     * @since 1.5
     */
	kMBTransactionStateAuthorized = 1,
	MBTransactionStateAuthorized = 1,
    /**
     * The transaction has been canceled.
     * @since 1.5
     */
	kMBTransactionStateCanceled = 2,
	MBTransactionStateCanceled = 2,
    /**
     * The transaction has been opened, and the user's funds have been placed into escrow.
     * @since 1.5
     */
	kMBTransactionStateOpen = 3,
	MBTransactionStateOpen = 3,
    /**
     * The transaction has been closed, and the user's funds have been captured.
     * @since 1.5
     */
	kMBTransactionStateClosed = 4,
	MBTransactionStateClosed = 4,
	
	kMBTransactionStateSame = -1,
	MBTransactionStateSame = -1,
	
	kMBTransactionStateInvalid = -2,
	MBTransactionStateInvalid = -2
	
} MBTransactionState;

/**
 * Stores information about a Bank transaction.
 * @since 1.5
 */
@protocol MBTransaction <MBDataModel>
/**
 * The transaction's unique ID.
 * @since 1.5
 */
@property (nonatomic, readwrite, strong) NSString* transactionId;
/**
 * The billing items for the transaction. The array must contain only one item, which 
 * must be an <code>MBBillingItem</code>.
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSArray* items;
/**
 * A comment on the transaction. On the US/worldwide platform, this comment is not
 * currently displayed to users.
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSString* comment;
/**
 * The transaction's current state.
 * @since 1.5
 */
@property (nonatomic, readonly, assign) MBTransactionState state;
/**
 * The date and time when the transaction was created, represented in Unix time (milliseconds since
 * 00:00:00 UTC on January 1, 1970).
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSString* published;
/**
 * The date and time when the transaction was last modified, represented in Unix time (milliseconds 
 * since 00:00:00 UTC on January 1, 1970).
 * @since 1.5
 */
@property (nonatomic, readonly, strong) NSString* updated;

+ (id) transaction;
+ (NSString *)stringForState:(MBTransactionState)state;
+ (MBTransactionState)stateFromString:(NSString *)state;

@end

typedef NSObject<MBTransaction> MBTransactionProtocol;

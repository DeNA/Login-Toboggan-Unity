//
//  MBCProfanity.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCPROFANITY_H_
#define MBCPROFANITY_H_

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
	 * MBCProfanity_checkProfanityCallback
	 * @description 	 * Callback for checking a text string for profane or offensive words.
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param bool textIsValid Set to <c>true</c> if the string is valid, or <c>false</c> if the string contains profane or offensive words.			
	 */
	typedef void (*MBCProfanity_checkProfanityCallback)(
				MBCSimpleAPIStatus status,
				/*AUTORELEASED*/ MBCError * error,
				bool textIsValid,
				
				void * context
																);
	
	#pragma mark - Static Methods
	/**
	 * MBCProfanity_checkProfanity
	 * @function
	 * @public
	 * @description 	 * Check a text string to determine whether it contains words that are clearly profane or offensive.
	 *
	 * @param const char *  text The string to check for profanity.			AUTORELEASED
	 * @cb CheckProfanityOnCompleteCallback  onComplete 
		 * Callback for checking a text string for profane or offensive words.			
	 * @cb-param MBCSimpleAPIStatus status Information about the result of the request.			
	 * @cb-param MBCError * error Information about the error, or <c>null</c> if there was not an error.			AUTORELEASED
	 * @cb-param bool textIsValid Set to <c>true</c> if the string is valid, or <c>false</c> if the string contains profane or offensive words.			
	 * <br/>
	 * 
	 */
	void MBCProfanity_checkProfanity(
										const char *  text,
										MBCProfanity_checkProfanityCallback onComplete,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );


#ifdef __cplusplus
}
#endif

#endif /* MBCPROFANITY_H_ */


//
//  MBCAnalytics.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCANALYTICS_H_
#define MBCANALYTICS_H_

#include "MBCStandardTypes.h"

#ifdef __cplusplus
extern "C" {
#endif

#pragma mark Enums / Bitfields

	#pragma mark - Notifications
	// Has None!
	
	#pragma mark - Method Callbacks!
	
	#pragma mark - Static Methods
#if MB_WW
	/**
	 * MBCAnalytics_reportEvent
	 * @function
	 * @public
	 * @description 	 * <strong>DEPRECATED:</strong> Use <c>reportGameEvent</c> or <c>reportErrorEvent</c> instead.
	 * <p>
	 * Report an Analytics event.
	 * <p>
	 * The <c>eventString</c> parameter is a <a href="http://www.json.org/">JSON</a>-formatted
	 * string that contains the following properties:
	 * <ul>
	 * <li><c>evcl</c>: Must contain the value <c>GAME</c>.</li>
	 * <li><c>evid</c>: An alphanumeric string identifying the type of event that is being reported.
	 * Must not contain spaces, punctuation, or other special characters.</li>
	 * <li><c>evpl</c>: A JSON object whose properties are key/value pairs with additional
	 * information about the event. Each key must be a string, and each value must be a string or
	 * number.</li>
	 * <li><c>plst</c>: Information about the user's current state, such as the user's level and
	 * experience points. Do not include information that is unique to a specific user, such as a
	 * user ID or nickname.</li>
	 * </ul>
	 * For example, your app could report a <c>battle</c> event whenever a user completes a
	 * battle, passing a value similar to the following in the <c>eventString</c> parameter.
	 * (For clarity, this example is split into multiple lines.)
	 * <code>
	 * {
	 *   "evcl": "GAME",
	 *   "evid": "battle",
	 * 	 "evpl": {
	 * 		"enemyType": "greenDragon",
	 * 		"enemyHitPoints": 58,
	 * 		"quest": "treasureHunt",
	 * 		"battleWon": "true"
	 * 	 },
	 * 	 "plst": {
	 * 		"hitPoints": 36,
	 * 		"level": 8,
	 * 		"xp": 143
	 * 	 }
	 * }
	 * </code>
	 *
	 * @param const char *  eventString A JSON-formatted string with information about the event, using the format shown above.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCAnalytics_reportEvent(
										const char *  eventString,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_WW
#if MB_WW
	/**
	 * MBCAnalytics_reportGameEvent
	 * @function
	 * @public
	 * @description 	 * Report a custom, app-specific event.
	 *
	 * @param const char *  eventId An alphanumeric string identifying the event being reported.			AUTORELEASED
	 * @param const char *  payload Additional information about the event, or <c>nil</c> if there is no additional information to provide. Encode information as key-value pairs in a <a href="http://www.json.org/">JSON</a>-formatted string.			AUTORELEASED
	 * @param const char *  playerState Information about the user's current state, or <c>nil</c> to omit this information. Examples of a user's state include a user's level, number of lives remaining, and so on. Encode information as key-value pairs in a <a href="http://www.json.org/">JSON</a>-formatted string. <strong>Note:</strong> Do not include information that is unique to the user, such as a user ID or nickname.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCAnalytics_reportGameEvent(
										const char *  eventId,
										const char *  payload,
										const char *  playerState,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_WW
#if MB_WW
	/**
	 * MBCAnalytics_reportErrorEvent
	 * @function
	 * @public
	 * @description 	 * Report an error event.
	 *
	 * @param const char *  error %Error message.			AUTORELEASED
	 * <br/>
	 * 
	 */
	void MBCAnalytics_reportErrorEvent(
										const char *  error,
										
										void * context	//Arbitrary Context Object, which will be passed back to callbacks
						   );
#endif // MB_WW


#ifdef __cplusplus
}
#endif

#endif /* MBCANALYTICS_H_ */


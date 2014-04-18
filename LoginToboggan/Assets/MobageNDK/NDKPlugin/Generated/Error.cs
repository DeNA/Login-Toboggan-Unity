//
//  Error.cs
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//

#if !(HAS_MOBAGE_DESKTOP_SHIM && UNITY_EDITOR)
// Mobage don't support Unity Editor right now. (add "-define:HAS_MOBAGE_DESKTOP_SHIM" to /Assets/smcs.rsp to override)


using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Mobage {

	/**
	 * <summary> Information about a Mobage error.</summary>
	 * <remarks>
	 *
	 * </remarks>
	 */
	public partial class Error {}
	#region Enums / Bitfields
		/**
		 * Enumeration of standard Mobage API errors.
		 */
		public enum StandardError {
			/**
					 *
		 * A server error occurred.
			 */
			ServerError = 10001, 
			/**
					 *
		 * The device cannot connect to the network.
			 */
			NetworkUnavailable = 10002, 
			/**
					 *
		 * The request was missing required information.
			 */
			MissingData = 10003, 
			/**
					 *
		 * The request contained invalid data.
			 */
			InvalidData = 10004, 
			/**
					 *
		 * An unknown error occurred.
			 */
			UnknownError = 10005, 
			/**
					 *
		 * A message from the server could not be parsed.
			 */
			ParseError = 10006, 
			/**
					 *
		 * There is no authorization token available for the user.
			 */
			NoAuthToken = 10007, 
		};

		/**
		 * Enumeration of Mobage errors that relate to HTTP errors.
		 */
		public enum HTTPError {
			/**
					 *
		 * The Mobage server is not currently available.
			 */
			ServerDown = 109, 
			/**
					 *
		 * The app must be upgraded to support the current version of Mobage.
			 */
			UpgradeRequired = 110, 
			/**
					 *
		 * The user has been banned from Mobage.
			 */
			UserBanned = 111, 
			/**
					 *
		 * The user has not agreed to the Mobage terms of service.
			 */
			AgreementNeeded = 112, 
			/**
					 *
		 * The request data was invalid.
			 */
			BadRequest = 400, 
			/**
					 *
		 * The specified data was not found.
			 */
			RecordNotFound = 404, 
			/**
					 *
		 * An authentication error occurred.
			 */
			Unauthorized = 401, 
			/**
					 *
		 * Access was forbidden for reasons other than an authentication error.
			 */
			PermissionDenied = 403, 
			/**
					 *
		 * An internal server error occurred.
			 */
			FirstInternalServerError = 500, 
			/**
					 *
		 * An unknown error occurred.
			 */
			LastHTTPError = 599, 
		};

		/**
		 * Enumeration of errors for Mobage's common APIs, which are supported in all regions.
		 */
		public enum CommonAPIError {
			/**
					 *
		 * The user's session is invalid.
			 */
			InvalidSession = 20001, 
			/**
					 *
		 * The method was called without a required parameter.
			 */
			MethodMissingArgument = 20002, 
			/**
					 *
		 * The method was called with an invalid parameter value.
			 */
			MethodInvalidArgument = 20003, 
			/**
					 *
		 * The method has not been implemented.
			 */
			MethodNotImplemented = 20004, 
			/**
					 *
		 * The current Mobage server does not support this method.
			 */
			MethodNotSupported = 20005, 
		};

		/**
		 * Enumeration of Mobage analytics errors.
		 */
		public enum AnalyticsServerError {
			/**
					 *
		 * An invalid response was received from the analytics server.
			 */
			InvalidResponse = 30001, 
			/**
					 *
		 * The analytics server rejected the request.
			 */
			EventRejected = 30002, 
			/**
					 *
		 * The analytics event size exceeded the maximum size.
			 */
			EventSizeTooLarge = 30003, 
			/**
					 *
		 * The analytics event property size exceeded the maximum size.
			 */
			EventPropertySizeTooLarge = 30004, 
			/**
					 *
		 * The analytics event contained an invalid array.
			 */
			EventContainsInvalidArray = 30005, 
		};

		/**
		 * Enumeration of Mobage Bank errors.
		 */
		public enum BankError {
			/**
					 *
		 * The Bank request could not be completed, because the transaction is not in the correct  state for the requested method.
			 */
			InvalidStateTransition = 40001, 
			/**
			
			 */
			DeadTransaction = 40002, 
			/**
			
			 */
			GetItemFail = 40003, 
			/**
			
			 */
			PurchaseFail = 40004, 
			/**
			
			 */
			CreditFail = 40005, 
			/**
			
			 */
			TransactionAlreadyOpen = 40006, 
			/**
			
			 */
			ProcessFail = 40007, 
			/**
			
			 */
			InvalidCredentials = 40008, 
			/**
			
			 */
			UnkownError = 40009, 
			/**
			
			 */
			PaymentCancelled = 40010, 
			/**
			
			 */
			PaymentInvalid = 40011, 
			/**
			
			 */
			PaymentNotAllowed = 40012, 
		};

		/**
	
		 */
		public enum ErrorEnum {
			/**
					 The Mobage server is not currently available.
			 */
			ServerDown = 109, 
			/**
					 The app must be upgraded to support the current version of Mobage.
			 */
			UpgradeRequired = 110, 
			/**
					 The user has been banned from Mobage.
			 */
			UserBanned = 111, 
			/**
					 The user has not agreed to the Mobage terms of service.
			 */
			AgreementNeeded = 112, 
			/**
					 The request data was invalid.
			 */
			BadRequest = 400, 
			/**
					 An authentication error occurred.
			 */
			Unauthorized = 401, 
			/**
					 Access was forbidden for reasons other than an authentication error.
			 */
			PermissionDenied = 403, 
			/**
					 The specified data was not found.
			 */
			RecordNotFound = 404, 
			/**
					 A server error occurred.
			 */
			ServerError = 10001, 
			/**
					 The device cannot connect to the network.
			 */
			NetworkUnavailable = 10002, 
			/**
					 The request was missing required information.
			 */
			MissingData = 10003, 
			/**
					 The request contained invalid data.
			 */
			InvalidData = 10004, 
			/**
					 An unknown error occurred.
			 */
			UnknownError = 10005, 
			/**
					 A message from the server could not be parsed.
			 */
			ParseError = 10006, 
			/**
					 There is no authorization token available for the user.
			 */
			NoAuthToken = 10007, 
			/**
			
			 */
			NoConsumerKey = 10008, 
			/**
			
			 */
			MobageNotInitialized = 10009, 
			/**
			
			 */
			ServerUnexpectedResponse = 10010, 
			/**
			
			 */
			NoActiveCampaigns = 10011, 
			/**
					 The user's session is invalid.
			 */
			CommonAPIInvalidSessionError = 20001, 
			/**
					 The method was called without a required parameter.
			 */
			CommonAPIMethodMissingArgumentError = 20002, 
			/**
					 The method was called with an invalid parameter value.
			 */
			CommonAPIMethodInvalidArgumentError = 20003, 
			/**
					 The method has not been implemented.
			 */
			CommonAPIMethodNotImplementedError = 20004, 
			/**
					 The current Mobage server does not support this method.
			 */
			CommonAPIMethodNotSupportedError = 20005, 
			/**
					 An invalid response was received from the analytics server.
			 */
			AnalyticsServerInvalidResponse = 30001, 
			/**
					 The analytics server rejected the request.
			 */
			AnalyticsServerEventRejected = 30002, 
			/**
					 The analytics event size exceeded the maximum size.
			 */
			AnalyticsServerEventSizeTooLarge = 30003, 
			/**
					 The analytics event property size exceeded the maximum size.
			 */
			AnalyticsServerEventPropertySizeTooLarge = 30004, 
			/**
					 The analytics event contained an invalid array.
			 */
			AnalyticsServerEventContainsInvalidArray = 30005, 
			/**
					 The Bank request could not be completed, because the transaction is not in the correct state for the requested method.
			 */
			BankErrorInvalidStateTransition = 40001, 
			/**
			
			 */
			BankErrorDeadTransaction = 40002, 
			/**
			
			 */
			BankErrorGetItemFail = 40003, 
			/**
			
			 */
			BankErrorPurchaseFail = 40004, 
			/**
			
			 */
			BankErrorCreditFail = 40005, 
			/**
			
			 */
			BankErrorTransactionAlreadyOpen = 40006, 
			/**
			
			 */
			BankErrorProcessFail = 40007, 
			/**
			
			 */
			BankErrorInvalidCredentials = 40008, 
			/**
			
			 */
			BankErrorUnknown = 40009, 
			/**
			
			 */
			BankErrorPaymentCancelled = 40010, 
			/**
			
			 */
			BankErrorPaymentInvalid = 40011, 
			/**
			
			 */
			BankErrorPaymentNotAllowed = 40012, 
			/**
			
			 */
			BankErrorInvoiceIDMissing = 40013, 
			/**
			
			 */
			BankErrorTransactionDataMissing = 40014, 
			/**
			
			 */
			CacheDiskFailed = 50001, 
			/**
			
			 */
			InvalidConfiguration = 50002, 
			/**
			
			 */
			UIAlreadyShowing = 60001, 
			/**
			
			 */
			UserCancelled = 60002, 
			/**
			
			 */
			LoginErrorRegLoginCancelled = 70001, 
			/**
			
			 */
			LoginErrorRegNameTaken = 70002, 
			/**
			
			 */
			LoginErrorRegistrationCancelled = 70003, 
			/**
			
			 */
			LoginErrorFacebookInvalidSession = 70004, 
			/**
			
			 */
			LoginErrorFacebookError = 70005, 
			/**
			
			 */
			LoginErrorFacebookCancel = 70006, 
			/**
			
			 */
			LoginErrorLoginALreadyInFlight = 70007, 
			/**
			
			 */
			LoginErrorFacebookAlreadyLinked = 70008, 
			/**
			
			 */
			LoginErrorFacebookOperationInProgress = 70009, 
			/**
			
			 */
			LoginErrorFacebookAppBlocked = 70010, 
			/**
			
			 */
			LoggedInWithDifferentUser = 80001, 
			/**
			
			 */
			GameNotOpenedInMarket = 80002, 
			/**
			
			 */
			TooManyFailedLoginAttempts = 90001, 
			/**
					 No ping back was received from the document in the web view (Android).
			 */
			NoPingBackFromDocument = 100001, 
			/**
					 URL gave an invalid response when pinged (non-2xx).
			 */
			InvalidURLResponse = 100002, 
			/**
					 Console error was logged while loading web view.
			 */
			ConsoleErrorDuringLoad = 100003, 
			/**
					 Unable to load experience.
			 */
			UnableToLoadExperience = 100004, 
			/**
					 Received error while loading document.
			 */
			ReceivedErrorDuringLoad = 100005, 
			/**
			
			 */
			MalformedSitemap = 10006, 
			/**
			
			 */
			UnableToDownloadSitemap = 10007, 
		};

		/**
	
		 */
		public enum MobageAPIErrorType {
			/**
					 The Mobage server is not currently available.
			 */
			ServerDown = 109, 
			/**
					 The app must be upgraded to support the current version of Mobage.
			 */
			UpgradeRequired = 110, 
			/**
					 The user has been banned from Mobage.
			 */
			UserBanned = 111, 
			/**
					 The user has not agreed to the Mobage terms of service.
			 */
			AgreementNeeded = 112, 
			/**
					 The request data was invalid.
			 */
			BadRequest = 400, 
			/**
					 An authentication error occurred.
			 */
			Unauthorized = 401, 
			/**
					 Access was forbidden for reasons other than an authentication error.
			 */
			PermissionDenied = 403, 
			/**
					 The specified data was not found.
			 */
			RecordNotFound = 404, 
			/**
					 A server error occurred.
			 */
			ServerError = 10001, 
			/**
					 The device cannot connect to the network.
			 */
			NetworkUnavailable = 10002, 
			/**
					 The request was missing required information.
			 */
			MissingData = 10003, 
			/**
					 The request contained invalid data.
			 */
			InvalidData = 10004, 
			/**
					 An unknown error occurred.
			 */
			UnknownError = 10005, 
			/**
					 A message from the server could not be parsed.
			 */
			ParseError = 10006, 
			/**
					 There is no authorization token available for the user.
			 */
			NoAuthToken = 10007, 
			/**
					 The user's session is invalid.
			 */
			CommonAPIInvalidSessionError = 20001, 
			/**
					 The method was called without a required parameter.
			 */
			CommonAPIMethodMissingArgumentError = 20002, 
			/**
					 The method was called with an invalid parameter value.
			 */
			CommonAPIMethodInvalidArgumentError = 20003, 
			/**
					 The method has not been implemented.
			 */
			CommonAPIMethodNotImplementedError = 20004, 
			/**
					 The current Mobage server does not support this method.
			 */
			CommonAPIMethodNotSupportedError = 20005, 
			/**
					 An invalid response was received from the analytics server.
			 */
			AnalyticsServerInvalidResponse = 30001, 
			/**
					 The analytics server rejected the request.
			 */
			AnalyticsServerEventRejected = 30002, 
			/**
					 The analytics event size exceeded the maximum size.
			 */
			AnalyticsServerEventSizeTooLarge = 30003, 
			/**
					 The analytics event property size exceeded the maximum size.
			 */
			AnalyticsServerEventPropertySizeTooLarge = 30004, 
			/**
					 The analytics event contained an invalid array.
			 */
			AnalyticsServerEventContainsInvalidArray = 30005, 
			/**
					 The Bank request could not be completed, because the transaction is not in the correct state for the requested method.
			 */
			BankErrorInvalidStateTransition = 40001, 
			/**
					 No ping back was received from the document in the web view (Android).
			 */
			NoPingBackFromDocument = 100001, 
			/**
					 URL gave an invalid response when pinged (non-2xx).
			 */
			InvalidURLResponse = 100002, 
			/**
					 Console error was logged while loading web view.
			 */
			ConsoleErrorDuringLoad = 100003, 
			/**
					 Unable to load experience.
			 */
			UnableToLoadExperience = 100004, 
			/**
					 Received error while loading document.
			 */
			ReceivedErrorDuringLoad = 100005, 
		};

	#endregion

/* Comment out for now until we can transfer over into single Enum class

#region Enums / Bitfields

	 * Enumeration of standard Mobage API errors.

	public enum StandardError {

				 *
		 * A server error occurred.

		ServerError = 10001, 

				 *
		 * The device cannot connect to the network.

		NetworkUnavailable = 10002, 

				 *
		 * The request was missing required information.

		MissingData = 10003, 

				 *
		 * The request contained invalid data.

		InvalidData = 10004, 

				 *
		 * An unknown error occurred.

		UnknownError = 10005, 

				 *
		 * A message from the server could not be parsed.

		ParseError = 10006, 

				 *
		 * There is no authorization token available for the user.

		NoAuthToken = 10007, 
	};
	

	 * Enumeration of Mobage errors that relate to HTTP errors.

	public enum HTTPError {

				 *
		 * The Mobage server is not currently available.

		ServerDown = 109, 

				 *
		 * The app must be upgraded to support the current version of Mobage.

		UpgradeRequired = 110, 

				 *
		 * The user has been banned from Mobage.

		UserBanned = 111, 

				 *
		 * The user has not agreed to the Mobage terms of service.

		AgreementNeeded = 112, 

				 *
		 * The request data was invalid.

		BadRequest = 400, 

				 *
		 * The specified data was not found.

		RecordNotFound = 404, 

				 *
		 * An authentication error occurred.

		Unauthorized = 401, 

				 *
		 * Access was forbidden for reasons other than an authentication error.

		PermissionDenied = 403, 

				 *
		 * An internal server error occurred.

		FirstInternalServerError = 500, 

				 *
		 * An unknown error occurred.

		LastHTTPError = 599, 
	};
	

	 * Enumeration of errors for Mobage's common APIs, which are supported in all regions.

	public enum CommonAPIError {

				 *
		 * The user's session is invalid.

		InvalidSession = 20001, 

				 *
		 * The method was called without a required parameter.

		MethodMissingArgument = 20002, 

				 *
		 * The method was called with an invalid parameter value.

		MethodInvalidArgument = 20003, 

				 *
		 * The method has not been implemented.

		MethodNotImplemented = 20004, 

				 *
		 * The current Mobage server does not support this method.

		MethodNotSupported = 20005, 
	};
	

	 * Enumeration of Mobage analytics errors.

	public enum AnalyticsServerError {

				 *
		 * An invalid response was received from the analytics server.

		InvalidResponse = 30001, 

				 *
		 * The analytics server rejected the request.

		EventRejected = 30002, 

				 *
		 * The analytics event size exceeded the maximum size.

		EventSizeTooLarge = 30003, 

				 *
		 * The analytics event property size exceeded the maximum size.

		EventPropertySizeTooLarge = 30004, 

				 *
		 * The analytics event contained an invalid array.

		EventContainsInvalidArray = 30005, 
	};
	

	 * Enumeration of Mobage Bank errors.

	public enum BankError {

				 *
		 * The Bank request could not be completed, because the transaction is not in the correct  state for the requested method.

		InvalidStateTransition = 40001, 

		

		DeadTransaction = 40002, 

		

		GetItemFail = 40003, 

		

		PurchaseFail = 40004, 

		

		CreditFail = 40005, 

		

		TransactionAlreadyOpen = 40006, 

		

		ProcessFail = 40007, 

		

		InvalidCredentials = 40008, 

		

		UnkownError = 40009, 

		

		PaymentCancelled = 40010, 

		

		PaymentInvalid = 40011, 

		

		PaymentNotAllowed = 40012, 
	};
	



	public enum ErrorEnum {

				 The Mobage server is not currently available.

		ServerDown = 109, 

				 The app must be upgraded to support the current version of Mobage.

		UpgradeRequired = 110, 

				 The user has been banned from Mobage.

		UserBanned = 111, 

				 The user has not agreed to the Mobage terms of service.

		AgreementNeeded = 112, 

				 The request data was invalid.

		BadRequest = 400, 

				 An authentication error occurred.

		Unauthorized = 401, 

				 Access was forbidden for reasons other than an authentication error.

		PermissionDenied = 403, 

				 The specified data was not found.

		RecordNotFound = 404, 

				 A server error occurred.

		ServerError = 10001, 

				 The device cannot connect to the network.

		NetworkUnavailable = 10002, 

				 The request was missing required information.

		MissingData = 10003, 

				 The request contained invalid data.

		InvalidData = 10004, 

				 An unknown error occurred.

		UnknownError = 10005, 

				 A message from the server could not be parsed.

		ParseError = 10006, 

				 There is no authorization token available for the user.

		NoAuthToken = 10007, 

		

		NoConsumerKey = 10008, 

		

		MobageNotInitialized = 10009, 

		

		ServerUnexpectedResponse = 10010, 

		

		NoActiveCampaigns = 10011, 

				 The user's session is invalid.

		CommonAPIInvalidSessionError = 20001, 

				 The method was called without a required parameter.

		CommonAPIMethodMissingArgumentError = 20002, 

				 The method was called with an invalid parameter value.

		CommonAPIMethodInvalidArgumentError = 20003, 

				 The method has not been implemented.

		CommonAPIMethodNotImplementedError = 20004, 

				 The current Mobage server does not support this method.

		CommonAPIMethodNotSupportedError = 20005, 

				 An invalid response was received from the analytics server.

		AnalyticsServerInvalidResponse = 30001, 

				 The analytics server rejected the request.

		AnalyticsServerEventRejected = 30002, 

				 The analytics event size exceeded the maximum size.

		AnalyticsServerEventSizeTooLarge = 30003, 

				 The analytics event property size exceeded the maximum size.

		AnalyticsServerEventPropertySizeTooLarge = 30004, 

				 The analytics event contained an invalid array.

		AnalyticsServerEventContainsInvalidArray = 30005, 

				 The Bank request could not be completed, because the transaction is not in the correct state for the requested method.

		BankErrorInvalidStateTransition = 40001, 

		

		BankErrorDeadTransaction = 40002, 

		

		BankErrorGetItemFail = 40003, 

		

		BankErrorPurchaseFail = 40004, 

		

		BankErrorCreditFail = 40005, 

		

		BankErrorTransactionAlreadyOpen = 40006, 

		

		BankErrorProcessFail = 40007, 

		

		BankErrorInvalidCredentials = 40008, 

		

		BankErrorUnknown = 40009, 

		

		BankErrorPaymentCancelled = 40010, 

		

		BankErrorPaymentInvalid = 40011, 

		

		BankErrorPaymentNotAllowed = 40012, 

		

		BankErrorInvoiceIDMissing = 40013, 

		

		BankErrorTransactionDataMissing = 40014, 

		

		CacheDiskFailed = 50001, 

		

		InvalidConfiguration = 50002, 

		

		UIAlreadyShowing = 60001, 

		

		UserCancelled = 60002, 

		

		LoginErrorRegLoginCancelled = 70001, 

		

		LoginErrorRegNameTaken = 70002, 

		

		LoginErrorRegistrationCancelled = 70003, 

		

		LoginErrorFacebookInvalidSession = 70004, 

		

		LoginErrorFacebookError = 70005, 

		

		LoginErrorFacebookCancel = 70006, 

		

		LoginErrorLoginALreadyInFlight = 70007, 

		

		LoginErrorFacebookAlreadyLinked = 70008, 

		

		LoginErrorFacebookOperationInProgress = 70009, 

		

		LoginErrorFacebookAppBlocked = 70010, 

		

		LoggedInWithDifferentUser = 80001, 

		

		GameNotOpenedInMarket = 80002, 

		

		TooManyFailedLoginAttempts = 90001, 

				 No ping back was received from the document in the web view (Android).

		NoPingBackFromDocument = 100001, 

				 URL gave an invalid response when pinged (non-2xx).

		InvalidURLResponse = 100002, 

				 Console error was logged while loading web view.

		ConsoleErrorDuringLoad = 100003, 

				 Unable to load experience.

		UnableToLoadExperience = 100004, 

				 Received error while loading document.

		ReceivedErrorDuringLoad = 100005, 

		

		MalformedSitemap = 10006, 

		

		UnableToDownloadSitemap = 10007, 
	};
	



	public enum MobageAPIErrorType {

				 The Mobage server is not currently available.

		ServerDown = 109, 

				 The app must be upgraded to support the current version of Mobage.

		UpgradeRequired = 110, 

				 The user has been banned from Mobage.

		UserBanned = 111, 

				 The user has not agreed to the Mobage terms of service.

		AgreementNeeded = 112, 

				 The request data was invalid.

		BadRequest = 400, 

				 An authentication error occurred.

		Unauthorized = 401, 

				 Access was forbidden for reasons other than an authentication error.

		PermissionDenied = 403, 

				 The specified data was not found.

		RecordNotFound = 404, 

				 A server error occurred.

		ServerError = 10001, 

				 The device cannot connect to the network.

		NetworkUnavailable = 10002, 

				 The request was missing required information.

		MissingData = 10003, 

				 The request contained invalid data.

		InvalidData = 10004, 

				 An unknown error occurred.

		UnknownError = 10005, 

				 A message from the server could not be parsed.

		ParseError = 10006, 

				 There is no authorization token available for the user.

		NoAuthToken = 10007, 

				 The user's session is invalid.

		CommonAPIInvalidSessionError = 20001, 

				 The method was called without a required parameter.

		CommonAPIMethodMissingArgumentError = 20002, 

				 The method was called with an invalid parameter value.

		CommonAPIMethodInvalidArgumentError = 20003, 

				 The method has not been implemented.

		CommonAPIMethodNotImplementedError = 20004, 

				 The current Mobage server does not support this method.

		CommonAPIMethodNotSupportedError = 20005, 

				 An invalid response was received from the analytics server.

		AnalyticsServerInvalidResponse = 30001, 

				 The analytics server rejected the request.

		AnalyticsServerEventRejected = 30002, 

				 The analytics event size exceeded the maximum size.

		AnalyticsServerEventSizeTooLarge = 30003, 

				 The analytics event property size exceeded the maximum size.

		AnalyticsServerEventPropertySizeTooLarge = 30004, 

				 The analytics event contained an invalid array.

		AnalyticsServerEventContainsInvalidArray = 30005, 

				 The Bank request could not be completed, because the transaction is not in the correct state for the requested method.

		BankErrorInvalidStateTransition = 40001, 

				 No ping back was received from the document in the web view (Android).

		NoPingBackFromDocument = 100001, 

				 URL gave an invalid response when pinged (non-2xx).

		InvalidURLResponse = 100002, 

				 Console error was logged while loading web view.

		ConsoleErrorDuringLoad = 100003, 

				 Unable to load experience.

		UnableToLoadExperience = 100004, 

				 Received error while loading document.

		ReceivedErrorDuringLoad = 100005, 
	};
	
#endregion
*/
	
	public partial class Error {
		// Properties!
		/**
		 * A unique string indicating the source of the error. All Mobage errors will contain the same value in this property.
		 */
		[NonSerialized]
		public String domain;
		/**
		 * A unique code identifying the error that occurred. Contains an enumerated value of one of the following:<ul><li>Mobage::AnalyticsServerError</li><li>Mobage::BankError</li><li>Mobage::CommonAPIError</li><li>Mobage::HTTPError</li><li>Mobage::StandardError</li></ul>
		 */
		[NonSerialized]
		public Int32 code;
		/**
		 * A summary of the error that can be displayed to the user.
		 */
		[NonSerialized]
		public String localizedDescription;
		/**
		 * A detailed description of the error that can be used for debugging.
		 */
		[NonSerialized]
		public String description;
		
	}

#region Notifications!
	public partial class Error {
	// Has None!
	}
#endregion // Notifications


#region Delegate Callbacks
	public partial class Error {
	}
#endregion

#region Static Methods
	public partial class Error {
	}
#endregion

#region Instance Methods
	public partial class Error {
	}
#endregion

}


#endif // End compilation exception for UNITY_EDITOR && HAS_MOBAGE_DESKTOP_SHIM

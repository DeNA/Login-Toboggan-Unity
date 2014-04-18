//
//  MBCUtils+iOS.h
//  mobage-ndk
//
//  Copyright (c) 2012, DeNA Co., Ltd. All rights reserved
//
//

#ifndef MBCUTILS_IOS_H_
#define MBCUTILS_IOS_H_

#include "MBCUtils.h"
#include "MBCStandardTypes.h"

#ifdef __cplusplus
extern "C" {
	#include <cstdlib>
	#include <cstring>
#else
	#include <stdlib.h>
	#include <string.h>
#endif


#define MBCToLiteral(type, from) (type)from


// Native->C
#define MBCNativeToCJSONObject(from) MBCToLiteral(void*,from)
#define MBCNativeToCDouble(from) MBCToLiteral(double,from)
#define MBCNativeToCInteger(from) MBCToLiteral(int,from)
#define MBCNativeToCBool(from) MBCToLiteral(bool,from)
#define MBCNativeToCAvatarData(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCAvatarDataArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCBillingItem(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCBillingItemArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCError(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCErrorArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCGameLeaderboard(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCGameLeaderboardArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCItemData(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCItemDataArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRemoteNotificationPayload(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRemoteNotificationPayloadArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRemoteNotificationResponse(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCRemoteNotificationResponseArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCScore(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCScoreArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCString(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCStringArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCTextdataEntry(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCTextdataEntryArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCTransaction(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCTransactionArray(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCUser(from) (from)?(transient_ ## from):NULL
#define MBCNativeToCUserArray(from) (from)?(transient_ ## from):NULL

// C->Native
#define MBCCToNativeJSONObject(from) MBCToLiteral(NSDictionary*,from)
#define MBCCToNativeDouble(from) MBCToLiteral(double,from)
#define MBCCToNativeInteger(from) MBCToLiteral(NSInteger,from)
#define MBCCToNativeBool(from) MBCToLiteral(BOOL,from)
#define MBCCToNativeString(from) ((from) ? [NSString stringWithUTF8String:from] : nil)
#define _MBCCToNativeArrayPrototype(type) NSArray* _MBCCToNative ## type ## Array(MBC ## type ## _Array* from)
#define _MBCCToNativeArrayBody(type,objcType,t2Convert) \
NSArray* _MBCCToNative ## type ## Array(MBC ## type ## _Array* from){ \
	int len = from ? from->length : 0; \
	NSMutableArray * tmp = [NSMutableArray arrayWithCapacity: len]; \
	for (int i = 0; i < len; i++){ \
		objcType t2 = MBCCToNative ## type (from->elements[i]); \
		if (t2){[tmp addObject:t2Convert];} \
	}\
	return tmp;\
}

#define MBCCToNativeDoubleArray(from) _MBCCToNativeDoubleArray(from)
#define MBCCToNativeIntegerArray(from) _MBCCToNativeIntegerArray(from)
#define MBCCToNativeBoolArray(from) _MBCCToNativeBoolArray(from)

// C->C
#define MBCCToJSONObject(from,deepCopy) MBCToLiteral(void*,from)
#define MBCCToCDouble(from,deepCopy) MBCToLiteral(double,from)
#define MBCCToCInteger(from,deepCopy) MBCToLiteral(int,from)
#define MBCCToCBool(from,deepCopy) MBCToLiteral(bool,from)
#define MBCCToCString(from,deepCopy) _MBCCStringCopy(from)
const char * _MBCCStringCopy(const char * input);

// Native->C_Struct
#define MBCCopyLiteralIntoStructPtrTyped(type, structPtr, objc, property) {(structPtr)->property = [((type*)objc) property];}

#define MBCCopyJSONObjectIntoStructPtrTyped(type, structPtr, objc, property) {MBCCopyLiteralIntoStructPtr(type, structPtr,objc,property)}
#define MBCCopyDoubleIntoStructPtrTyped(type, structPtr, objc, property) {MBCCopyLiteralIntoStructPtrTyped(type, structPtr,objc,property)}
#define MBCCopyIntegerIntoStructPtrTyped(type, structPtr, objc, property) {MBCCopyLiteralIntoStructPtrTyped(type, structPtr,objc,property)}
#define MBCCopyBoolIntoStructPtrTyped(type, structPtr, objc, property) {MBCCopyLiteralIntoStructPtrTyped(type,structPtr,objc,property)}

#define MBCCopyJSONObjectIntoStructPtr(structPtr, objc, property) {MBCCopyJSONObjectIntoStructPtrTyped(MBC_OBJC_CLASSNAME,structPtr,objc,property)}
#define MBCCopyDoubleIntoStructPtr(structPtr, objc, property) {MBCCopyDoubleIntoStructPtrTyped(MBC_OBJC_CLASSNAME,structPtr,objc,property)}
#define MBCCopyIntegerIntoStructPtr(structPtr, objc, property) {MBCCopyDoubleIntoStructPtrTyped(MBC_OBJC_CLASSNAME,structPtr,objc,property)}
#define MBCCopyBoolIntoStructPtr(structPtr, objc, property) {MBCCopyDoubleIntoStructPtrTyped(MBC_OBJC_CLASSNAME,structPtr,objc,property)}

#define _MBCDestroyPropertyLiteral(structPtr,property) /* property is a literal */
#define _MBCDestroyPropertyJSONObject(structPtr,property) (structPtr)->property = nil;
#define _MBCDestroyPropertyDouble(structPtr,property) _MBCDestroyPropertyLiteral(structPtr,property)
#define _MBCDestroyPropertyInteger(structPtr,property) _MBCDestroyPropertyLiteral(structPtr,property)
#define _MBCDestroyPropertyBool(structPtr,property) _MBCDestroyPropertyLiteral(structPtr,property)

_MBCCToNativeArrayPrototype(Double);
_MBCCToNativeArrayPrototype(Integer);
_MBCCToNativeArrayPrototype(Bool);

// This is an exceptional error, object gets leaked!
#define MBCMakeError(domain,code,msg) MBCConstructError((__bridge void *)[MBError makeErrorFromString: @"" msg withDomain: @"" domain andCode: code])

	
// Callback storage stuff. Workaround for lack of inheritance in c
void setDelayedCallback(bool delay);
bool getDelayedCallback();

struct callback_invoker;
struct callback_invoker_vtable {
	void (*invokeCallback)(struct callback_invoker*);
	void (*release)(struct callback_invoker*);
};
struct callback_invoker {
	struct callback_invoker_vtable* __vtable;
};

extern void storeCallback(struct callback_invoker* invoker);
extern void invokeAllCallbacks();
	
#ifdef __cplusplus
}
#endif

#endif

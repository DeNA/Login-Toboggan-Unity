//
//  MB_G_Log.h
//  mobage-ndk
//
//  Created by Frederic Barthelemy on 2/11/12.
//  Copyright (c) 2012 ngmoco:). All rights reserved.
//

#ifndef mobage_ndk_MB_G_Log_h
#define mobage_ndk_MB_G_Log_h

#ifndef MB_G_LOG
#define MB_G_LOG 1
#endif

#ifndef MB_G_LOG_ERROR
#define MB_G_LOG_ERROR 1
#endif

#ifndef MB_G_LOG_INFO
#define MB_G_LOG_INFO 0
#endif

#ifndef MB_G_LOG_CLASSLOAD
#define MB_G_LOG_CLASSLOAD 1
#endif

#if MB_G_LOG
#import <Foundation/Foundation.h>
#define MB_G_LOG_HAS_SET_ENABLED 1
FOUNDATION_EXPORT void MBLog_SetEnabled(BOOL enabled);
FOUNDATION_EXPORT BOOL MBLog_GetEnabled();
FOUNDATION_EXPORT void MBLog(NSString *fmt, ...);
#define MB_G_Log(format, args...) MBLog(format, ## args)
#else
#define MB_G_Log(format, args...) 
#endif

#if MB_G_LOG || MB_G_LOG_ERROR
#define MB_G_LogError(format, args...) NSLog(format, ## args)
#else
#define MB_G_LogError(format, args...) 
#endif

#if MB_G_LOG && MB_G_LOG_INFO
#define MB_G_LogInfo(format, args...) MB_G_Log(format, ## args)
#else
#define MB_G_LogInfo(format, args...) 
#endif

#if MB_G_LOG && MB_G_LOG_CLASSLOAD
#define MB_G_LogClassLoad NSLog(@"Class Load: [%@]",NSStringFromClass(self))
#else
#define MB_G_LogClassLoad
#endif

#if NG_LOG_THREADS
#define NGLog(format, args...) if (NGConsoleLoggingEnabled) { NSLog(format" : %@", ## args, [NSThread currentThread]); }
#else
#define NGLog(format, args...) if (NGConsoleLoggingEnabled) { NSLog(format, ## args); }
#endif

#define NGLogFormat NGLog
#define NGLogDeprecated(formatCSTRING, args...) NGLog(@"Warning: [%@ %@] is deprecated. " formatCSTRING, NSStringFromClass([self class]), NSStringFromSelector(_cmd), ## args)

#endif

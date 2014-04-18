/**
 * MBGResult.h
 */
#import <Foundation/Foundation.h>

/*!
 * @abstract
 */
@interface MBGResult : NSObject {

	NSInteger _start;
	NSInteger _count;
	NSInteger _total;
}
/*!
 * @abstract
 */
@property (nonatomic, assign) NSInteger start;

/*!
 * @abstract
 */
@property (nonatomic, assign) NSInteger count;

/*!
 * @abstract
 */
@property (nonatomic, assign) NSInteger total;

+ (id)result;
- (id)initWithStart:(NSInteger)theStartIndex 
           andCount:(NSInteger)theCount 
           andTotal:(NSInteger)theTotal;


@end

#import "MB_WW_DataModel.h"
#import "MBScore.h"


@protocol MB_WW_Score <MBScore>
@property (atomic, readonly, strong) NSString *userId;
@property (atomic, readonly, assign) double scoreValue;
@property (atomic, readonly, strong) NSString *displayValue;
@property (atomic, readonly, assign) NSInteger rank;
@end

@interface MB_WW_Score : MB_WW_DataModel<MB_WW_Score>
@end

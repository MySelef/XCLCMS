SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_Ads_Update]
@AdsID bigint,
@Code varchar(50),
@AdsType char(3),
@Title nvarchar(200),
@Contents nvarchar(2000),
@AdWidth int,
@AdHeight int,
@URL varchar(500),
@URLOpenType char(3),
@StartTime datetime,
@EndTime datetime,
@NickName nvarchar(50),
@Email varchar(100),
@QQ varchar(50),
@Tel varchar(50),
@OtherContact nvarchar(500),
@Remark nvarchar(500),
@FK_MerchantID bigint,
@FK_MerchantAppID bigint,
@RecordState char(1),
@CreateTime datetime,
@CreaterID bigint,
@CreaterName nvarchar(50),
@UpdateTime datetime,
@UpdaterID bigint,
@UpdaterName nvarchar(50),

@ResultCode INT OUTPUT,
@ResultMessage NVARCHAR(1000) OUTPUT

 AS 
  BEGIN TRY
		UPDATE [Ads] SET 
		Code=@Code ,
		Title=@Title,
		FK_MerchantID=@FK_MerchantID ,
		[AdsType] = @AdsType,[Contents] = @Contents,[AdWidth] = @AdWidth,[AdHeight] = @AdHeight,[URL] = @URL,[URLOpenType] = @URLOpenType,[StartTime] = @StartTime,[EndTime] = @EndTime,[NickName] = @NickName,[Email] = @Email,[QQ] = @QQ,[Tel] = @Tel,[OtherContact] = @OtherContact,[Remark] = @Remark,[FK_MerchantAppID] = @FK_MerchantAppID,[RecordState] = @RecordState,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
		WHERE AdsID=@AdsID
		SET @ResultCode=1
END TRY
BEGIN CATCH
	SET @ResultMessage= ERROR_MESSAGE() 
	SET @ResultCode=0
END CATCH
GO

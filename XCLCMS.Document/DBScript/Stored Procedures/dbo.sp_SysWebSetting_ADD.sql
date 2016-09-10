
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO




CREATE PROCEDURE [dbo].[sp_SysWebSetting_ADD]
@SysWebSettingID bigint,
@KeyName varchar(100),
@KeyValue varchar(2000),
@TestKeyValue varchar(2000),
@UATKeyValue varchar(2000),
@PrdKeyValue varchar(2000),
@Remark varchar(1000),
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
BEGIN
 
	BEGIN TRY
		INSERT INTO [SysWebSetting](
		[SysWebSettingID],[KeyName],[KeyValue],[TestKeyValue],[UATKeyValue],[PrdKeyValue],[Remark],[FK_MerchantID],[FK_MerchantAppID],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
		)VALUES(
		@SysWebSettingID,@KeyName,@KeyValue,@TestKeyValue,@UATKeyValue,@PrdKeyValue,@Remark,@FK_MerchantID,@FK_MerchantAppID,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
		)

		SET @ResultCode=1
	END TRY 
	BEGIN CATCH
		SET @ResultMessage= ERROR_MESSAGE() 
		SET @ResultCode=0
	END CATCH 

END



GO

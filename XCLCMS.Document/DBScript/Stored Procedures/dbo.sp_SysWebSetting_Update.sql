
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



CREATE PROCEDURE [dbo].[sp_SysWebSetting_Update]
@SysWebSettingID bigint,
@KeyName varchar(100),
@KeyValue varchar(2000),
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
		UPDATE [SysWebSetting] SET 
		KeyName=@KeyName , FK_MerchantID=@FK_MerchantID, 
		[KeyValue] = @KeyValue,[Remark] = @Remark,[FK_MerchantAppID] = @FK_MerchantAppID,[RecordState] = @RecordState,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
		WHERE SysWebSettingID=@SysWebSettingID

		SET @ResultCode=1
	END TRY
	BEGIN CATCH
		SET @ResultMessage= ERROR_MESSAGE() 
		SET @ResultCode=0	
	END CATCH

END

 




GO

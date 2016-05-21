
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[sp_MerchantApp_ADD]
@MerchantAppID bigint,
@MerchantAppName varchar(100),
@FK_MerchantID bigint,
@ResourceVersion varchar(50),
@Email varchar(50),
@CopyRight varchar(2000),
@MetaDescription varchar(500),
@MetaKeyWords varchar(500),
@MetaTitle varchar(500),
@WebURL varchar(500),
@Remark varchar(1000),
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
			INSERT INTO [MerchantApp](
			[MerchantAppID],[MerchantAppName],[FK_MerchantID],[ResourceVersion],[Email],[CopyRight],[MetaDescription],[MetaKeyWords],[MetaTitle],[WebURL],[Remark],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
			)VALUES(
			@MerchantAppID,@MerchantAppName,@FK_MerchantID,@ResourceVersion,@Email,@CopyRight,@MetaDescription,@MetaKeyWords,@MetaTitle,@WebURL,@Remark,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
			)

			SET @ResultCode=1
	END TRY
	BEGIN CATCH
			SET @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0
	END CATCH
GO

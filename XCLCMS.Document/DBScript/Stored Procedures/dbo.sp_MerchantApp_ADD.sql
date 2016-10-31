
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE PROCEDURE [dbo].[sp_MerchantApp_ADD]
@MerchantAppID BIGINT,
@MerchantAppName VARCHAR(100),
@FK_MerchantID BIGINT,
@AppKey VARCHAR(50),
@ResourceVersion VARCHAR(50),
@Email VARCHAR(50),
@CopyRight VARCHAR(2000),
@MetaDescription VARCHAR(500),
@MetaKeyWords VARCHAR(500),
@MetaTitle VARCHAR(500),
@WebURL VARCHAR(500),
@Remark VARCHAR(1000),
@RecordState CHAR(1),
@CreateTime DATETIME,
@CreaterID BIGINT,
@CreaterName NVARCHAR(50),
@UpdateTime DATETIME,
@UpdaterID BIGINT,
@UpdaterName NVARCHAR(50),

@ResultCode INT OUTPUT,
@ResultMessage NVARCHAR(1000) OUTPUT

 AS 
 	BEGIN TRY
			INSERT INTO [MerchantApp](
			[MerchantAppID],[MerchantAppName],[FK_MerchantID],[AppKey],[ResourceVersion],[Email],[CopyRight],[MetaDescription],[MetaKeyWords],[MetaTitle],[WebURL],[Remark],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
			)VALUES(
			@MerchantAppID,@MerchantAppName,@FK_MerchantID,@AppKey, @ResourceVersion,@Email,@CopyRight,@MetaDescription,@MetaKeyWords,@MetaTitle,@WebURL,@Remark,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
			)

			SET @ResultCode=1
	END TRY
	BEGIN CATCH
			SET @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0
	END CATCH

GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[sp_FriendLinks_ADD]
@FriendLinkID BIGINT,
@Title NVARCHAR(200),
@Description NVARCHAR(2000),
@URL VARCHAR(500),
@ContactName NVARCHAR(50),
@Email VARCHAR(100),
@QQ VARCHAR(50),
@Tel VARCHAR(50),
@Remark NVARCHAR(500),
@OtherContact NVARCHAR(500),
@FK_MerchantID BIGINT,
@FK_MerchantAppID BIGINT,
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
		INSERT INTO [FriendLinks](
		[FriendLinkID],[Title],[Description],[URL],[ContactName],[Email],[QQ],[Tel],[Remark],[OtherContact],[FK_MerchantID],[FK_MerchantAppID],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
		)VALUES(
		@FriendLinkID,@Title,@Description,@URL,@ContactName,@Email,@QQ,@Tel,@Remark,@OtherContact,@FK_MerchantID,@FK_MerchantAppID,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
		)
		SET @ResultCode=1
END TRY
BEGIN CATCH
	SET @ResultMessage= ERROR_MESSAGE() 
	SET @ResultCode=0
END CATCH

GO

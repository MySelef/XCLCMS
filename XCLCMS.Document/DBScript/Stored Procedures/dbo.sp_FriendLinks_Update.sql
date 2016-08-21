SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[sp_FriendLinks_Update]
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

		UPDATE [FriendLinks] SET 
		Title=@Title ,
		FK_MerchantID=@FK_MerchantID ,
		[Description] = @Description,[URL] = @URL,[ContactName] = @ContactName,[Email] = @Email,[QQ] = @QQ,[Tel] = @Tel,[Remark] = @Remark,[OtherContact] = @OtherContact,[FK_MerchantAppID] = @FK_MerchantAppID,[RecordState] = @RecordState,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
		WHERE FriendLinkID=@FriendLinkID

		SET @ResultCode=1
END TRY
BEGIN CATCH
	SET @ResultMessage= ERROR_MESSAGE() 
	SET @ResultCode=0
END CATCH

GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



CREATE PROC [dbo].[sp_Merchant_Del] (
@MerchantID TVP_IDTable READONLY,
@Context TVP_Context READONLY,

@ResultCode INT OUTPUT,
@ResultMessage NVARCHAR(1000) OUTPUT
) AS 
BEGIN

	BEGIN TRAN trans

	BEGIN TRY


			DECLARE @UserInfoID BIGINT
			DECLARE @UserName VARCHAR(50)
			SELECT @UserInfoID=UserInfoID,@UserName=UserName FROM @Context


			--删除字典表
			UPDATE dbo.SysDic 
			SET RecordState='R' ,
			UpdateTime=GETDATE(),
			UpdaterName=@UserName,
			UpdaterID=@UserInfoID
			FROM dbo.SysDic AS a
			INNER JOIN @MerchantID AS b ON a.FK_MerchantID=b.ID


			--删除角色表
			UPDATE dbo.SysRole
			SET RecordState='R',
			UpdateTime=GETDATE(),
			UpdaterID=@UserInfoID,
			UpdaterName=@UserName
			FROM dbo.SysRole AS a
			INNER JOIN @MerchantID AS b ON a.FK_MerchantID=b.ID

			--删除系统配置表
			UPDATE dbo.SysWebSetting 
			SET RecordState='R',
			UpdateTime=GETDATE(),
			UpdaterID=@UserInfoID,
			UpdaterName=@UserName
			FROM dbo.SysWebSetting AS a
			INNER JOIN @MerchantID AS b ON a.FK_MerchantID=b.ID

			--删除文章表
			UPDATE dbo.Article
			SET RecordState='R',
			UpdateTime=GETDATE(),
			UpdaterID=@UserInfoID,
			UpdaterName=@UserName
			FROM dbo.Article AS a
			INNER JOIN @MerchantID AS b ON a.FK_MerchantID=b.ID

			--删除用户表
			UPDATE dbo.UserInfo 
			SET RecordState='R',
			UpdateTime=GETDATE(),
			UpdaterID=@UserInfoID,
			UpdaterName=@UserName
			FROM dbo.UserInfo AS a
			INNER JOIN @MerchantID AS b ON a.FK_MerchantID=b.ID


			--删除商户应用信息
			UPDATE dbo.MerchantApp
			SET RecordState='R',
			UpdateTime=GETDATE(),
			UpdaterName=@UserName,
			UpdaterID=@UserInfoID
			FROM dbo.MerchantApp AS a
			INNER JOIN @MerchantID AS b ON a.FK_MerchantID=b.ID


			--删除商户基础信息
			UPDATE dbo.Merchant
			SET RecordState='R',
			MerchantState='N',
			UpdateTime=GETDATE(),
			UpdaterID=@UserInfoID,
			UpdaterName=@UserName
			FROM dbo.Merchant AS a
			INNER JOIN @MerchantID AS b ON a.MerchantID=b.ID

		SET @ResultCode=1
		COMMIT TRAN trans
	END TRY
	BEGIN CATCH
		SET @ResultMessage= ERROR_MESSAGE() 
		SET @ResultCode=0
		ROLLBACK TRAN trans
	END CATCH


END


GO

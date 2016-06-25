
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO














/*****更新用户基本信息*****/  
CREATE PROCEDURE [dbo].[sp_UserInfo_Update]
@UserInfoID bigint,
@UserName varchar(50),
@FK_MerchantID bigint,
@FK_MerchantAppID bigint,
@RealName nvarchar(50),
@NickName nvarchar(50),
@Pwd varchar(50),
@Age int,
@SexType char(1),
@Birthday datetime,
@Tel varchar(50),
@QQ varchar(50),
@Email varchar(100),
@OtherContact nvarchar(500),
@AccessType varchar(50),
@AccessToken varchar(100),
@UserState char(1),
@Remark nvarchar(1000),
@RoleName nvarchar(100),
@RoleMaxWeight int,
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
	UPDATE [UserInfo] SET 
	UserName=@UserName , FK_MerchantID=@FK_MerchantID , RealName=@RealName , NickName=@NickName ,
	[FK_MerchantAppID] = @FK_MerchantAppID,[Pwd] = @Pwd,[Age] = @Age,[SexType] = @SexType,[Birthday] = @Birthday,[Tel] = @Tel,[QQ] = @QQ,[Email] = @Email,[OtherContact] = @OtherContact,[AccessType] = @AccessType,[AccessToken] = @AccessToken,[UserState] = @UserState,[Remark] = @Remark,[RoleName] = @RoleName,[RoleMaxWeight] = @RoleMaxWeight,[RecordState] = @RecordState,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
	WHERE UserInfoID=@UserInfoID

	
		SET @ResultCode=1
	END TRY
	BEGIN CATCH
		SET @ResultMessage= ERROR_MESSAGE() 
		SET @ResultCode=0	
	END CATCH

END





GO

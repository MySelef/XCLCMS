SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO





/*****添加用户基本信息*****/ 
CREATE PROCEDURE [dbo].[sp_UserInfo_ADD]
@UserInfoID bigint,
@UserName varchar(50),
@FK_MerchantID bigint,
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
		INSERT INTO [UserInfo](
		[UserInfoID],[UserName],[FK_MerchantID],[RealName],[NickName],[Pwd],[Age],[SexType],[Birthday],[Tel],[QQ],[Email],[OtherContact],[AccessType],[AccessToken],[UserState],[Remark],[RoleName],[RoleMaxWeight],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
		)VALUES(
		@UserInfoID,@UserName,@FK_MerchantID,@RealName,@NickName,@Pwd,@Age,@SexType,@Birthday,@Tel,@QQ,@Email,@OtherContact,@AccessType,@AccessToken,@UserState,@Remark,@RoleName,@RoleMaxWeight,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
		)
		SET @ResultCode=1
	END TRY
	BEGIN CATCH
			set @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0
	END CATCH
	

END





GO

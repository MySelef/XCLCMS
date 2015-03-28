USE [XCLCMS]
GO
/****** Object:  StoredProcedure [dbo].[UserInfo_Update]    Script Date: 03/21/2015 10:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserInfo_Update]
@UserInfoID bigint,
@UserName varchar(50),
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
@RoleName NVARCHAR(100),
@RoleMaxWeight INT,
@RecordState char(1),
@CreateTime datetime,
@CreaterID bigint,
@CreaterName nvarchar(50),
@UpdateTime datetime,
@UpdaterID bigint,
@UpdaterName nvarchar(50),

@UserRoleIDXML XML=NULL,
@WithMoreState INT=1
 AS 

/**存储过程功能：更新用户信息或包含其它附加信息
	一、@WithMoreState字段说明：
			按位操作，具体项如下：
			...
			1=预留
			1=预留
			1=预留
			...			
			1=更新角色信息
			1=更新用户基本信息
			示例：
			a:包含更新用户基本信息，则为（@WithMoreState & 1=1）
			b:包含更新角色信息，则为（@WithMoreState & 2=2）
*/

IF(@WithMoreState&2=2)
BEGIN
	/*****更新角色信息*****/
	DELETE dbo.SysUserRole WHERE FK_UserInfoID=@UserInfoID	
	IF(@UserRoleIDXML IS NOT NULL)
	BEGIN
			--检查当前用户最大权力,筛选中当前要添加的权力中小于等于当前创建用户的最大权力记录
			DECLARE @maxWeight BIGINT=NULL
			SELECT @maxWeight=RoleMaxWeight FROM dbo.UserInfo WHERE UserInfoID=@UpdaterID
			;WITH UserRoleId_Info1 AS (
				SELECT 
				T.C.value('text()[1]','bigint') AS FK_SysRoleID
				FROM @UserRoleIDXML.nodes('//long') AS T(C)
			)
			--添加角色
			INSERT INTO dbo.SysUserRole
					( FK_UserInfoID ,
					  FK_SysRoleID ,
					  RecordState ,
					  CreateTime ,
					  CreaterID ,
					  CreaterName ,
					  UpdateTime ,
					  UpdaterID ,
					  UpdaterName
					)
				SELECT
				@UserInfoID AS FK_UserInfoID,
				a.FK_SysRoleID,
				'N' AS RecordState,
				@CreateTime AS CreateTime,
				@CreaterID AS CreaterID,
				@CreaterName AS CreaterName,
				@UpdateTime AS UpdateTime,
				@UpdaterID AS UpdaterID,
				@UpdaterName	 AS UpdaterName					
				FROM UserRoleId_Info1 AS a
				INNER JOIN dbo.v_SysDic_Roles AS b ON a.FK_SysRoleID=b.SysDicID AND @maxWeight IS NOT NULL AND b.[Weight]<=@maxWeight
	END

	--更新RoleName字段（拼接角色名为字符串）
	CREATE TABLE #UserRole_Temp1(RoleName nvarchar(100))
	;WITH UserInfo_Roles AS (
		SELECT
		b.DicName
		FROM dbo.SysUserRole AS a
		INNER JOIN dbo.v_SysDic_Roles AS b ON a.FK_UserInfoID=@UserInfoID AND a.RecordState='N' AND a.FK_SysRoleID=b.SysDicID
	)
	INSERT INTO #UserRole_Temp1 SELECT * FROM UserInfo_Roles

	SET @RoleName=(SELECT a.RoleName+',' FROM #UserRole_Temp1 AS a FOR XML PATH(''))
	IF(@RoleName IS NOT NULL AND LEN(@RoleName)>0)
	BEGIN
		set @RoleName=LEFT(@RoleName,LEN(@RoleName)-1)
	END
	DROP TABLE #UserRole_Temp1

	--更新@RoleMaxWeight字段
	SELECT
	@RoleMaxWeight=MAX(b.Weight)
	FROM dbo.SysUserRole AS a
	INNER JOIN dbo.v_SysDic_Roles AS b ON a.FK_UserInfoID=@UserInfoID AND a.RecordState='N' AND a.FK_SysRoleID=b.SysDicID
END


IF(@WithMoreState & 1=1)
BEGIN
	/*****更新用户基本信息*****/  
	UPDATE dbo.UserInfo SET
	UserName=@UserName ,
	RealName =@RealName,
	NickName =@NickName,
	Pwd =@Pwd,
	Age =@Age,
	SexType =@SexType,
	Birthday =@Birthday,
	Tel =@Tel,
	QQ =@QQ,
	Email =@Email,
	OtherContact =@OtherContact,
	AccessType =@AccessType,
	AccessToken =@AccessToken,
	UserState =@UserState,
	Remark =@Remark,
	RoleName=@RoleName,
	RoleMaxWeight=@RoleMaxWeight,
	RecordState =@RecordState,
	CreateTime =@CreateTime,
	CreaterID =@CreaterID,
	CreaterName=@CreaterName,
	UpdateTime =@UpdateTime,
	UpdaterID =@UpdaterID,
	UpdaterName =@UpdaterName
	WHERE UserInfoID=@UserInfoID


END
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO






/**
* 刷新用户表中的角色信息
*/
CREATE PROC [dbo].[sp_SysRole_RefreshUserRoleInfo](
	@UserInfoID BIGINT=NULL--用户ID，如果未指定，则更新所有用户表，否则，只更新该用户
) AS 
BEGIN

	--创建对应的临时表
	CREATE TABLE #UserRoleInfo_Temp
	(
		FK_UserInfoID BIGINT,
		SysRoleID BIGINT,
		NodeLevel INT,
		RoleName NVARCHAR(50)
	)

	--用户对应的角色信息(#UserRoleInfo_Temp)
	IF(@UserInfoID>0)
	BEGIN
		
		INSERT INTO #UserRoleInfo_Temp
		SELECT
		a.FK_UserInfoID,
		b.SysRoleID,
		b.NodeLevel,
		b.RoleName
		FROM dbo.SysUserRole AS a
		INNER JOIN dbo.v_SysRole AS b ON a.RecordState='N' AND a.FK_SysRoleID=b.SysRoleID	
		WHERE a.FK_UserInfoID=@UserInfoID
	
	END
	ELSE 
	BEGIN
	
		INSERT INTO #UserRoleInfo_Temp
		SELECT
		a.FK_UserInfoID,
		b.SysRoleID,
		b.NodeLevel,
		b.RoleName
		FROM dbo.SysUserRole AS a
		INNER JOIN dbo.v_SysRole AS b ON a.RecordState='N' AND a.FK_SysRoleID=b.SysRoleID	
	
	END

	--用户对应的角色名(#UserRoleNameInfo_Temp)
	;WITH UserRoleNameInfo AS (
		SELECT
		a.FK_UserInfoID,
		(
			SELECT ISNULL(b.RoleName,'') +',' FROM #UserRoleInfo_Temp AS b WHERE b.FK_UserInfoID=a.FK_UserInfoID FOR XML PATH('')
		) AS RoleNameString
		FROM #UserRoleInfo_Temp AS a GROUP BY a.FK_UserInfoID
	)
	SELECT
	a.FK_UserInfoID,
	SUBSTRING(a.RoleNameString,1,LEN(a.RoleNameString)-1) AS RoleNames
	INTO #UserRoleNameInfo_Temp
	FROM UserRoleNameInfo AS a


	--更新用户信息
	IF(@UserInfoID>0)
	BEGIN
	
		UPDATE dbo.UserInfo SET RoleName=b.RoleNames FROM dbo.UserInfo AS a
		LEFT JOIN #UserRoleNameInfo_Temp AS b ON a.UserInfoID=b.FK_UserInfoID
		WHERE a.UserInfoID=@UserInfoID
	
	END 
	ELSE
	BEGIN
	
		UPDATE dbo.UserInfo SET RoleName=b.RoleNames FROM dbo.UserInfo AS a
		LEFT JOIN #UserRoleNameInfo_Temp AS b ON a.UserInfoID=b.FK_UserInfoID
	
	END

	--删除临时表
	DROP TABLE #UserRoleInfo_Temp
	DROP TABLE #UserRoleNameInfo_Temp

END




GO

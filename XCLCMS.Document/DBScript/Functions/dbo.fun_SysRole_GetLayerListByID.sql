
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO





CREATE FUNCTION [dbo].[fun_SysRole_GetLayerListByID](@sysRoleID BIGINT) RETURNS TABLE AS RETURN
--获取当前角色的所在层级路径名
--如:根目录/子目录/文件

WITH Info1 AS (
	SELECT SysRoleID, ParentID, RoleName FROM dbo.SysRole  WITH(NOLOCK) WHERE SysRoleID=@sysRoleID
	UNION ALL
	SELECT a.SysRoleID, a.ParentID,a.RoleName FROM dbo.SysRole AS a  WITH(NOLOCK) 
	INNER JOIN Info1 AS b ON a.SysRoleID=b.ParentID
)
SELECT SysRoleID, ParentID,RoleName FROM Info1





GO


SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

--清理无效的普通商户角色的无效权限
CREATE PROC [dbo].[sp_ClearInvalidNormalRoleFunctions] AS 

BEGIN


;WITH NormalFunctionID AS (
	--普通商户功能id
	SELECT DISTINCT a.FK_SysFunctionID FROM dbo.SysRoleFunction AS a  WITH(NOLOCK) 
	INNER JOIN dbo.SysRole AS b WITH(NOLOCK)  ON a.FK_SysRoleID=b.SysRoleID
	WHERE b.Code='MerchantMainRole'
)
--删除普通商户角色中不在普通商户功能id中的【角色功能对应关系】
DELETE SysRoleFunction FROM SysRoleFunction AS a
INNER JOIN dbo.SysRole AS b ON a.FK_SysRoleID=b.SysRoleID
INNER JOIN dbo.Merchant AS c ON b.FK_MerchantID=c.MerchantID
LEFT JOIN NormalFunctionID AS d ON a.FK_SysFunctionID=d.FK_SysFunctionID
WHERE c.MerchantSystemType='NOR' AND d.FK_SysFunctionID IS NULL


END




GO

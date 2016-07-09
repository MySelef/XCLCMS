
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO







CREATE VIEW [dbo].[v_SysRole] AS

 WITH Info1 AS 
 ( 
	 SELECT *,1 AS NodeLevel FROM dbo.SysRole  WITH(NOLOCK) WHERE ParentID=0--根节点
	 UNION ALL
	 SELECT a.*,NodeLevel+1 AS NodeLevel FROM dbo.SysRole AS a WITH(NOLOCK) 
	 INNER JOIN Info1 AS b ON a.ParentID=b.SysRoleID
	 WHERE a.RecordState='N'
 )
SELECT
a.*,
(
	CASE WHEN EXISTS (SELECT TOP 1 1 FROM dbo.SysRole AS b  WITH(NOLOCK)  WHERE b.ParentID=a.SysRoleID AND b.RecordState='N') THEN 0 ELSE 1 END
) AS IsLeaf,
(CASE WHEN a.ParentID=0 THEN 1 ELSE 0 END) AS IsRoot,
b.MerchantName,
b.MerchantSystemType
FROM Info1 AS a
LEFT JOIN dbo.Merchant AS b  WITH(NOLOCK) ON a.FK_MerchantID=b.MerchantID






GO

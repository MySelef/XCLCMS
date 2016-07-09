
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO








CREATE VIEW [dbo].[v_SysFunction] AS

 WITH Info1 AS 
 ( 
	 SELECT *,1 AS NodeLevel FROM dbo.SysFunction WITH(NOLOCK)  WHERE ParentID=0--根节点
	 UNION ALL
	 SELECT a.*,NodeLevel+1 AS NodeLevel FROM dbo.SysFunction AS a WITH(NOLOCK) 
	 INNER JOIN Info1 AS b ON a.ParentID=b.SysFunctionID
	 WHERE a.RecordState='N'
 )
SELECT
*,
(
	CASE WHEN EXISTS (SELECT TOP 1 1 FROM dbo.SysFunction AS b   WITH(NOLOCK) WHERE b.ParentID=a.SysFunctionID AND b.RecordState='N') THEN 0 ELSE 1 END
) AS IsLeaf,
(CASE WHEN a.ParentID=0 THEN 1 ELSE 0 END) AS IsRoot
FROM Info1 AS a







GO

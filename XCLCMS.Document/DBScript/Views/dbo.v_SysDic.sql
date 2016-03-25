SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO




CREATE VIEW [dbo].[v_SysDic] AS 


 with Info1 as 
 ( 
	 SELECT *,1 AS NodeLevel from dbo.SysDic WHERE ParentID=0--根节点
	 UNION ALL
	 SELECT a.*,NodeLevel+1 AS NodeLevel FROM dbo.SysDic AS a
	 INNER JOIN Info1 AS b ON a.ParentID=b.SysDicID
	 WHERE a.RecordState='N'
 )
SELECT
*,
(
	CASE WHEN EXISTS (SELECT TOP 1 1 FROM dbo.SysDic AS b  WHERE b.ParentID=a.SysDicID AND b.RecordState='N') THEN 0 ELSE 1 END
) AS IsLeaf
FROM Info1 AS a





GO


SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO






CREATE VIEW [dbo].[v_SysDic] AS 


 WITH Info1 AS 
 ( 
	 SELECT *,1 AS NodeLevel FROM dbo.SysDic WHERE ParentID=0--根节点
	 UNION ALL
	 SELECT a.*,NodeLevel+1 AS NodeLevel FROM dbo.SysDic AS a
	 INNER JOIN Info1 AS b ON a.ParentID=b.SysDicID
	 WHERE a.RecordState='N'
 )
SELECT
a.*,
(
	CASE WHEN EXISTS (SELECT TOP 1 1 FROM dbo.SysDic AS b  WHERE b.ParentID=a.SysDicID AND b.RecordState='N') THEN 0 ELSE 1 END
) AS IsLeaf,
(CASE WHEN a.ParentID=0 THEN 1 ELSE 0 END) AS IsRoot,
b.MerchantName
FROM Info1 AS a
LEFT JOIN dbo.Merchant AS b ON a.FK_MerchantID=b.MerchantID







GO

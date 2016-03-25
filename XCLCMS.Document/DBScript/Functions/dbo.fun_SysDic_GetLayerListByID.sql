SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE FUNCTION [dbo].[fun_SysDic_GetLayerListByID](@sysDicID BIGINT) RETURNS TABLE AS RETURN
--获取当前字典节点的所在层级路径名
--如:根目录/子目录/文件

WITH Info1 AS (
	SELECT SysDicID, ParentID,DicName FROM dbo.SysDic WHERE SysDicID=@sysDicID
	UNION ALL
	SELECT a.SysDicID, a.ParentID,a.DicName FROM dbo.SysDic AS a 
	INNER JOIN Info1 AS b ON a.SysDicID=b.ParentID
)
SELECT SysDicID, ParentID,DicName FROM Info1

GO

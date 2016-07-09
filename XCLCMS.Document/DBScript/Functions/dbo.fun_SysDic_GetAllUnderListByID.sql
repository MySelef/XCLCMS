
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



CREATE FUNCTION [dbo].[fun_SysDic_GetAllUnderListByID](@SysDicID BIGINT) RETURNS TABLE AS RETURN
--递归获取指定SysDicID下的所有列表（不包含该SysDicID的记录）
WITH Info1 AS (
	SELECT * FROM dbo.v_SysDic  WITH(NOLOCK) WHERE RecordState='N' AND ParentID=(
		SELECT SysDicID FROM dbo.SysDic  WITH(NOLOCK) WHERE SysDicID=@SysDicID
	)
),Info2 AS (
	SELECT * FROM Info1
	UNION ALL
	SELECT a.* FROM dbo.v_SysDic AS a WITH(NOLOCK) 
	INNER JOIN Info2 AS b ON a.ParentID=b.SysDicID AND a.RecordState='N'
)
SELECT * FROM Info2




GO

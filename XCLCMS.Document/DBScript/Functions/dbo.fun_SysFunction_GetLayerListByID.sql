SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO




CREATE FUNCTION [dbo].[fun_SysFunction_GetLayerListByID](@sysFunctionID BIGINT) RETURNS TABLE AS RETURN
--获取当前系统功能的所在层级路径名
--如:根目录/子目录/文件

WITH Info1 AS (
	SELECT SysFunctionID, ParentID, FunctionName FROM dbo.SysFunction WHERE SysFunctionID=@sysFunctionID
	UNION ALL
	SELECT a.SysFunctionID, a.ParentID,a.FunctionName FROM dbo.SysFunction AS a 
	INNER JOIN Info1 AS b ON a.SysFunctionID=b.ParentID
)
SELECT SysFunctionID, ParentID,FunctionName FROM Info1
GO

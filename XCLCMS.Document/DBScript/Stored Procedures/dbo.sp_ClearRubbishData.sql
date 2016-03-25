SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO







CREATE PROC [dbo].[sp_ClearRubbishData] AS
BEGIN

	--清理垃圾数据
	--包括：已被删除的数据

	/*****************SysDic*****************/
	CREATE TABLE #SysDic_Temp1(SysDicID BIGINT)
	WHILE 1=1
	BEGIN
		--删除父id不存在的记录（除根节点外）
		TRUNCATE TABLE #SysDic_Temp1
		DELETE FROM dbo.SysDic WHERE RecordState<>'N'
		;WITH SysDic_Info1 AS (
			SELECT
			a.SysDicID
			FROM dbo.SysDic AS a
			LEFT JOIN dbo.SysDic AS b ON a.ParentID=b.SysDicID
			WHERE a.ParentID<>0 AND b.SysDicID IS NULL
		)
		INSERT INTO #SysDic_Temp1 SELECT SysDicID FROM SysDic_Info1
		IF EXISTS (SELECT TOP 1 1 FROM #SysDic_Temp1)
		BEGIN 
			DELETE FROM dbo.SysDic FROM dbo.SysDic AS a
			INNER JOIN #SysDic_Temp1 AS b ON a.SysDicID=b.SysDicID
		END
		ELSE 
		BEGIN 
			BREAK;
		END
		
	END
	
	DROP TABLE #SysDic_Temp1
	
	/*****************SysWebSetting*****************/
	DELETE FROM dbo.SysWebSetting WHERE RecordState<>'N'
	
	/*****************UserInfo*****************/
	DELETE FROM dbo.UserInfo WHERE RecordState='D'
	
	/*****************SysUserRole*****************/
	DELETE FROM dbo.SysUserRole FROM dbo.SysUserRole AS a
	LEFT JOIN dbo.UserInfo AS b ON a.FK_UserInfoID=b.UserInfoID
	WHERE b.UserInfoID IS NULL OR a.RecordState<>'N'
	
	/*****************SysFunction*****************/
	DELETE FROM dbo.SysFunction WHERE RecordState<>'N'

END








GO

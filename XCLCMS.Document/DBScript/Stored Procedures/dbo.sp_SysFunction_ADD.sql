SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO




CREATE PROCEDURE [dbo].[sp_SysFunction_ADD]
@SysFunctionID bigint,
@ParentID bigint,
@FunctionName varchar(100),
@Code varchar(50),
@Remark nvarchar(500),
@RecordState char(1),
@CreateTime datetime,
@CreaterID bigint,
@CreaterName nvarchar(50),
@UpdateTime datetime,
@UpdaterID bigint,
@UpdaterName nvarchar(50),

@ResultCode INT OUTPUT,
@ResultMessage NVARCHAR(1000) OUTPUT

 AS 
BEGIN
 
	BEGIN TRY
		INSERT INTO [SysFunction](
		[SysFunctionID],[ParentID],[FunctionName],[Code],[Remark],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
		)VALUES(
		@SysFunctionID,@ParentID,@FunctionName,@Code,@Remark,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
		)
		SET @ResultCode=1
	END TRY
	BEGIN CATCH
		set @ResultMessage= ERROR_MESSAGE() 
		SET @ResultCode=0
	END CATCH
	
END




GO

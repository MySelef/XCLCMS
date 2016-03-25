SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO




CREATE PROCEDURE [dbo].[sp_SysFunction_Update]
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
	
	UPDATE [SysFunction] SET 
	FunctionName=@FunctionName , Code=@Code , RecordState=@RecordState ,
	[ParentID] = @ParentID,[Remark] = @Remark,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
	WHERE SysFunctionID=@SysFunctionID  
		
		SET @ResultCode=1
	END TRY
	BEGIN CATCH
			set @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0
	END CATCH
END



GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO







CREATE PROCEDURE [dbo].[sp_SysDic_ADD]
@SysDicID bigint,
@Code varchar(50),
@DicType char(1),
@ParentID bigint,
@DicName varchar(200),
@DicValue varchar(1000),
@Sort int,
@Remark VARCHAR(1000),
@FK_FunctionID BIGINT,
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
			INSERT INTO [SysDic](
			[SysDicID],[Code],[DicType],[ParentID],[DicName],[DicValue],[Sort],[Remark],[FK_FunctionID],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
			)VALUES(
			@SysDicID,@Code,@DicType,@ParentID,@DicName,@DicValue,@Sort,@Remark,@FK_FunctionID,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
			)			
			SET @ResultCode=1
		END TRY
		BEGIN CATCH
			set @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0		
		END CATCH
	

	END






GO

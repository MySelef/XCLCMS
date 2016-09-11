SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE PROCEDURE [dbo].[sp_ObjectTag_ADD]
@ObjectType char(3),
@FK_ObjectID bigint,
@FK_TagsID bigint,
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


	  BEGIN TRY
		INSERT INTO [ObjectTag](
		[ObjectType],[FK_ObjectID],[FK_TagsID],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
		)VALUES(
		@ObjectType,@FK_ObjectID,@FK_TagsID,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
		)
		SET @ResultCode=1
END TRY
BEGIN CATCH
	SET @ResultMessage= ERROR_MESSAGE() 
	SET @ResultCode=0
END CATCH
GO

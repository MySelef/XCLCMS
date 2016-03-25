SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO







CREATE PROCEDURE [dbo].[sp_SysDic_Update]
    @SysDicID BIGINT ,
    @Code VARCHAR(50) ,
    @DicType CHAR(1) ,
    @ParentID BIGINT ,
    @DicName VARCHAR(200) ,
    @DicValue VARCHAR(1000) ,
    @Sort INT ,
    @Remark VARCHAR(1000), 
   @FK_FunctionID BIGINT, 
    @RecordState CHAR(1) ,
    @CreateTime DATETIME ,
    @CreaterID BIGINT ,
    @CreaterName NVARCHAR(50) ,
    @UpdateTime DATETIME ,
    @UpdaterID BIGINT ,
    @UpdaterName NVARCHAR(50),
   
	@ResultCode INT OUTPUT,
	@ResultMessage NVARCHAR(1000) OUTPUT
AS

	BEGIN
	
		BEGIN TRY 
			UPDATE  [SysDic]
			SET     [ParentID] = @ParentID ,
					[DicValue] = @DicValue ,
					[Sort] = @Sort ,
					[Remark]=@Remark,
					[FK_FunctionID]=@FK_FunctionID,
					[CreateTime] = @CreateTime ,
					[CreaterID] = @CreaterID ,
					[CreaterName] = @CreaterName ,
					[UpdateTime] = @UpdateTime ,
					[UpdaterID] = @UpdaterID ,
					[UpdaterName] = @UpdaterName ,
					Code = @Code ,
					DicType = @DicType ,
					DicName = @DicName ,
					RecordState = @RecordState
			WHERE   SysDicID = @SysDicID		
			
			SET @ResultCode=1
		END TRY
		BEGIN CATCH
			set @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0				
		END CATCH
	

	END








GO

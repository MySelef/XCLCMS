USE [XCLCMS]
GO
/****** Object:  StoredProcedure [dbo].[SysDic_Update]    Script Date: 03/21/2015 10:00:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SysDic_Update]
    @SysDicID BIGINT ,
    @Code VARCHAR(50) ,
    @DicType CHAR(1) ,
    @ParentID BIGINT ,
    @DicName VARCHAR(200) ,
    @DicValue VARCHAR(1000) ,
    @Sort INT ,
    @Weight INT, 
    @Remark VARCHAR(1000), 
   @FK_FunctionID BIGINT, 
    @RecordState CHAR(1) ,
    @CreateTime DATETIME ,
    @CreaterID BIGINT ,
    @CreaterName NVARCHAR(50) ,
    @UpdateTime DATETIME ,
    @UpdaterID BIGINT ,
    @UpdaterName NVARCHAR(50),
   
	@RoleFunctionXML XML=NULL,
	@WithMoreState INT=1    
AS

/**存储过程功能：更新字典库信息或包含其它附加信息
	一、@WithMoreState字段说明：
			按位操作，具体项如下：
			...
			1=预留
			1=预留
			1=预留
			...			
			1=更新角色的功能信息
			1=更新字典库基本信息
			示例：
			a:包含更新字典库基本信息，则为（@WithMoreState & 1=1）
			b:包含更新角色的功能信息，则为（@WithMoreState & 2=2）
*/

	IF(@WithMoreState & 2=2)
	BEGIN
		/*****更新角色的功能信息*****/
			--删除角色的功能
			DELETE FROM dbo.SysRoleFunction WHERE FK_SysRoleID=@SysDicID
			IF(@RoleFunctionXML IS NOT NULL)
			BEGIN
				;WITH FunctionId_Info1 AS (
					SELECT 
					T.C.value('text()[1]','bigint') AS functionID
					FROM @RoleFunctionXML.nodes('//long') AS T(C)
				)
				INSERT INTO dbo.SysRoleFunction
						( FK_SysRoleID ,
						  FK_SysFunctionID ,
						  RecordState ,
						  CreateTime ,
						  CreaterID ,
						  CreaterName ,
						  UpdateTime ,
						  UpdaterID ,
						  UpdaterName
						)
				SELECT
				@SysDicID,
				a.functionID,
				'N',
				@CreateTime,
				@CreaterID,
				@CreaterName,
				@UpdateTime ,
				@UpdaterID ,
				@UpdaterName
				FROM FunctionId_Info1 AS a
			END
	END

	IF(@WithMoreState & 1=1)
	BEGIN
		/****更新字典库基本信息****/
		UPDATE  [SysDic]
		SET     [ParentID] = @ParentID ,
				[DicValue] = @DicValue ,
				[Sort] = @Sort ,
				[Weight]=@Weight,
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
	END
GO

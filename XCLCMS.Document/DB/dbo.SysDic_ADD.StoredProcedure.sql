USE [XCLCMS]
GO
/****** Object:  StoredProcedure [dbo].[SysDic_ADD]    Script Date: 03/21/2015 10:00:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SysDic_ADD]
@SysDicID bigint,
@Code varchar(50),
@DicType char(1),
@ParentID bigint,
@DicName varchar(200),
@DicValue varchar(1000),
@Sort int,
@Weight int,
@Remark VARCHAR(1000),
@FK_FunctionID BIGINT,
@RecordState char(1),
@CreateTime datetime,
@CreaterID bigint,
@CreaterName nvarchar(50),
@UpdateTime datetime,
@UpdaterID bigint,
@UpdaterName nvarchar(50),

@RoleFunctionXML XML=NULL,
@WithMoreState INT=1

 AS 

/**存储过程功能：增加字典库信息或包含其它附加信息
	一、@WithMoreState字段说明：
			按位操作，具体项如下：
			...
			1=预留
			1=预留
			1=预留
			...			
			1=添加角色的功能信息
			1=添加字典库基本信息
			示例：
			a:包含添加字典库基本信息，则为（@WithMoreState & 1=1）
			b:包含添加角色的功能信息，则为（@WithMoreState & 2=2）
*/

	IF(@WithMoreState & 2=2)
	BEGIN
		/****添加角色的功能信息****/
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
		/****添加字典库基本信息****/
		INSERT INTO [SysDic](
		[SysDicID],[Code],[DicType],[ParentID],[DicName],[DicValue],[Sort],[Weight],[Remark],[FK_FunctionID],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
		)VALUES(
		@SysDicID,@Code,@DicType,@ParentID,@DicName,@DicValue,@Sort,@Weight,@Remark,@FK_FunctionID,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
		)	
	END
GO

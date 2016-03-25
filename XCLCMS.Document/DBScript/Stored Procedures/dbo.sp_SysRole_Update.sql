SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE PROCEDURE [dbo].[sp_SysRole_Update]
@SysRoleID bigint,
@ParentID bigint,
@RoleName nvarchar(50),
@Code varchar(50),
@Sort int,
@Weight int,
@Remark varchar(1000),
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

	BEGIN TRAN trans

	BEGIN TRY
	
		--更新角色信息
		UPDATE [SysRole] SET 
		RoleName=@RoleName ,RecordState=@RecordState, 
		[ParentID] = @ParentID,[Code] = @Code,[Sort] = @Sort,[Weight] = @Weight,[Remark] = @Remark,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
		WHERE SysRoleID=@SysRoleID
		
		--刷新所有用户角色信息
		EXEC dbo.sp_SysRole_RefreshUserRoleInfo
		
		SET @ResultCode=1
		COMMIT TRAN trans
	END TRY
	BEGIN CATCH
		set @ResultMessage= ERROR_MESSAGE() 
		SET @ResultCode=0
		ROLLBACK TRAN trans
	END CATCH

END






GO

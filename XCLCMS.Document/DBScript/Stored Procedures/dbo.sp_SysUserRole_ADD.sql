SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO








/*
	保存用户角色关系表
*/
CREATE PROCEDURE [dbo].[sp_SysUserRole_ADD]
(
	@FK_UserInfoID bigint,
	@FK_SysRoleIDTable TVP_IDTable READONLY ,--该用户对应的角色id （一个或多个）
	
	@RecordState char(1),
	@CreateTime DATETIME,
	@CreaterID bigint,
	@CreaterName nvarchar(50),
	@UpdateTime datetime,
	@UpdaterID bigint,
	@UpdaterName nvarchar(50),
	
	@ResultCode INT OUTPUT,
	@ResultMessage NVARCHAR(1000) OUTPUT
)
 AS 

 BEGIN
 
	SET @ResultCode=1
	SET @ResultMessage=N'' 
	
	BEGIN TRAN trans
	
	BEGIN TRY
		
			/********其它附加处理********/
			BEGIN
			
				--清空该用户的所有角色
				DELETE dbo.SysUserRole WHERE FK_UserInfoID=@FK_UserInfoID	

			END
		 
			/********解析角色xml及保存信息********/
			BEGIN
			
				;WITH RoleIdList AS (
					--角色list
					SELECT ID AS FK_SysRoleID FROM @FK_SysRoleIDTable
				),
				BaseInfo AS (
					--用户角色表基本信息
					SELECT 
					@FK_UserInfoID AS FK_UserInfoID,
					@RecordState AS RecordState,
					@CreateTime AS CreateTime,
					@CreaterID AS CreaterID,
					@CreaterName AS CreaterName,
					@UpdateTime AS UpdateTime,
					@UpdaterID AS UpdaterID,
					@UpdaterName AS UpdaterName
				),
				JoinInfo AS (
					--该用户与角色list组合成多个记录便于写入表中
					SELECT * FROM RoleIdList CROSS JOIN BaseInfo
				),
				ResultInfo AS (
					--排除无效的角色信息
					SELECT 
					a.*
					FROM JoinInfo AS a
					INNER JOIN dbo.v_SysRole AS b ON a.FK_SysRoleID=b.SysRoleID
				)
				SELECT * INTO #ResultInfoTemp FROM ResultInfo
				
				
				/********保存********/
				INSERT dbo.SysUserRole( FK_UserInfoID ,FK_SysRoleID ,RecordState ,CreateTime ,CreaterID ,CreaterName ,UpdateTime ,UpdaterID ,UpdaterName)
				SELECT FK_UserInfoID ,FK_SysRoleID ,RecordState ,CreateTime ,CreaterID ,CreaterName ,UpdateTime ,UpdaterID ,UpdaterName FROM #ResultInfoTemp
		 
		 
				/********更新用户表********/
				EXEC dbo.sp_SysRole_RefreshUserRoleInfo @FK_UserInfoID

				/********其它处理********/
				DROP TABLE #ResultInfoTemp
				
				
			END 
		
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

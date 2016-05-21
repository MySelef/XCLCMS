
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[sp_MerchantApp_Update]
@MerchantAppID bigint,
@MerchantAppName varchar(100),
@FK_MerchantID bigint,
@ResourceVersion varchar(50),
@Email varchar(50),
@CopyRight varchar(2000),
@MetaDescription varchar(500),
@MetaKeyWords varchar(500),
@MetaTitle varchar(500),
@WebURL varchar(500),
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

 	BEGIN TRY
			UPDATE [MerchantApp] SET 
			[MerchantAppName] = @MerchantAppName,[FK_MerchantID] = @FK_MerchantID,[ResourceVersion] = @ResourceVersion,[Email] = @Email,[CopyRight] = @CopyRight,[MetaDescription] = @MetaDescription,[MetaKeyWords] = @MetaKeyWords,[MetaTitle] = @MetaTitle,[WebURL] = @WebURL,[Remark] = @Remark,[RecordState] = @RecordState,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
			WHERE MerchantAppID=@MerchantAppID 

			SET @ResultCode=1
	END TRY
	BEGIN CATCH
			SET @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0
	END CATCH

GO

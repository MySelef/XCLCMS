
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE PROCEDURE [dbo].[sp_MerchantApp_Update]
@MerchantAppID BIGINT,
@MerchantAppName VARCHAR(100),
@FK_MerchantID BIGINT,
@AppKey VARCHAR(50),
@ResourceVersion VARCHAR(50),
@Email VARCHAR(50),
@CopyRight VARCHAR(2000),
@MetaDescription VARCHAR(500),
@MetaKeyWords VARCHAR(500),
@MetaTitle VARCHAR(500),
@WebURL VARCHAR(500),
@Remark VARCHAR(1000),
@RecordState CHAR(1),
@CreateTime DATETIME,
@CreaterID BIGINT,
@CreaterName NVARCHAR(50),
@UpdateTime DATETIME,
@UpdaterID BIGINT,
@UpdaterName NVARCHAR(50),

@ResultCode INT OUTPUT,
@ResultMessage NVARCHAR(1000) OUTPUT
 AS 

 	BEGIN TRY
			UPDATE [MerchantApp] SET 
			[MerchantAppName] = @MerchantAppName,[FK_MerchantID] = @FK_MerchantID,[AppKey]=@AppKey,  [ResourceVersion] = @ResourceVersion,[Email] = @Email,[CopyRight] = @CopyRight,[MetaDescription] = @MetaDescription,[MetaKeyWords] = @MetaKeyWords,[MetaTitle] = @MetaTitle,[WebURL] = @WebURL,[Remark] = @Remark,[RecordState] = @RecordState,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
			WHERE MerchantAppID=@MerchantAppID 

			SET @ResultCode=1
	END TRY
	BEGIN CATCH
			SET @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0
	END CATCH


GO

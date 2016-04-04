
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE PROCEDURE [dbo].[sp_Attachment_Update]
@AttachmentID BIGINT,
@ParentID BIGINT,
@FileName VARCHAR(500),
@Title NVARCHAR(200),
@ViewType CHAR(3),
@FormatType CHAR(3),
@Ext VARCHAR(10),
@URL VARCHAR(1000),
@Description NVARCHAR(2000),
@DownLoadCount INT,
@ViewCount INT,
@FileSize DECIMAL(18,2),
@ImgWidth INT,
@ImgHeight INT,
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
	UPDATE [Attachment] SET 
	Title=@Title, 
	[ParentID] = @ParentID,[FileName] = @FileName,[ViewType] = @ViewType,[FormatType] = @FormatType,[Ext] = @Ext,[URL] = @URL,[Description] = @Description,[DownLoadCount] = @DownLoadCount,[ViewCount] = @ViewCount,[FileSize] = @FileSize,[ImgWidth] = @ImgWidth,[ImgHeight] = @ImgHeight,[RecordState] = @RecordState,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
	WHERE AttachmentID=@AttachmentID
	SET @ResultCode=1
 END TRY
 	BEGIN CATCH
			SET @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0
	END CATCH


GO

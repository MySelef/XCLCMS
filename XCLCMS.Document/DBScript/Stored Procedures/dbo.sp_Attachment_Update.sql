
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO




CREATE PROCEDURE [dbo].[sp_Attachment_Update]
@AttachmentID bigint,
@ParentID bigint,
@OriginFileName varchar(500),
@FileName varchar(500),
@Title nvarchar(200),
@ViewType char(3),
@FormatType char(3),
@Ext varchar(10),
@URL varchar(1000),
@Description nvarchar(2000),
@DownLoadCount int,
@ViewCount int,
@FileSize decimal(18,2),
@ImgWidth int,
@ImgHeight int,
@FK_MerchantID bigint,
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
	UPDATE [Attachment] SET 
	 Title=@Title , FK_MerchantID=@FK_MerchantID ,
	[ParentID] = @ParentID,[OriginFileName] = @OriginFileName,[FileName] = @FileName,[ViewType] = @ViewType,[FormatType] = @FormatType,[Ext] = @Ext,[URL] = @URL,[Description] = @Description,[DownLoadCount] = @DownLoadCount,[ViewCount] = @ViewCount,[FileSize] = @FileSize,[ImgWidth] = @ImgWidth,[ImgHeight] = @ImgHeight,[RecordState] = @RecordState,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
	WHERE AttachmentID=@AttachmentID

	SET @ResultCode=1
 END TRY
 	BEGIN CATCH
			SET @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0
	END CATCH




GO

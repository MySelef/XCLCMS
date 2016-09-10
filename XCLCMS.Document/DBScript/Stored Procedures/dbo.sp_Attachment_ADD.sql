
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



CREATE PROCEDURE [dbo].[sp_Attachment_ADD]
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
	INSERT INTO [Attachment](
	[AttachmentID],[ParentID],[OriginFileName],[FileName],[Title],[ViewType],[FormatType],[Ext],[URL],[Description],[DownLoadCount],[ViewCount],[FileSize],[ImgWidth],[ImgHeight],[FK_MerchantID],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
	)VALUES(
	@AttachmentID,@ParentID,@OriginFileName,@FileName,@Title,@ViewType,@FormatType,@Ext,@URL,@Description,@DownLoadCount,@ViewCount,@FileSize,@ImgWidth,@ImgHeight,@FK_MerchantID,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
	)

	SET @ResultCode=1
END TRY
BEGIN CATCH
	SET @ResultMessage= ERROR_MESSAGE() 
	SET @ResultCode=0
END CATCH



GO

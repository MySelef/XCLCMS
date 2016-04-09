
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE PROCEDURE [dbo].[sp_Attachment_ADD]
@AttachmentID BIGINT,
@ParentID BIGINT,
@OriginFileName varchar(500),
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
	INSERT INTO [Attachment](
	[AttachmentID],[ParentID],[OriginFileName],[FileName],[Title],[ViewType],[FormatType],[Ext],[URL],[Description],[DownLoadCount],[ViewCount],[FileSize],[ImgWidth],[ImgHeight],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
	)VALUES(
	@AttachmentID,@ParentID,@OriginFileName,@FileName,@Title,@ViewType,@FormatType,@Ext,@URL,@Description,@DownLoadCount,@ViewCount,@FileSize,@ImgWidth,@ImgHeight,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
	)

	SET @ResultCode=1
END TRY
BEGIN CATCH
	SET @ResultMessage= ERROR_MESSAGE() 
	SET @ResultCode=0
END CATCH


GO

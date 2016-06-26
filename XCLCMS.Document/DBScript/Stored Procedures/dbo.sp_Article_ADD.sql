
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE PROCEDURE [dbo].[sp_Article_ADD]
@ArticleID bigint,
@Code varchar(50),
@Title nvarchar(200),
@SubTitle nvarchar(200),
@AuthorName nvarchar(50),
@FromInfo nvarchar(500),
@ArticleContentType char(3),
@Contents nvarchar(MAX),
@Summary nvarchar(500),
@MainImage1 bigint,
@MainImage2 bigint,
@MainImage3 bigint,
@ViewCount int,
@IsCanComment char(1),
@CommentCount int,
@GoodCount int,
@MiddleCount int,
@BadCount int,
@HotCount int,
@URLOpenType char(3),
@ArticleState char(3),
@VerifyState char(3),
@IsRecommend char(1),
@IsEssence char(1),
@IsTop char(1),
@TopBeginTime datetime,
@TopEndTime datetime,
@KeyWords nvarchar(100),
@Tags nvarchar(100),
@Comments nvarchar(500),
@LinkUrl varchar(300),
@PublishTime datetime,
@FK_MerchantID bigint,
@FK_MerchantAppID bigint,
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
		INSERT INTO [Article](
		[ArticleID],[Code],[Title],[SubTitle],[AuthorName],[FromInfo],[ArticleContentType],[Contents],[Summary],[MainImage1],[MainImage2],[MainImage3],[ViewCount],[IsCanComment],[CommentCount],[GoodCount],[MiddleCount],[BadCount],[HotCount],[URLOpenType],[ArticleState],[VerifyState],[IsRecommend],[IsEssence],[IsTop],[TopBeginTime],[TopEndTime],[KeyWords],[Tags],[Comments],[LinkUrl],[PublishTime],[FK_MerchantID],[FK_MerchantAppID],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
		)VALUES(
		@ArticleID,@Code,@Title,@SubTitle,@AuthorName,@FromInfo,@ArticleContentType,@Contents,@Summary,@MainImage1,@MainImage2,@MainImage3,@ViewCount,@IsCanComment,@CommentCount,@GoodCount,@MiddleCount,@BadCount,@HotCount,@URLOpenType,@ArticleState,@VerifyState,@IsRecommend,@IsEssence,@IsTop,@TopBeginTime,@TopEndTime,@KeyWords,@Tags,@Comments,@LinkUrl,@PublishTime,@FK_MerchantID,@FK_MerchantAppID,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
		)
		SET @ResultCode=1
END TRY
BEGIN CATCH
	SET @ResultMessage= ERROR_MESSAGE() 
	SET @ResultCode=0
END CATCH

GO

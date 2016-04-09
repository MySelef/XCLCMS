SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE PROCEDURE [dbo].[sp_Article_Update]
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
	UPDATE [Article] SET 
	Code=@Code , Title=@Title,
	[SubTitle] = @SubTitle,[AuthorName] = @AuthorName,[FromInfo] = @FromInfo,[ArticleContentType] = @ArticleContentType,[Contents] = @Contents,[Summary] = @Summary,[MainImage1] = @MainImage1,[MainImage2] = @MainImage2,[MainImage3] = @MainImage3,[ViewCount] = @ViewCount,[IsCanComment] = @IsCanComment,[CommentCount] = @CommentCount,[GoodCount] = @GoodCount,[MiddleCount] = @MiddleCount,[BadCount] = @BadCount,[HotCount] = @HotCount,[URLOpenType] = @URLOpenType,[ArticleState] = @ArticleState,[VerifyState] = @VerifyState,[IsRecommend] = @IsRecommend,[IsEssence] = @IsEssence,[IsTop] = @IsTop,[TopBeginTime] = @TopBeginTime,[TopEndTime] = @TopEndTime,[KeyWords] = @KeyWords,[Tags] = @Tags,[Comments] = @Comments,[LinkUrl] = @LinkUrl,[PublishTime] = @PublishTime,[RecordState] = @RecordState,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
	WHERE ArticleID=@ArticleID 

		SET @ResultCode=1
 END TRY
 	BEGIN CATCH
			SET @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0
	END CATCH
GO

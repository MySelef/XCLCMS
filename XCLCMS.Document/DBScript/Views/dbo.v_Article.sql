SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[v_Article] AS 

WITH info AS (
	SELECT
	a.ArticleID ,
    a.Code ,
    a.Title ,
    a.SubTitle ,
    a.AuthorName ,
    a.FromInfo ,
    a.ArticleContentType ,
    a.Contents ,
    a.Summary ,
    a.MainImage1 ,
    a.MainImage2 ,
    a.MainImage3 ,
    a.ViewCount ,
    a.IsCanComment ,
    a.CommentCount ,
    a.GoodCount ,
    a.MiddleCount ,
    a.BadCount ,
    a.HotCount ,
    a.URLOpenType ,
    a.ArticleState ,
    a.VerifyState ,
    a.IsRecommend ,
    a.IsEssence ,
    a.IsTop ,
    a.TopBeginTime ,
    a.TopEndTime ,
    a.KeyWords ,
    a.Tags ,
    a.Comments ,
    a.LinkUrl ,
    a.PublishTime ,
    a.RecordState ,
    a.CreateTime ,
    a.CreaterID ,
    a.CreaterName ,
    a.UpdateTime ,
    a.UpdaterID ,
    a.UpdaterName,
	(
		SELECT CAST(FK_TypeID AS VARCHAR)+',' FROM dbo.ArticleType WHERE FK_ArticleID=a.ArticleID FOR XML PATH('')
	) AS ArticleTypeIDs,
	(
		SELECT CAST(bb.DicName AS VARCHAR)+',' FROM dbo.ArticleType AS aa
		INNER JOIN dbo.SysDic AS bb ON aa.FK_TypeID=bb.SysDicID
		WHERE aa.FK_ArticleID=a.ArticleID FOR XML PATH('')
	) AS ArticleTypeNames
	FROM dbo.Article AS a
)
SELECT 
info.UpdaterName ,
info.UpdaterID ,
info.UpdateTime ,
info.CreaterName ,
info.CreaterID ,
info.CreateTime ,
info.RecordState ,
info.PublishTime ,
info.LinkUrl ,
info.Comments ,
info.Tags ,
info.KeyWords ,
info.TopEndTime ,
info.TopBeginTime ,
info.IsTop ,
info.IsEssence ,
info.IsRecommend ,
info.VerifyState ,
info.ArticleState ,
info.URLOpenType ,
info.HotCount ,
info.BadCount ,
info.MiddleCount ,
info.GoodCount ,
info.CommentCount ,
info.IsCanComment ,
info.ViewCount ,
info.MainImage3 ,
info.MainImage2 ,
info.MainImage1 ,
info.Summary ,
info.Contents ,
info.ArticleContentType ,
info.FromInfo ,
info.AuthorName ,
info.SubTitle ,
info.Title ,
info.Code ,
info.ArticleID ,
SUBSTRING(info.ArticleTypeIDs,0,LEN(info.ArticleTypeIDs)) AS ArticleTypeIDs ,
SUBSTRING(info.ArticleTypeNames,0,LEN(info.ArticleTypeNames)) AS ArticleTypeNames
FROM info

GO

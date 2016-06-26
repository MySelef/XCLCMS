
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
	a.FK_MerchantID,
	a.FK_MerchantAppID,
	b.MerchantName,
	b.MerchantSystemType,
	c.MerchantAppName,
	(
		SELECT CAST(FK_TypeID AS VARCHAR)+',' FROM dbo.ArticleType WHERE FK_ArticleID=a.ArticleID FOR XML PATH('')
	) AS ArticleTypeIDs,
	(
		SELECT CAST(bb.DicName AS VARCHAR)+',' FROM dbo.ArticleType AS aa
		INNER JOIN dbo.SysDic AS bb ON aa.FK_TypeID=bb.SysDicID
		WHERE aa.FK_ArticleID=a.ArticleID FOR XML PATH('')
	) AS ArticleTypeNames
	FROM dbo.Article AS a
	LEFT JOIN dbo.Merchant AS b ON a.FK_MerchantID=b.MerchantID
	LEFT JOIN dbo.MerchantApp AS c ON a.FK_MerchantAppID=c.MerchantAppID
)
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
a.FK_MerchantID,
a.FK_MerchantAppID,
a.MerchantName,
a.MerchantSystemType,
a.MerchantAppName,
SUBSTRING(a.ArticleTypeIDs,0,LEN(a.ArticleTypeIDs)) AS ArticleTypeIDs ,
SUBSTRING(a.ArticleTypeNames,0,LEN(a.ArticleTypeNames)) AS ArticleTypeNames
FROM info AS a





GO

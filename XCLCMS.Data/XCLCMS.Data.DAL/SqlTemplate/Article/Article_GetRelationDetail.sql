--DECLARE @@ArticleID BIGINT=0
--DECLARE @@IsASC TINYINT=0
--DECLARE @@TopCount INT=0

--上一篇
IF(@@IsASC=0)
BEGIN
	 SELECT TOP 1 * FROM dbo.Article as tb_Article WITH(NOLOCK) 
	 WHERE ArticleID<@@ArticleID   
	 @(Model.ArticleRecordState)  
	 @(Model.MerchantID)  
	 @(Model.MerchantAppID)   
	 ORDER BY ArticleID DESC
END
ELSE
BEGIN
	SELECT TOP 1 * FROM dbo.Article as tb_Article WITH(NOLOCK)  
	WHERE ArticleID>@@ArticleID  
	@(Model.ArticleRecordState)  
	@(Model.MerchantID)  
	@(Model.MerchantAppID)  
	ORDER BY ArticleID ASC
END

--下一篇
IF(@@IsASC=0)
BEGIN
	 SELECT TOP 1 * FROM dbo.Article as tb_Article WITH(NOLOCK)  
	 WHERE ArticleID>@@ArticleID  
	 @(Model.ArticleRecordState)  
	 @(Model.MerchantID)  
	 @(Model.MerchantAppID)  
	 ORDER BY ArticleID DESC
END
ELSE
BEGIN
	SELECT TOP 1 * FROM dbo.Article as tb_Article WITH(NOLOCK)  
	WHERE ArticleID<@@ArticleID 
	@(Model.ArticleRecordState)  
	@(Model.MerchantID)  
	@(Model.MerchantAppID)   
	ORDER BY ArticleID ASC
END

--同类其它文章（top n）
SELECT 
DISTINCT
TOP (@@TopCount)
tb_Article.* 
FROM dbo.Article AS tb_Article WITH(NOLOCK) 
INNER JOIN dbo.ArticleType AS b  WITH(NOLOCK) ON tb_Article.ArticleID=b.FK_ArticleID
INNER JOIN (
	SELECT DISTINCT FK_TypeID FROM dbo.ArticleType WITH(NOLOCK) WHERE FK_ArticleID=@@ArticleID AND RecordState='N'
) AS c ON b.FK_TypeID=c.FK_TypeID
WHERE tb_Article.ArticleID<>@@ArticleID
@(Model.ArticleRecordState)  
@(Model.MerchantID)  
@(Model.MerchantAppID) 
ORDER BY tb_Article.ArticleID @(Model.IsASC?"ASC":"DESC")
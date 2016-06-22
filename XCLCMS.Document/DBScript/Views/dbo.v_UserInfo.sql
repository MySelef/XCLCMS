SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[v_UserInfo] AS 
SELECT
a.*,
b.MerchantName,
b.MerchantSystemType,
c.MerchantAppName
FROM dbo.UserInfo AS a 
INNER JOIN dbo.Merchant AS b ON a.FK_MerchantID=b.MerchantID
LEFT JOIN dbo.MerchantApp AS c ON a.FK_MerchantAppID=c.MerchantAppID
GO

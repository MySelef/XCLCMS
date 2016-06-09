
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO



CREATE VIEW [dbo].[v_MerchantApp] AS 
SELECT
a.*,
b.MerchantName,
b.MerchantSystemType
FROM dbo.MerchantApp AS a
INNER JOIN dbo.Merchant AS b ON a.FK_MerchantID=b.MerchantID


GO

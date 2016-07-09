
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO




CREATE VIEW [dbo].[v_MerchantApp] AS 
SELECT
a.*,
b.MerchantName,
b.MerchantSystemType
FROM dbo.MerchantApp AS a WITH(NOLOCK) 
INNER JOIN dbo.Merchant AS b  WITH(NOLOCK) ON a.FK_MerchantID=b.MerchantID



GO

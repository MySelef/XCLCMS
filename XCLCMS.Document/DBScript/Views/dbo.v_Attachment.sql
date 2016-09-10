SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[v_Attachment] AS 
SELECT
a.*,
b.MerchantName
FROM dbo.Attachment AS a WITH(NOLOCK)
INNER JOIN dbo.Merchant AS b WITH(NOLOCK) ON a.FK_MerchantID=b.MerchantID


GO

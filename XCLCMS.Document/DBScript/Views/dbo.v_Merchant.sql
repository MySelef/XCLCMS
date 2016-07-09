
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO




CREATE VIEW [dbo].[v_Merchant] AS 

SELECT
a.*,
b.DicName AS MerchantTypeName,
c.DicName AS PassTypeName
FROM dbo.Merchant AS a WITH(NOLOCK) 
LEFT JOIN dbo.SysDic AS b  WITH(NOLOCK) ON a.FK_MerchantType=b.SysDicID
LEFT JOIN dbo.SysDic AS c  WITH(NOLOCK) ON a.FK_PassType=c.SysDicID



GO

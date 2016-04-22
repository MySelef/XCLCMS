
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE VIEW [dbo].[v_Merchant] AS 

SELECT
a.*,
b.DicName AS MerchantTypeName,
c.DicName AS PassTypeName
FROM dbo.Merchant AS a
LEFT JOIN dbo.SysDic AS b ON a.FK_MerchantType=b.SysDicID
LEFT JOIN dbo.SysDic AS c ON a.FK_PassType=c.SysDicID
GO

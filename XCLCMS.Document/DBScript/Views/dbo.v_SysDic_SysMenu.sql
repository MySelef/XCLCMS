SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
CREATE VIEW [dbo].[v_SysDic_SysMenu] AS 

--所有系统菜单信息
SELECT * FROM dbo.fun_SysDic_GetAllUnderListByCode('SysMenu')
GO

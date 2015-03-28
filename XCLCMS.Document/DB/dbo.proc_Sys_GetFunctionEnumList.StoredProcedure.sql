USE [XCLCMS]
GO
/****** Object:  StoredProcedure [dbo].[proc_Sys_GetFunctionEnumList]    Script Date: 03/21/2015 10:00:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[proc_Sys_GetFunctionEnumList] AS 
--生成模块功能的c# 枚举
BEGIN

DECLARE @str VARCHAR(MAX)=''
DECLARE @br VARCHAR(2)=char(13)+char(10)

SELECT
@str=@str+('/// <summary>'+@br+'///'+ (C_TypeName+Remark)+@br+'/// </summary>'+@br+'[Description("'+(C_TypeName+Remark)+'")]'+@br+ FunctionName +'=' +CAST(SysFunctionID AS VARCHAR)+',')+@br
FROM dbo.v_SysFunction WHERE RecordState='N'
ORDER BY FunctionName ASC

PRINT @str

end
GO

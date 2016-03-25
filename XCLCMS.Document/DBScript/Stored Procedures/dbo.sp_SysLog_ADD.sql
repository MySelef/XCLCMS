SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


CREATE PROCEDURE [dbo].[sp_SysLog_ADD]
@LogLevel varchar(50),
@LogType varchar(50),
@RefferUrl varchar(1000),
@Url varchar(1000),
@Code varchar(50),
@Title varchar(500),
@Contents varchar(4000),
@ClientIP varchar(50),
@Remark varchar(2000),
@CreateTime DATETIME

 AS 
 
	INSERT INTO [SysLog](
	[LogLevel],[LogType],[RefferUrl],[Url],[Code],[Title],[Contents],[ClientIP],[Remark],[CreateTime]
	)VALUES(
	@LogLevel,@LogType,@RefferUrl,@Url,@Code,@Title,@Contents,@ClientIP,@Remark,@CreateTime
	)

GO

USE [XCLCMS]
GO
/****** Object:  StoredProcedure [dbo].[SysWebSetting_ADD]    Script Date: 03/21/2015 10:00:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SysWebSetting_ADD]
@SysWebSettingID bigint,
@KeyName varchar(100),
@KeyValue varchar(2000),
@Remark varchar(1000),
@RecordState char(1),
@CreateTime datetime,
@CreaterID bigint,
@CreaterName nvarchar(50),
@UpdateTime datetime,
@UpdaterID bigint,
@UpdaterName nvarchar(50)

 AS 
	INSERT INTO [SysWebSetting](
	[SysWebSettingID],[KeyName],[KeyValue],[Remark],[RecordState],[CreateTime],[CreaterID],[CreaterName],[UpdateTime],[UpdaterID],[UpdaterName]
	)VALUES(
	@SysWebSettingID,@KeyName,@KeyValue,@Remark,@RecordState,@CreateTime,@CreaterID,@CreaterName,@UpdateTime,@UpdaterID,@UpdaterName
	)
GO

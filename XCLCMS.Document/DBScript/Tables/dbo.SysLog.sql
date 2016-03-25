CREATE TABLE [dbo].[SysLog]
(
[SysLogID] [bigint] NOT NULL IDENTITY(1, 1),
[LogLevel] [varchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[LogType] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[RefferUrl] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL,
[Url] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL,
[Code] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[Title] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[Contents] [varchar] (4000) COLLATE Chinese_PRC_CI_AS NULL,
[ClientIP] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[Remark] [varchar] (2000) COLLATE Chinese_PRC_CI_AS NULL,
[CreateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SysLog] ADD CONSTRAINT [PK_SYSLOG] PRIMARY KEY CLUSTERED  ([SysLogID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ClientIP] ON [dbo].[SysLog] ([ClientIP]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_LogType] ON [dbo].[SysLog] ([LogType]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Title] ON [dbo].[SysLog] ([Title]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', '系统日志记录', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '客户端IP', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'ClientIP'
GO
EXEC sp_addextendedproperty N'MS_Description', '日志代码', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'Code'
GO
EXEC sp_addextendedproperty N'MS_Description', '内容', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'Contents'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '日志级别', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'LogLevel'
GO
EXEC sp_addextendedproperty N'MS_Description', '日志类别(LogTypeEnum)', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'LogType'
GO
EXEC sp_addextendedproperty N'MS_Description', '来源URL', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'RefferUrl'
GO
EXEC sp_addextendedproperty N'MS_Description', '备注', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'Remark'
GO
EXEC sp_addextendedproperty N'MS_Description', 'SysLogID', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'SysLogID'
GO
EXEC sp_addextendedproperty N'MS_Description', '标题', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'Title'
GO
EXEC sp_addextendedproperty N'MS_Description', 'Url', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'Url'
GO

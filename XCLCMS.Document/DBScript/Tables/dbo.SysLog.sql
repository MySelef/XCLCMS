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
[FK_MerchantID] [bigint] NOT NULL CONSTRAINT [DF__tmp_ms_xx__FK_Me__351DDF8C] DEFAULT ((0)),
[FK_MerchantAppID] [bigint] NOT NULL CONSTRAINT [DF__tmp_ms_xx__FK_Me__361203C5] DEFAULT ((0)),
[CreateTime] [datetime] NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[SysLog] ADD 
CONSTRAINT [PK_SYSLOG] PRIMARY KEY CLUSTERED  ([SysLogID]) ON [PRIMARY]
CREATE NONCLUSTERED INDEX [IX_LogType] ON [dbo].[SysLog] ([LogType]) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_Title] ON [dbo].[SysLog] ([Title]) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_ClientIP] ON [dbo].[SysLog] ([ClientIP]) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_FK_MerchantID] ON [dbo].[SysLog] ([FK_MerchantID]) ON [PRIMARY]

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

EXEC sp_addextendedproperty N'MS_Description', '所属应用号', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'FK_MerchantAppID'
GO

EXEC sp_addextendedproperty N'MS_Description', '所属商户号', 'SCHEMA', N'dbo', 'TABLE', N'SysLog', 'COLUMN', N'FK_MerchantID'
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

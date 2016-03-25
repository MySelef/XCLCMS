CREATE TABLE [dbo].[SysWebSetting]
(
[SysWebSettingID] [bigint] NOT NULL,
[KeyName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL,
[KeyValue] [varchar] (2000) COLLATE Chinese_PRC_CI_AS NULL,
[Remark] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL,
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SysWebSetting] ADD CONSTRAINT [PK_SYSWEBSETTING] PRIMARY KEY CLUSTERED  ([SysWebSettingID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[SysWebSetting] ADD CONSTRAINT [AK_UK_KEYNAME_SYSWEBSE] UNIQUE NONCLUSTERED  ([KeyName]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_KeyName] ON [dbo].[SysWebSetting] ([KeyName]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', '网站配置表', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', 'COLUMN', N'CreaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', 'COLUMN', N'CreaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '键', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', 'COLUMN', N'KeyName'
GO
EXEC sp_addextendedproperty N'MS_Description', '值', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', 'COLUMN', N'KeyValue'
GO
EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', 'COLUMN', N'RecordState'
GO
EXEC sp_addextendedproperty N'MS_Description', '备注', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', 'COLUMN', N'Remark'
GO
EXEC sp_addextendedproperty N'MS_Description', 'SysWebSettingID', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', 'COLUMN', N'SysWebSettingID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', 'COLUMN', N'UpdaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', 'COLUMN', N'UpdaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'SysWebSetting', 'COLUMN', N'UpdateTime'
GO

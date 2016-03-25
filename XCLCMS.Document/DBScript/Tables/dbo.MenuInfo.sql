CREATE TABLE [dbo].[MenuInfo]
(
[MenuInfoID] [bigint] NOT NULL,
[ParentID] [bigint] NOT NULL,
[Code] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[MenuName] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[URL] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[Description] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[URLOpenType] [char] (3) COLLATE Chinese_PRC_CI_AS NULL,
[FK_MenuTypeID] [bigint] NOT NULL,
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MenuInfo] ADD CONSTRAINT [PK_MENUINFO] PRIMARY KEY CLUSTERED  ([MenuInfoID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Code] ON [dbo].[MenuInfo] ([Code]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MenuName] ON [dbo].[MenuInfo] ([MenuName]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', '菜单表', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '唯一标识', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'Code'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'CreaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'CreaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '描述', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'Description'
GO
EXEC sp_addextendedproperty N'MS_Description', '菜单类型', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'FK_MenuTypeID'
GO
EXEC sp_addextendedproperty N'MS_Description', 'MenuInfoID', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'MenuInfoID'
GO
EXEC sp_addextendedproperty N'MS_Description', '菜单名称', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'MenuName'
GO
EXEC sp_addextendedproperty N'MS_Description', '父菜单ID', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'ParentID'
GO
EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'RecordState'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'UpdaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'UpdaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'UpdateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '链接地址', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'URL'
GO
EXEC sp_addextendedproperty N'MS_Description', '打开方式(URLOpenTypeEnum)', 'SCHEMA', N'dbo', 'TABLE', N'MenuInfo', 'COLUMN', N'URLOpenType'
GO

CREATE TABLE [dbo].[SysRole]
(
[SysRoleID] [bigint] NOT NULL,
[ParentID] [bigint] NOT NULL,
[RoleName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NOT NULL,
[Code] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[Sort] [int] NOT NULL,
[Weight] [int] NULL,
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
ALTER TABLE [dbo].[SysRole] ADD CONSTRAINT [PK_SYSROLE] PRIMARY KEY CLUSTERED  ([SysRoleID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_RoleName] ON [dbo].[SysRole] ([RoleName]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', '角色表', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '角色标识', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'Code'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'CreaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'CreaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '父ID', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'ParentID'
GO
EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'RecordState'
GO
EXEC sp_addextendedproperty N'MS_Description', '备注', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'Remark'
GO
EXEC sp_addextendedproperty N'MS_Description', '角色名', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'RoleName'
GO
EXEC sp_addextendedproperty N'MS_Description', '排序号', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'Sort'
GO
EXEC sp_addextendedproperty N'MS_Description', 'SysRoleID', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'SysRoleID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'UpdaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'UpdaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'UpdateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '权重', 'SCHEMA', N'dbo', 'TABLE', N'SysRole', 'COLUMN', N'Weight'
GO

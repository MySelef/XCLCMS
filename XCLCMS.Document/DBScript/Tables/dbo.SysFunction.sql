CREATE TABLE [dbo].[SysFunction]
(
[SysFunctionID] [bigint] NOT NULL,
[ParentID] [bigint] NOT NULL,
[FunctionName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL,
[Code] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[Remark] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[SysFunction] ADD 
CONSTRAINT [PK_SYSFUNCTION] PRIMARY KEY CLUSTERED  ([SysFunctionID]) ON [PRIMARY]
CREATE NONCLUSTERED INDEX [IX_FunctionName] ON [dbo].[SysFunction] ([FunctionName]) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_Code] ON [dbo].[SysFunction] ([Code]) ON [PRIMARY]



GO
EXEC sp_addextendedproperty N'MS_Description', '系统功能表', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', NULL, NULL
GO

EXEC sp_addextendedproperty N'MS_Description', '功能标识', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'Code'
GO

EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'CreaterID'
GO

EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'CreaterName'
GO

EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'CreateTime'
GO


EXEC sp_addextendedproperty N'MS_Description', '功能名', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'FunctionName'
GO

EXEC sp_addextendedproperty N'MS_Description', '父ID', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'ParentID'
GO

EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'RecordState'
GO

EXEC sp_addextendedproperty N'MS_Description', '备注', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty N'MS_Description', 'SysFunctionID', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'SysFunctionID'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'UpdaterID'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'UpdaterName'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'SysFunction', 'COLUMN', N'UpdateTime'
GO

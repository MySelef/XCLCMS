CREATE TABLE [dbo].[SysDic]
(
[SysDicID] [bigint] NOT NULL,
[Code] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[DicType] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[ParentID] [bigint] NOT NULL,
[DicName] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[DicValue] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL,
[Sort] [int] NOT NULL,
[Remark] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL,
[FK_FunctionID] [bigint] NULL,
[FK_MerchantID] [bigint] NOT NULL CONSTRAINT [DF__tmp_ms_xx__FK_Me__2E70E1FD] DEFAULT ((0)),
[FK_MerchantAppID] [bigint] NOT NULL CONSTRAINT [DF__tmp_ms_xx__FK_Me__2F650636] DEFAULT ((0)),
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[SysDic] ADD 
CONSTRAINT [PK_SYSDIC] PRIMARY KEY CLUSTERED  ([SysDicID]) ON [PRIMARY]
CREATE NONCLUSTERED INDEX [IX_Code] ON [dbo].[SysDic] ([Code]) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_DicName] ON [dbo].[SysDic] ([DicName]) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_FK_MerchantID] ON [dbo].[SysDic] ([FK_MerchantID]) ON [PRIMARY]

GO
EXEC sp_addextendedproperty N'MS_Description', '系统字典表', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', NULL, NULL
GO

EXEC sp_addextendedproperty N'MS_Description', '字典标识', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'Code'
GO

EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'CreaterID'
GO

EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'CreaterName'
GO

EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty N'MS_Description', '键', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'DicName'
GO

EXEC sp_addextendedproperty N'MS_Description', '字典类型(DicTypeEnum)', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'DicType'
GO

EXEC sp_addextendedproperty N'MS_Description', '值', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'DicValue'
GO

EXEC sp_addextendedproperty N'MS_Description', '所属功能ID', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'FK_FunctionID'
GO

EXEC sp_addextendedproperty N'MS_Description', '所属应用号', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'FK_MerchantAppID'
GO

EXEC sp_addextendedproperty N'MS_Description', '所属商户号', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'FK_MerchantID'
GO

EXEC sp_addextendedproperty N'MS_Description', '父ID', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'ParentID'
GO

EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'RecordState'
GO

EXEC sp_addextendedproperty N'MS_Description', '备注', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'Remark'
GO

EXEC sp_addextendedproperty N'MS_Description', '排序号', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'Sort'
GO

EXEC sp_addextendedproperty N'MS_Description', 'SysDicID', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'SysDicID'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'UpdaterID'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'UpdaterName'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'SysDic', 'COLUMN', N'UpdateTime'
GO

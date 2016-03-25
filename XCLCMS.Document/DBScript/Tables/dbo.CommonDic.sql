CREATE TABLE [dbo].[CommonDic]
(
[CommonDicID] [bigint] NOT NULL,
[Code] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[DicType] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[ParentID] [bigint] NOT NULL,
[DicName] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[DicValue] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL,
[Sort] [int] NOT NULL,
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CommonDic] ADD CONSTRAINT [PK_COMMONDIC] PRIMARY KEY CLUSTERED  ([CommonDicID]) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CommonDic] ADD CONSTRAINT [AK_UK_CODE_COMMONDI] UNIQUE NONCLUSTERED  ([Code]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Code] ON [dbo].[CommonDic] ([Code]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_DicName] ON [dbo].[CommonDic] ([DicName]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', '公共字典表', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '唯一标识', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'Code'
GO
EXEC sp_addextendedproperty N'MS_Description', 'CommonDicID', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'CommonDicID'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'CreaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'CreaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '键', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'DicName'
GO
EXEC sp_addextendedproperty N'MS_Description', '字典类型(DicTypeEnum)', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'DicType'
GO
EXEC sp_addextendedproperty N'MS_Description', '值', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'DicValue'
GO
EXEC sp_addextendedproperty N'MS_Description', '父ID', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'ParentID'
GO
EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'RecordState'
GO
EXEC sp_addextendedproperty N'MS_Description', '排序号', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'Sort'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'UpdaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'UpdaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'CommonDic', 'COLUMN', N'UpdateTime'
GO

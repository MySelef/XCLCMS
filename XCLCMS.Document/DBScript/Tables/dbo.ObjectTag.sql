CREATE TABLE [dbo].[ObjectTag]
(
[ObjectType] [char] (3) COLLATE Chinese_PRC_CI_AS NOT NULL,
[FK_ObjectID] [bigint] NOT NULL,
[FK_TagsID] [bigint] NOT NULL,
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[ObjectTag] ADD 
CONSTRAINT [PK_OBJECTTAG] PRIMARY KEY CLUSTERED  ([ObjectType], [FK_ObjectID], [FK_TagsID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ObjectType] ON [dbo].[ObjectTag] ([ObjectType]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', '所有标签关系表', 'SCHEMA', N'dbo', 'TABLE', N'ObjectTag', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'ObjectTag', 'COLUMN', N'CreaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'ObjectTag', 'COLUMN', N'CreaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'ObjectTag', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '所属主体ID', 'SCHEMA', N'dbo', 'TABLE', N'ObjectTag', 'COLUMN', N'FK_ObjectID'
GO
EXEC sp_addextendedproperty N'MS_Description', '所属标签', 'SCHEMA', N'dbo', 'TABLE', N'ObjectTag', 'COLUMN', N'FK_TagsID'
GO
EXEC sp_addextendedproperty N'MS_Description', '标签所属主体类别(ObjectTypeEnum)', 'SCHEMA', N'dbo', 'TABLE', N'ObjectTag', 'COLUMN', N'ObjectType'
GO
EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'ObjectTag', 'COLUMN', N'RecordState'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'ObjectTag', 'COLUMN', N'UpdaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'ObjectTag', 'COLUMN', N'UpdaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'ObjectTag', 'COLUMN', N'UpdateTime'
GO

CREATE TABLE [dbo].[ObjectAttachment]
(
[ObjectType] [char] (3) COLLATE Chinese_PRC_CI_AS NOT NULL,
[FK_ObjectID] [bigint] NOT NULL,
[FK_AttachmentID] [bigint] NOT NULL,
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_ObjectType] ON [dbo].[ObjectAttachment] ([ObjectType]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', '所有附件关系表', 'SCHEMA', N'dbo', 'TABLE', N'ObjectAttachment', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'ObjectAttachment', 'COLUMN', N'CreaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'ObjectAttachment', 'COLUMN', N'CreaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'ObjectAttachment', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '附件ID', 'SCHEMA', N'dbo', 'TABLE', N'ObjectAttachment', 'COLUMN', N'FK_AttachmentID'
GO
EXEC sp_addextendedproperty N'MS_Description', '附件所属主体ID', 'SCHEMA', N'dbo', 'TABLE', N'ObjectAttachment', 'COLUMN', N'FK_ObjectID'
GO
EXEC sp_addextendedproperty N'MS_Description', '附件所属主体类别(ObjectTypeEnum)', 'SCHEMA', N'dbo', 'TABLE', N'ObjectAttachment', 'COLUMN', N'ObjectType'
GO
EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'ObjectAttachment', 'COLUMN', N'RecordState'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'ObjectAttachment', 'COLUMN', N'UpdaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'ObjectAttachment', 'COLUMN', N'UpdaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'ObjectAttachment', 'COLUMN', N'UpdateTime'
GO

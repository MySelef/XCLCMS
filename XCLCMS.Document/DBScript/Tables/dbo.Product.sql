CREATE TABLE [dbo].[Product]
(
[ProductID] [bigint] NOT NULL,
[Title] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[URLOpenType] [char] (3) COLLATE Chinese_PRC_CI_AS NULL,
[Description] [nvarchar] (max) COLLATE Chinese_PRC_CI_AS NULL,
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Product] ADD CONSTRAINT [PK_PRODUCT] PRIMARY KEY CLUSTERED  ([ProductID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Title] ON [dbo].[Product] ([Title]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', '产品表', 'SCHEMA', N'dbo', 'TABLE', N'Product', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'Product', 'COLUMN', N'CreaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'Product', 'COLUMN', N'CreaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'Product', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '产品描述', 'SCHEMA', N'dbo', 'TABLE', N'Product', 'COLUMN', N'Description'
GO
EXEC sp_addextendedproperty N'MS_Description', 'ProductID', 'SCHEMA', N'dbo', 'TABLE', N'Product', 'COLUMN', N'ProductID'
GO
EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'Product', 'COLUMN', N'RecordState'
GO
EXEC sp_addextendedproperty N'MS_Description', '标题', 'SCHEMA', N'dbo', 'TABLE', N'Product', 'COLUMN', N'Title'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'Product', 'COLUMN', N'UpdaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'Product', 'COLUMN', N'UpdaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'Product', 'COLUMN', N'UpdateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '打开方式(URLOpenTypeEnum)', 'SCHEMA', N'dbo', 'TABLE', N'Product', 'COLUMN', N'URLOpenType'
GO

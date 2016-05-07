CREATE TABLE [dbo].[Tags]
(
[TagsID] [bigint] NOT NULL,
[TagName] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL,
[Description] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[FK_MerchantID] [bigint] NOT NULL CONSTRAINT [DF__tmp_ms_xx__FK_Me__408F9238] DEFAULT ((0)),
[FK_MerchantAppID] [bigint] NOT NULL CONSTRAINT [DF__tmp_ms_xx__FK_Me__4183B671] DEFAULT ((0)),
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[Tags] ADD 
CONSTRAINT [PK_TAGS] PRIMARY KEY CLUSTERED  ([TagsID]) ON [PRIMARY]
CREATE NONCLUSTERED INDEX [IX_TagName] ON [dbo].[Tags] ([TagName]) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_FK_MerchantID] ON [dbo].[Tags] ([FK_MerchantID]) ON [PRIMARY]

GO
EXEC sp_addextendedproperty N'MS_Description', '标签表', 'SCHEMA', N'dbo', 'TABLE', N'Tags', NULL, NULL
GO

EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'CreaterID'
GO

EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'CreaterName'
GO

EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty N'MS_Description', '描述信息', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'Description'
GO

EXEC sp_addextendedproperty N'MS_Description', '所属应用号', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'FK_MerchantAppID'
GO

EXEC sp_addextendedproperty N'MS_Description', '所属商户号', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'FK_MerchantID'
GO

EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'RecordState'
GO

EXEC sp_addextendedproperty N'MS_Description', '标签名', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'TagName'
GO

EXEC sp_addextendedproperty N'MS_Description', 'TagsID', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'TagsID'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'UpdaterID'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'UpdaterName'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'Tags', 'COLUMN', N'UpdateTime'
GO

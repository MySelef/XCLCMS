CREATE TABLE [dbo].[FriendLinks]
(
[FriendLinkID] [bigint] NOT NULL,
[Title] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[Description] [nvarchar] (2000) COLLATE Chinese_PRC_CI_AS NULL,
[URL] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[ContactName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[Email] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL,
[QQ] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[Tel] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[Remark] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[OtherContact] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FriendLinks] ADD CONSTRAINT [PK_FRIENDLINKS] PRIMARY KEY CLUSTERED  ([FriendLinkID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Title] ON [dbo].[FriendLinks] ([Title]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', '友情链接表', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '联系人名', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'ContactName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'CreaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'CreaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '描述', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'Description'
GO
EXEC sp_addextendedproperty N'MS_Description', '电子邮件', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'Email'
GO
EXEC sp_addextendedproperty N'MS_Description', 'FriendLinkID', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'FriendLinkID'
GO
EXEC sp_addextendedproperty N'MS_Description', '其它联系方式', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'OtherContact'
GO
EXEC sp_addextendedproperty N'MS_Description', 'QQ', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'QQ'
GO
EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'RecordState'
GO
EXEC sp_addextendedproperty N'MS_Description', '备注', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'Remark'
GO
EXEC sp_addextendedproperty N'MS_Description', '手机号', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'Tel'
GO
EXEC sp_addextendedproperty N'MS_Description', '标题', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'Title'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'UpdaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'UpdaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'UpdateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '链接地址', 'SCHEMA', N'dbo', 'TABLE', N'FriendLinks', 'COLUMN', N'URL'
GO

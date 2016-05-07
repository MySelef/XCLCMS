CREATE TABLE [dbo].[Attachment]
(
[AttachmentID] [bigint] NOT NULL,
[ParentID] [bigint] NOT NULL CONSTRAINT [DF__tmp_ms_xx__Paren__1C5231C2] DEFAULT ((0)),
[OriginFileName] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[FileName] [varchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[Title] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[ViewType] [char] (3) COLLATE Chinese_PRC_CI_AS NOT NULL,
[FormatType] [char] (3) COLLATE Chinese_PRC_CI_AS NOT NULL,
[Ext] [varchar] (10) COLLATE Chinese_PRC_CI_AS NULL,
[URL] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL,
[Description] [nvarchar] (2000) COLLATE Chinese_PRC_CI_AS NULL,
[DownLoadCount] [int] NOT NULL,
[ViewCount] [int] NOT NULL,
[FileSize] [decimal] (18, 2) NOT NULL CONSTRAINT [DF__tmp_ms_xx__FileS__1D4655FB] DEFAULT ((0)),
[ImgWidth] [int] NOT NULL CONSTRAINT [DF__tmp_ms_xx__ImgWi__1E3A7A34] DEFAULT ((0)),
[ImgHeight] [int] NOT NULL CONSTRAINT [DF__tmp_ms_xx__ImgHe__1F2E9E6D] DEFAULT ((0)),
[FK_MerchantID] [bigint] NOT NULL CONSTRAINT [DF__tmp_ms_xx__FK_Me__2022C2A6] DEFAULT ((0)),
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[Attachment] ADD 
CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED  ([AttachmentID]) ON [PRIMARY]
CREATE NONCLUSTERED INDEX [IX_Title] ON [dbo].[Attachment] ([Title]) ON [PRIMARY]

CREATE NONCLUSTERED INDEX [IX_FK_MerchantID] ON [dbo].[Attachment] ([FK_MerchantID]) ON [PRIMARY]

GO
EXEC sp_addextendedproperty N'MS_Description', '附件表', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', NULL, NULL
GO

EXEC sp_addextendedproperty N'MS_Description', 'AttachmentID', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'AttachmentID'
GO

EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'CreaterID'
GO

EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'CreaterName'
GO

EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'CreateTime'
GO

EXEC sp_addextendedproperty N'MS_Description', '描述信息', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'Description'
GO

EXEC sp_addextendedproperty N'MS_Description', '下载数', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'DownLoadCount'
GO

EXEC sp_addextendedproperty N'MS_Description', '附件扩展名(不含点)', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'Ext'
GO

EXEC sp_addextendedproperty N'MS_Description', '附件大小（kb）', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'FileSize'
GO

EXEC sp_addextendedproperty N'MS_Description', '所属商户号', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'FK_MerchantID'
GO

EXEC sp_addextendedproperty N'MS_Description', '附件格式类型(AttachmentFormatTypeEnum)', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'FormatType'
GO

EXEC sp_addextendedproperty N'MS_Description', '图片高度（如果是图片）', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'ImgHeight'
GO

EXEC sp_addextendedproperty N'MS_Description', '图片宽度（如果是图片）', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'ImgWidth'
GO

EXEC sp_addextendedproperty N'MS_Description', '原始文件名', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'OriginFileName'
GO

EXEC sp_addextendedproperty N'MS_Description', '主附件ID', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'ParentID'
GO

EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'RecordState'
GO

EXEC sp_addextendedproperty N'MS_Description', '附件标题', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'Title'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'UpdaterID'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'UpdaterName'
GO

EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'UpdateTime'
GO

EXEC sp_addextendedproperty N'MS_Description', '相对路径', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'URL'
GO

EXEC sp_addextendedproperty N'MS_Description', '查看数', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'ViewCount'
GO

EXEC sp_addextendedproperty N'MS_Description', '附件查看类型(AttachmentViewTypeEnum)', 'SCHEMA', N'dbo', 'TABLE', N'Attachment', 'COLUMN', N'ViewType'
GO

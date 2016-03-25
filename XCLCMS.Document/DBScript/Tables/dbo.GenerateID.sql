CREATE TABLE [dbo].[GenerateID]
(
[IDType] [char] (3) COLLATE Chinese_PRC_CI_AS NOT NULL,
[IDValue] [bigint] NOT NULL,
[IDCode] [bigint] NULL,
[CreateTime] [datetime] NOT NULL,
[Remark] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[GenerateID] ADD CONSTRAINT [PK_GENERATEID] PRIMARY KEY CLUSTERED  ([IDType], [IDValue]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', 'ID生成表', 'SCHEMA', N'dbo', 'TABLE', N'GenerateID', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'GenerateID', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '唯一值', 'SCHEMA', N'dbo', 'TABLE', N'GenerateID', 'COLUMN', N'IDCode'
GO
EXEC sp_addextendedproperty N'MS_Description', 'ID类型(IDTypeEnum)', 'SCHEMA', N'dbo', 'TABLE', N'GenerateID', 'COLUMN', N'IDType'
GO
EXEC sp_addextendedproperty N'MS_Description', '生成的ID值', 'SCHEMA', N'dbo', 'TABLE', N'GenerateID', 'COLUMN', N'IDValue'
GO
EXEC sp_addextendedproperty N'MS_Description', '备注', 'SCHEMA', N'dbo', 'TABLE', N'GenerateID', 'COLUMN', N'Remark'
GO

CREATE TABLE [dbo].[MerchantApp]
(
[MerchantAppID] [bigint] NOT NULL,
[MerchantAppName] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL,
[FK_MerchantID] [bigint] NOT NULL,
[Remark] [varchar] (1000) COLLATE Chinese_PRC_CI_AS NULL,
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NOT NULL,
[CreateTime] [datetime] NOT NULL,
[CreaterID] [bigint] NOT NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NOT NULL,
[UpdaterID] [bigint] NOT NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MerchantApp] ADD CONSTRAINT [PK_MERCHANTAPP] PRIMARY KEY CLUSTERED  ([MerchantAppID]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', '商户应用表', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', 'COLUMN', N'CreaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', 'COLUMN', N'CreaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '所属商户ID', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', 'COLUMN', N'FK_MerchantID'
GO
EXEC sp_addextendedproperty N'MS_Description', '商户应用ID', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', 'COLUMN', N'MerchantAppID'
GO
EXEC sp_addextendedproperty N'MS_Description', '商户应用名', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', 'COLUMN', N'MerchantAppName'
GO
EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', 'COLUMN', N'RecordState'
GO
EXEC sp_addextendedproperty N'MS_Description', '备注', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', 'COLUMN', N'Remark'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', 'COLUMN', N'UpdaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', 'COLUMN', N'UpdaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'MerchantApp', 'COLUMN', N'UpdateTime'
GO

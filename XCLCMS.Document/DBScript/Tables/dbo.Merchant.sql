CREATE TABLE [dbo].[Merchant]
(
[MerchantID] [bigint] NOT NULL,
[MerchantName] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NOT NULL,
[MerchantType] [char] (1) COLLATE Chinese_PRC_CI_AS NULL,
[Domain] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[LogoURL] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[ContactName] [nvarchar] (100) COLLATE Chinese_PRC_CI_AS NULL,
[Tel] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[Landline] [varchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[Email] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL,
[QQ] [varchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[PassType] [char] (3) COLLATE Chinese_PRC_CI_AS NULL,
[PassNumber] [varchar] (100) COLLATE Chinese_PRC_CI_AS NULL,
[Address] [nvarchar] (200) COLLATE Chinese_PRC_CI_AS NULL,
[OtherContact] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[MerchantRemark] [nvarchar] (500) COLLATE Chinese_PRC_CI_AS NULL,
[RegisterTime] [datetime] NULL,
[MerchantState] [char] (1) COLLATE Chinese_PRC_CI_AS NULL,
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
ALTER TABLE [dbo].[Merchant] ADD CONSTRAINT [PK_MERCHANT] PRIMARY KEY CLUSTERED  ([MerchantID]) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_MerchantName] ON [dbo].[Merchant] ([MerchantName]) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', '商户表', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', NULL, NULL
GO
EXEC sp_addextendedproperty N'MS_Description', '地址', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'Address'
GO
EXEC sp_addextendedproperty N'MS_Description', '联系人', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'ContactName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者ID', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'CreaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建者名', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'CreaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '创建时间', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'CreateTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '绑定的域名', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'Domain'
GO
EXEC sp_addextendedproperty N'MS_Description', '电子邮件', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'Email'
GO
EXEC sp_addextendedproperty N'MS_Description', '固话', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'Landline'
GO
EXEC sp_addextendedproperty N'MS_Description', 'logo图片地址', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'LogoURL'
GO
EXEC sp_addextendedproperty N'MS_Description', '商户ID', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'MerchantID'
GO
EXEC sp_addextendedproperty N'MS_Description', '商户名', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'MerchantName'
GO
EXEC sp_addextendedproperty N'MS_Description', '商户备注信息', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'MerchantRemark'
GO
EXEC sp_addextendedproperty N'MS_Description', '商户状态(MerchantStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'MerchantState'
GO
EXEC sp_addextendedproperty N'MS_Description', '商户类型(参见字典库)', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'MerchantType'
GO
EXEC sp_addextendedproperty N'MS_Description', '其它联系信息', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'OtherContact'
GO
EXEC sp_addextendedproperty N'MS_Description', '证件号', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'PassNumber'
GO
EXEC sp_addextendedproperty N'MS_Description', '证件类型（参见字典库）', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'PassType'
GO
EXEC sp_addextendedproperty N'MS_Description', 'qq', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'QQ'
GO
EXEC sp_addextendedproperty N'MS_Description', '记录状态(RecordStateEnum)', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'RecordState'
GO
EXEC sp_addextendedproperty N'MS_Description', '注册时间', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'RegisterTime'
GO
EXEC sp_addextendedproperty N'MS_Description', '备注', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'Remark'
GO
EXEC sp_addextendedproperty N'MS_Description', '手机', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'Tel'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人ID', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'UpdaterID'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新人名', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'UpdaterName'
GO
EXEC sp_addextendedproperty N'MS_Description', '更新时间', 'SCHEMA', N'dbo', 'TABLE', N'Merchant', 'COLUMN', N'UpdateTime'
GO

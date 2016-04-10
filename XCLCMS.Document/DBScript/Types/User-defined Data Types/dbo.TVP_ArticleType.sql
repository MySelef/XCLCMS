CREATE TYPE [dbo].[TVP_ArticleType] AS TABLE
(
[FK_ArticleID] [bigint] NULL,
[FK_TypeID] [bigint] NULL,
[RecordState] [char] (1) COLLATE Chinese_PRC_CI_AS NULL,
[CreateTime] [datetime] NULL,
[CreaterID] [bigint] NULL,
[CreaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL,
[UpdateTime] [datetime] NULL,
[UpdaterID] [bigint] NULL,
[UpdaterName] [nvarchar] (50) COLLATE Chinese_PRC_CI_AS NULL
)
GO

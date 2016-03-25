SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
--TOP n 实现的通用分页存储过程
CREATE PROC [dbo].[sp_Pager]
@tbname     nvarchar(4000),               --要分页显示的表名
@FieldKey   nvarchar(4000),      --用于定位记录的主键(惟一键)字段,可以是逗号分隔的多个字段
@PageCurrent int=1,               --要显示的页码
@PageSize   int=10,                --每页的大小(记录数)
@FieldShow nvarchar(4000)='',      --以逗号分隔的要显示的字段列表,如果不指定,则显示所有字段
@FieldOrder nvarchar(4000)='',      --以逗号分隔的排序字段列表,可以指定在字段后面指定DESC/ASC用于指定排序顺序
                                          
@Where    nvarchar(4000)='',     --查询条件
@PageCount int OUTPUT,           --总页数
@RecordCount int OUTPUT--总记录数
AS
SET NOCOUNT ON

--分页字段检查
IF ISNULL(@FieldKey,N'')=''
BEGIN
    RAISERROR(N'分页处理需要主键（或者惟一键）',1,16)
    RETURN
END

--其他参数检查及规范
IF ISNULL(@PageCurrent,0)<1 SET @PageCurrent=1
IF ISNULL(@PageSize,0)<1 SET @PageSize=10
IF ISNULL(@FieldShow,N'')=N'' SET @FieldShow=N'*'
IF ISNULL(@FieldOrder,N'')=N''
    SET @FieldOrder=N''
ELSE
    SET @FieldOrder=N'ORDER BY '+LTRIM(@FieldOrder)
IF ISNULL(@Where,N'')=N''
    SET @Where=N''
ELSE
    SET @Where=N'WHERE ('+@Where+N')'

--如果@PageCount为NULL值,则计算总页数(这样设计可以只在第一次计算总页数,以后调用时,把总页数传回给存储过程,避免再次计算总页数,对于不想计算总页数的处理而言,可以给@PageCount赋值)
IF @PageCount IS NULL
BEGIN
    DECLARE @sql nvarchar(4000)
    SET @sql=N'SELECT @PageCount=COUNT(*)'
        +N' FROM '+@tbname
        +N' '+@Where
    EXEC sp_executesql @sql,N'@PageCount int OUTPUT',@PageCount OUTPUT
    SET @PageCount=(@PageCount+@PageSize-1)/@PageSize
END

--如果@RecordCount为NULL值,则计算总记录数(这样设计可以只在第一次计算总记录数,以后调用时,把总记录数传回给存储过程,避免再次计算总记录数,对于不想计算总记录数的处理而言,可以给@RecordCount赋值)
IF @RecordCount IS NULL
BEGIN
    DECLARE @sqlRecordCount nvarchar(4000)
    SET @sqlRecordCount=N'SELECT @RecordCount=COUNT(*)'
        +N' FROM '+@tbname
        +N' '+@Where
    EXEC sp_executesql @sqlRecordCount,N'@RecordCount int OUTPUT',@RecordCount OUTPUT
    SET @RecordCount=@RecordCount
END


--限制传过来的当前页码数与实际页码总数的值，小于则为起始页，大于则为最后一页
if(@PageCurrent>1 AND @PageCurrent>@PageCount)
begin
	set @PageCurrent=@PageCount
END
IF(@PageCurrent<=0)
BEGIN
	SET @PageCurrent=1
END
-----------------------------------


--计算分页显示的TOPN值
DECLARE @TopN varchar(20),@TopN1 varchar(20)
SELECT @TopN=@PageSize,
    @TopN1=(@PageCurrent-1)*@PageSize

--第一页直接显示
IF @PageCurrent=1
    EXEC(N'SELECT TOP '+@TopN
        +N' '+@FieldShow
        +N' FROM '+@tbname
        +N' '+@Where
        +N' '+@FieldOrder)
ELSE
BEGIN
    --处理别名
    IF @FieldShow=N'*'
        SET @FieldShow=N'a.*'

    --生成主键(惟一键)处理条件
    DECLARE @Where1 nvarchar(4000),@Where2 nvarchar(4000),
        @s nvarchar(1000),@Field sysname
    SELECT @Where1=N'',@Where2=N'',@s=@FieldKey
    WHILE CHARINDEX(N',',@s)>0
        SELECT @Field=LEFT(@s,CHARINDEX(N',',@s)-1),
            @s=STUFF(@s,1,CHARINDEX(N',',@s),N''),
            @Where1=@Where1+N' AND a.'+@Field+N'=b.'+@Field,
            @Where2=@Where2+N' AND b.'+@Field+N' IS NULL',
            @Where=REPLACE(@Where,@Field,N'a.'+@Field),
            @FieldOrder=REPLACE(@FieldOrder,@Field,N'a.'+@Field),
            @FieldShow=REPLACE(@FieldShow,@Field,N'a.'+@Field)
    SELECT @Where=REPLACE(@Where,@s,N'a.'+@s),
        @FieldOrder=REPLACE(@FieldOrder,@s,N'a.'+@s),
        @FieldShow=REPLACE(@FieldShow,@s,N'a.'+@s),
        @Where1=STUFF(@Where1+N' AND a.'+@s+N'=b.'+@s,1,5,N''),    
        @Where2=CASE
            WHEN @Where='' THEN N'WHERE ('
            ELSE @Where+N' AND ('
            END+N'b.'+@s+N' IS NULL'+@Where2+N')'

    --执行查询
    exec(N'SELECT TOP '+@TopN
        +N' '+@FieldShow
        +N' FROM '+@tbname
        +N' a LEFT JOIN(SELECT TOP '+@TopN1
        +N' '+@FieldKey
        +N' FROM '+@tbname
        +N' a '+@Where
        +N' '+@FieldOrder
        +N')b ON '+@Where1
        +N' '+@Where2
        +N' '+@FieldOrder)
END
GO

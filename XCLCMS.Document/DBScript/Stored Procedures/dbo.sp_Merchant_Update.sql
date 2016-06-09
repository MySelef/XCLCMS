
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO





CREATE PROCEDURE [dbo].[sp_Merchant_Update]
@MerchantID bigint,
@MerchantName nvarchar(100),
@FK_MerchantType bigint,
@MerchantSystemType char(3),
@Domain varchar(200),
@LogoURL varchar(200),
@ContactName nvarchar(100),
@Tel varchar(200),
@Landline varchar(200),
@Email varchar(100),
@QQ varchar(50),
@FK_PassType bigint,
@PassNumber varchar(100),
@Address nvarchar(200),
@OtherContact nvarchar(500),
@MerchantRemark nvarchar(500),
@RegisterTime datetime,
@MerchantState char(1),
@Remark varchar(1000),
@RecordState char(1),
@CreateTime datetime,
@CreaterID bigint,
@CreaterName nvarchar(50),
@UpdateTime datetime,
@UpdaterID bigint,
@UpdaterName nvarchar(50),

@ResultCode INT OUTPUT,
@ResultMessage NVARCHAR(1000) OUTPUT
 AS 
BEGIN

	BEGIN TRY
		UPDATE [Merchant] SET 
		MerchantName=@MerchantName ,
		[FK_MerchantType] = @FK_MerchantType,[MerchantSystemType] = @MerchantSystemType,[Domain] = @Domain,[LogoURL] = @LogoURL,[ContactName] = @ContactName,[Tel] = @Tel,[Landline] = @Landline,[Email] = @Email,[QQ] = @QQ,[FK_PassType] = @FK_PassType,[PassNumber] = @PassNumber,[Address] = @Address,[OtherContact] = @OtherContact,[MerchantRemark] = @MerchantRemark,[RegisterTime] = @RegisterTime,[MerchantState] = @MerchantState,[Remark] = @Remark,[RecordState] = @RecordState,[CreateTime] = @CreateTime,[CreaterID] = @CreaterID,[CreaterName] = @CreaterName,[UpdateTime] = @UpdateTime,[UpdaterID] = @UpdaterID,[UpdaterName] = @UpdaterName
		WHERE MerchantID=@MerchantID

		SET @ResultCode=1
	END TRY
	BEGIN CATCH
			SET @ResultMessage= ERROR_MESSAGE() 
			SET @ResultCode=0
	END CATCH

END 





GO

CREATE   PROCEDURE SP_BindersSave
(
	@Id BIGINT = NULL,
	@BinderName NVARCHAR(50),
	@ColorId BIGINT,
	@PocketId BIGINT,
	@SetId BIGINT,
	@Sku NVARCHAR(50),
	@IsNFC BIT,
	@CreatedBy BIGINT
)
AS
BEGIN

		IF EXISTS(
			SELECT 1 FROM [Binders] WHERE Sku = LOWER(TRIM(@Sku)) AND IsDeleted = 0 AND IsActive = 1
		)
		BEGIN
			SELECT -1 AS Success, 'Binder with this SKU already exists' AS MESSAGE
			RETURN
		END

	IF(ISNULL(@Id, 0) = 0)
	BEGIN
		

		INSERT INTO [Binders] (BinderName, ColorId, PocketId, SetId, Sku, IsNFC, CreatedBy)
		VALUES ( LOWER(TRIM(@BinderName)), @ColorId, @PocketId, @SetId, LOWER(TRIM(@Sku)), @IsNFC, @CreatedBy)

		IF(@@ROWCOUNT > 0)
		BEGIN
			SELECT 1 AS Success, 'Binder saved successfully' AS MESSAGE
		END
		ELSE
		BEGIN
			SELECT 0 AS Success, 'Binder save failed' AS MESSAGE
		END
	END
	ELSE
	BEGIN

		UPDATE [Binders]
		SET BinderName = LOWER(TRIM(@BinderName)),
			ColorId = @ColorId,
			PocketId = @PocketId,
			SetId = @SetId,
			Sku = LOWER(TRIM(@Sku)),
			IsNFC = @IsNFC,
			UpdatedAt = GETUTCDATE(),
			UpdatedBy = @CreatedBy
		WHERE Id = @Id

		IF(@@ROWCOUNT > 0)
		BEGIN
			SELECT 1 AS Success, 'Binder updated successfully' AS MESSAGE
		END
		ELSE
		BEGIN
			SELECT 0 AS Success, 'Binder update failed' AS MESSAGE
		END
	END
END
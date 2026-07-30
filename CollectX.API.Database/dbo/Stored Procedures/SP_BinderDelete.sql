
CREATE   PROCEDURE SP_BinderDelete
(
	@Id BIGINT,
	@CreatedBy BIGINT
)
AS
BEGIN
	UPDATE [Binders]
	SET IsDeleted = 1,IsActive=0,
		UpdatedAt = GETUTCDATE(),
		UpdatedBy = @CreatedBy
	WHERE Id = @Id AND IsDeleted = 0 AND IsActive = 1

	IF(@@ROWCOUNT > 0)
	BEGIN
		SELECT 1 AS Success, 'Binder deleted successfully' AS MESSAGE
	END
	ELSE
	BEGIN
		SELECT 0 AS Success, 'Binder delete failed' AS MESSAGE
	END
END
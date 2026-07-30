CREATE   PROCEDURE SP_ChangePassword
	@UserId BIGINT,
	@NewPassword NVARCHAR(MAX)
AS
BEGIN

	UPDATE USERS 
	SET [Password] = @NewPassword, UpdatedAt = GETUTCDATE()
	WHERE Id = @UserId AND IsActive = 1;

	IF(@@ROWCOUNT > 0)
	BEGIN
		SELECT 1 AS Success, 'Password reset successful.' AS [Message];
	END
	ELSE
	BEGIN
		SELECT 0 AS Success, 'Password reset failed. User not found.' AS [Message];
	END
END
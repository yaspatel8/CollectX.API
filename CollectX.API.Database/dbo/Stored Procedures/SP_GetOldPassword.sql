CREATE   PROCEDURE SP_GetOldPassword
	@UserId BIGINT
AS
BEGIN
	select [Password] from USERS where Id = @UserId and IsActive = 1;
END
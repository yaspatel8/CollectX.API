CREATE PROCEDURE SP_GetUserDetails 
	@UserId BIGINT
AS
BEGIN
	SELECT u.Id AS UserId, u.FirstName, u.LastName, u.Email, u.PhoneNumber, u.Address,u.ImagePath
	FROM USERS u
	WHERE u.Id = @UserId AND u.IsDeleted = 0;

END
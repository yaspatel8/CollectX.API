CREATE   PROCEDURE SP_UserLogin
	@Email NVARCHAR(MAX)      
AS  
BEGIN  
	DECLARE @UserId BIGINT;
	DECLARE @Role NVARCHAR(50);
	DECLARE @Password NVARCHAR(MAX);
	
	SELECT TOP 1 @UserId = u.Id,@Role= r.RoleName, @Password = u.[Password]
	FROM USERS u
	INNER JOIN roles r ON u.RoleId = r.Id
	WHERE LOWER(u.Email) = LOWER(@Email)   
	  AND u.IsDeleted = 0 AND u.IsActive = 1;  
	
	IF(ISNULL(@UserId,0) = 0)
	BEGIN  
		SELECT 0 AS Success, 'Invalid email id or password.' AS [Message];  
		RETURN;  
	END  
	 
	IF EXISTS (  
	 SELECT 1   
	 FROM [USERS]   
	 WHERE Id = @UserId AND IsActive = 0  
	)  
	BEGIN  
		SELECT 0 AS Success, 'Your account has been inactivated, please contact the admin.' AS [Message];  
		RETURN;  
	END 
	
	IF EXISTS (  
	 SELECT 1
	 FROM [USERS]
	 WHERE Id = @UserId AND IsActive = 1  
	)  
	BEGIN  
		SELECT 1 AS Success, 'Login successful.' AS [Message], @UserId AS UserId, @Role AS Role, @Password AS Password;
	END
END
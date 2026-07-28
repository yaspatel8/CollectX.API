CREATE   PROCEDURE SP_UserLogin
	@Email NVARCHAR(MAX),      
    @Password NVARCHAR(MAX)  
AS  
BEGIN  
	DECLARE @UserId BIGINT;  
  
	SELECT TOP 1 @UserId = Id   
	FROM USERS  
	WHERE LOWER(Email) = LOWER(@Email)   
	  AND [Password] = @Password   
	  AND IsDeleted = 0 AND IsActive = 1;  
	
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
		SELECT 1 AS Success, 'Login successful.' AS [Message], @UserId AS UserId, FirstName, LastName, Email,PhoneNumber,Address
		FROM [USERS]
		WHERE Id = @UserId;
	END
END
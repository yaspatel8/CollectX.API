CREATE   PROCEDURE SP_EditProfile
(
	@Id BIGINT = NULL,
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Email NVARCHAR(100),
	@PhoneNumber NVARCHAR(15),
	@Address NVARCHAR(MAX),
	@Image NVARCHAR(MAX) = NULL,
	@OldFileName NVARCHAR(200) OUTPUT,
	@UpdatedBy BIGINT
)
AS
BEGIN
	IF EXISTS(
		SELECT 1 FROM USERS WHERE Email=LOWER(TRIM(@Email)) AND Id <> @Id
	)
	BEGIN
        SELECT -1 AS Success,
               'Email already exists' AS Message;
        RETURN;
    END
 
	IF EXISTS (
        SELECT 1
        FROM USERS
        WHERE PhoneNumber = @PhoneNumber AND Id <> @Id
    )
    BEGIN
        SELECT -1 AS Success,
               'Phone number already exists' AS Message;
        RETURN;
    END
 
	SELECT @OldFileName = ImagePath
		FROM USERS
		WHERE Id=@Id;

	UPDATE USERS 
	SET 
		FirstName=@FirstName,
		LastName=@LastName,
		Email=@Email,
		PhoneNumber=@PhoneNumber,
		Address=@Address,
		ImagePath=ISNULL(@Image,ImagePath),
		UpdatedBy=@UpdatedBy,
		UpdatedAt=GETUTCDATE()
	WHERE Id=@Id;

	IF @@ROWCOUNT > 0
	BEGIN
		SELECT 1 AS  Success,
	              'Updated Sucess' AS Message
	END
	ELSE
	BEGIN
		SELECT 0 AS  Success,
	              'Updated Fail' AS Message
	END
END
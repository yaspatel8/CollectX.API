
CREATE   PROCEDURE SP_SetsGetAll
AS
BEGIN
	SELECT Id, Name, Image, CardSize,IsActive
	FROM [Sets]
	WHERE IsDeleted = 0 AND IsActive = 1
END
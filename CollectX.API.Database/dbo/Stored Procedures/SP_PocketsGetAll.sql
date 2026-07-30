
CREATE   PROCEDURE SP_PocketsGetAll
AS
BEGIN
	SELECT Id, PocketSize,IsActive
	FROM Pockets
	WHERE IsDeleted = 0 AND IsActive = 1
END
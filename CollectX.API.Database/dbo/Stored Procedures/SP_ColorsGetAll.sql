CREATE   PROCEDURE SP_ColorsGetAll
AS
BEGIN
	SELECT Id, Name, hex_code,IsActive
	FROM Colors
	WHERE IsDeleted = 0 AND IsActive = 1

END
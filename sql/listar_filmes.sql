CREATE PROCEDURE sp_listar_filmes
AS
BEGIN
    SET NOCOUNT ON;

    SELECT titulo
    FROM Filme;
END;
CREATE PROCEDURE sp_popular_sessoes
    @titulo VARCHAR(255),
    @data DATE,
    @horario TIME
AS
BEGIN
    SET NOCOUNT ON;
    -- Verificar se o filme existe pelo t�tulo
    IF EXISTS (SELECT 1 FROM Filme WHERE titulo = @titulo)
    BEGIN
        -- Obter o ID do filme com base no t�tulo
        DECLARE @filme_id INT;
        SELECT @filme_id = filme_id FROM Filme WHERE titulo = @titulo;
        -- Inserir uma nova sess�o na tabela Sessao
        INSERT INTO Sessao (filme_id, data, horario)
        VALUES (@filme_id, @data, @horario);
        -- Mensagem de sucesso
        PRINT 'Sess�o inserida com sucesso.';
    END
    ELSE
    BEGIN
        -- Filme n�o encontrado
        PRINT 'O filme especificado n�o existe.';
    END
END
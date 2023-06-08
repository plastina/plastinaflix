CREATE PROCEDURE sp_popular_filmes
    @titulo VARCHAR(255),
    @descricao VARCHAR(255),
    @duracao VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    -- Verificar se o filme j� existe pelo t�tulo
    IF NOT EXISTS (SELECT 1 FROM Filme WHERE titulo = @titulo)
    BEGIN
        -- Inserir um novo filme na tabela Filme
        INSERT INTO Filme (titulo, descricao, duracao)
        VALUES (@titulo, @descricao, @duracao);
        -- Mensagem de sucesso
        PRINT 'Filme inserido com sucesso.';
    END
    ELSE
    BEGIN
        -- Filme com o mesmo t�tulo j� existe
        PRINT 'Um filme com o mesmo t�tulo j� existe.';
    END
END
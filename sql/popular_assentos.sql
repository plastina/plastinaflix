CREATE PROCEDURE sp_popular_assentos
    @linha VARCHAR(10),
    @coluna VARCHAR(10),
    @sala_id INT
AS
BEGIN
    SET NOCOUNT ON;
    -- Verificar se a sala existe pelo ID
    IF EXISTS (SELECT 1 FROM Sala WHERE sala_id = @sala_id)
    BEGIN
        -- Inserir um novo assento na tabela Assento
        INSERT INTO Assento (sala_id, linha, coluna)
        VALUES (@sala_id, @linha, @coluna);
        -- Mensagem de sucesso
        PRINT 'Assento inserido com sucesso.';
    END
    ELSE
    BEGIN
        -- Sala não encontrada
        PRINT 'A sala especificada não existe.';
    END
END
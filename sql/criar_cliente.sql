CREATE PROCEDURE sp_criar_cliente
    @nome VARCHAR(100),
    @email VARCHAR(100),
    @telefone VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar se o cliente j� existe pelo endere�o de e-mail
    IF NOT EXISTS (SELECT 1 FROM Cliente WHERE email = @email)
    BEGIN
        INSERT INTO Cliente (nome, email, telefone)
        VALUES (@nome, @email, @telefone);
        -- Mensagem de sucesso
        PRINT 'Cliente criado com sucesso.';
    END
    ELSE
    BEGIN
        -- Cliente j� existe com o mesmo e-mail
        PRINT 'Um cliente com o mesmo endere�o de e-mail j� existe.';
    END
END;
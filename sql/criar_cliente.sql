CREATE PROCEDURE sp_criar_cliente
    @nome VARCHAR(100),
    @email VARCHAR(100),
    @telefone VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar se o cliente já existe pelo endereço de e-mail
    IF NOT EXISTS (SELECT 1 FROM Cliente WHERE email = @email)
    BEGIN
        INSERT INTO Cliente (nome, email, telefone)
        VALUES (@nome, @email, @telefone);
        -- Mensagem de sucesso
        PRINT 'Cliente criado com sucesso.';
    END
    ELSE
    BEGIN
        -- Cliente já existe com o mesmo e-mail
        PRINT 'Um cliente com o mesmo endereço de e-mail já existe.';
    END
END;
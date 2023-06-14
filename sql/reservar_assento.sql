CREATE PROCEDURE sp_reservar_assento
    @assento_id INT,
    @nome VARCHAR(100)
AS
BEGIN
    SET XACT_ABORT ON; -- Garante o rollback autom�tico da transa��o em caso de erro

    BEGIN TRANSACTION; -- Inicia a transa��o

    BEGIN TRY
        -- Verifica se o assento existe
        IF NOT EXISTS (SELECT 1 FROM Assento WHERE assento_id = @assento_id)
        BEGIN
            RAISERROR('O assento especificado n�o existe.', 16, 1);
            RETURN;
        END
		
        -- Verifica se o assento est� dispon�vel
        DECLARE @status BIT;

        SELECT @status = STATUS
        FROM Reserva
        WHERE assento_id = @assento_id;

        IF @status = 1
        BEGIN
            RAISERROR('O assento n�o est� dispon�vel para reserva.', 16, 1);
            RETURN;
        END
		
        -- Verifica se o cliente j� existe na tabela Cliente
        DECLARE @cliente_id INT;

        SELECT @cliente_id = cliente_id
        FROM Cliente
        WHERE nome = @nome;

        IF @cliente_id IS NULL
        BEGIN
            -- Insere o cliente na tabela Cliente
            INSERT INTO Cliente (nome)
            VALUES (@nome);

            -- Obt�m o ID do cliente rec�m-inserido
            SET @cliente_id = SCOPE_IDENTITY();
        END
        ELSE
        BEGIN
            -- Verifica se o cliente j� possui reserva para o assento
            IF EXISTS (SELECT 1 FROM Reserva WHERE assento_id = @assento_id AND cliente_id = @cliente_id)
            BEGIN
                RAISERROR('O cliente j� possui uma reserva para este assento.', 16, 1);
                RETURN;
            END
        END

        -- Insere a reserva na tabela Reserva
        INSERT INTO Reserva (assento_id, cliente_id, STATUS)
        VALUES (@assento_id, @cliente_id, 1);

        COMMIT; -- Confirma a transa��o
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK; -- Realiza o rollback da transa��o em caso de erro

        THROW; -- Propaga o erro para a aplica��o
    END CATCH
END;

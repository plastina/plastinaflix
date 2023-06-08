CREATE PROCEDURE sp_reservar_assento
    @assento_id INT
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
        FROM Sessao
        WHERE sessao_id = @assento_id;

        IF @status = 0
        BEGIN
            RAISERROR('O assento n�o est� dispon�vel para reserva.', 16, 1);
            RETURN;
        END

        -- Verifica se o assento j� est� reservado por outro cliente
        IF EXISTS (SELECT 1 FROM Reserva WHERE assento_id = @assento_id)
        BEGIN
            RAISERROR('O assento j� est� reservado por outro cliente.', 16, 1);
            RETURN;
        END

        -- Insere a reserva na tabela Reserva
        INSERT INTO Reserva (assento_id, STATUS)
        VALUES (@assento_id, 0);

        COMMIT; -- Confirma a transa��o
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK; -- Realiza o rollback da transa��o em caso de erro

        THROW; -- Propaga o erro para a aplica��o
    END CATCH
END;
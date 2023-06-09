CREATE PROCEDURE sp_reservar_assento
    @assento_id INT
AS
BEGIN
    SET XACT_ABORT ON; -- Garante o rollback automático da transação em caso de erro

    BEGIN TRANSACTION; -- Inicia a transação

    BEGIN TRY
        -- Verifica se o assento existe
        IF NOT EXISTS (SELECT 1 FROM Assento WHERE assento_id = @assento_id)
        BEGIN
            RAISERROR('O assento especificado não existe.', 16, 1);
            RETURN;
        END
		
        -- Verifica se o assento está disponível
        DECLARE @status BIT;

        SELECT @status = STATUS
        FROM Reserva
        WHERE assento_id = @assento_id;

        IF @status = 1
        BEGIN
            RAISERROR('O assento não está disponível para reserva.', 16, 1);
            RETURN;
        END
		     

        -- Insere a reserva na tabela Reserva
        INSERT INTO Reserva (assento_id, STATUS)
        VALUES (@assento_id, 1);

        COMMIT; -- Confirma a transação
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK; -- Realiza o rollback da transação em caso de erro

        THROW; -- Propaga o erro para a aplicação
    END CATCH
END;
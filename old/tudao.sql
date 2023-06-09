CREATE DATABASE CinemaDB

-- Tabela Filme
CREATE TABLE Filme (
    filme_id INT IDENTITY(1,1) PRIMARY KEY,
    titulo VARCHAR(255),
    descricao VARCHAR(255),
    duracao VARCHAR(50)
);

-- Tabela Sala
CREATE TABLE Sala (
    sala_id INT IDENTITY(1,1) PRIMARY KEY,
    numero VARCHAR(10),
    capacidade INT,
    CONSTRAINT UQ_Sala_Numero UNIQUE (numero) -- Restrição UNIQUE no número da sala
);

-- Tabela Sessao
CREATE TABLE Sessao (
    sessao_id INT IDENTITY(1,1) PRIMARY KEY,
    filme_id INT,
    sala_id INT,
    data DATE,
    horario TIME,
    STATUS BIT,
    FOREIGN KEY (filme_id) REFERENCES Filme(filme_id),
    FOREIGN KEY (sala_id) REFERENCES Sala(sala_id),
    CONSTRAINT UQ_Sessao_Sala_Data_Horario UNIQUE (sala_id, data, horario) -- Restrição UNIQUE na combinação de sala, data e horário
);

-- Tabela Assento
CREATE TABLE Assento (
    assento_id INT IDENTITY(1,1) PRIMARY KEY,
    sala_id INT,
    linha VARCHAR(10),
    coluna VARCHAR(10),
    FOREIGN KEY (sala_id) REFERENCES Sala(sala_id),
    CONSTRAINT UQ_Assento_Sala_Linha_Coluna UNIQUE (sala_id, linha, coluna) -- Restrição UNIQUE na combinação de sala, linha e coluna
);

-- Tabela Cliente
CREATE TABLE Cliente (
    cliente_id INT IDENTITY(1,1) PRIMARY KEY,
    nome VARCHAR(100),
    email VARCHAR(100),
    telefone VARCHAR(20)
);

-- Tabela Reserva
CREATE TABLE Reserva (
    reserva_id INT IDENTITY(1,1) PRIMARY KEY,
    sessao_id INT,
    assento_id INT,
    cliente_id INT,
    STATUS BIT,
    FOREIGN KEY (sessao_id) REFERENCES Sessao(sessao_id),
    FOREIGN KEY (assento_id) REFERENCES Assento(assento_id),
    FOREIGN KEY (cliente_id) REFERENCES Cliente(cliente_id)
);










--Parte 2
CREATE PROCEDURE sp_popular_filmes
    @titulo VARCHAR(255),
    @descricao VARCHAR(255),
    @duracao VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    -- Verificar se o filme já existe pelo título
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
        -- Filme com o mesmo título já existe
        PRINT 'Um filme com o mesmo título já existe.';
    END
END



CREATE PROCEDURE sp_popular_sessoes
    @titulo VARCHAR(255),
    @data DATE,
    @horario TIME
AS
BEGIN
    SET NOCOUNT ON;
    -- Verificar se o filme existe pelo título
    IF EXISTS (SELECT 1 FROM Filme WHERE titulo = @titulo)
    BEGIN
        -- Obter o ID do filme com base no título
        DECLARE @filme_id INT;
        SELECT @filme_id = filme_id FROM Filme WHERE titulo = @titulo;
        -- Inserir uma nova sessão na tabela Sessao
        INSERT INTO Sessao (filme_id, data, horario)
        VALUES (@filme_id, @data, @horario);
        -- Mensagem de sucesso
        PRINT 'Sessão inserida com sucesso.';
    END
    ELSE
    BEGIN
        -- Filme não encontrado
        PRINT 'O filme especificado não existe.';
    END
END



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



--Parte 3



CREATE PROCEDURE sp_reservar_assento
    @sessao_id INT,
    @assento_id INT,
    @cliente_id INT
AS
BEGIN
    SET XACT_ABORT ON; -- Garante o rollback automático da transação em caso de erro

    BEGIN TRANSACTION; -- Inicia a transação

    BEGIN TRY
        -- Verifica se a sessão existe
        IF NOT EXISTS (SELECT 1 FROM Sessao WHERE sessao_id = @sessao_id)
        BEGIN
            RAISERROR('A sessão especificada não existe.', 16, 1);
            RETURN;
        END

        -- Verifica se o assento existe
        IF NOT EXISTS (SELECT 1 FROM Assento WHERE assento_id = @assento_id)
        BEGIN
            RAISERROR('O assento especificado não existe.', 16, 1);
            RETURN;
        END

        -- Verifica se o cliente existe
        IF NOT EXISTS (SELECT 1 FROM Cliente WHERE cliente_id = @cliente_id)
        BEGIN
            RAISERROR('O cliente especificado não existe.', 16, 1);
            RETURN;
        END

        -- Verifica se o assento está disponível
        DECLARE @status BIT;

        SELECT @status = STATUS
        FROM Sessao
        WHERE sessao_id = @sessao_id;

        IF @status = 0
        BEGIN
            RAISERROR('O assento não está disponível para reserva.', 16, 1);
            RETURN;
        END

        -- Verifica se o assento já está reservado por outro cliente na mesma sessão
        IF EXISTS (SELECT 1 FROM Reserva WHERE sessao_id = @sessao_id AND assento_id = @assento_id)
        BEGIN
            RAISERROR('O assento já está reservado por outro cliente.', 16, 1);
            RETURN;
        END

        -- Insere a reserva na tabela Reserva
        INSERT INTO Reserva (sessao_id, assento_id, cliente_id, STATUS)
        VALUES (@sessao_id, @assento_id, @cliente_id, 0);

        COMMIT; -- Confirma a transação
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK; -- Realiza o rollback da transação em caso de erro

        THROW; -- Propaga o erro para a aplicação
    END CATCH
END;




CREATE PROCEDURE sp_listar_filmes
AS
BEGIN
    SET NOCOUNT ON;

    SELECT titulo
    FROM Filme;
END;





-- Inserção de dados na tabela Filme
INSERT INTO Filme (titulo, descricao, duracao)
VALUES ('Filme 1', 'Descrição do Filme 1', '2h 30min'),
       ('Filme 2', 'Descrição do Filme 2', '1h 45min'),
       ('Filme 3', 'Descrição do Filme 3', '2h');

-- Inserção de dados na tabela Sala
INSERT INTO Sala (numero, capacidade)
VALUES ('Sala 1', 20),
       ('Sala 2', 80),
       ('Sala 3', 120);

-- Inserção de dados na tabela Sessao
INSERT INTO Sessao (filme_id, sala_id, data, horario, STATUS)
VALUES (1, 1, '2023-05-19', '14:00:00', 1);

-- Inserção de dados na tabela Assento
INSERT INTO Assento (sala_id, linha, coluna)
VALUES (1, 'A', '1'),
       (1, 'A', '2'),
       (1, 'A', '3'),
       (1, 'A', '4'),
       (1, 'A', '5'),
       (1, 'B', '6'),
       (1, 'B', '7'),
       (1, 'B', '8'),
       (1, 'B', '9'),
	   (1, 'B', '10'),
       (1, 'C', '11'),
       (1, 'C', '12'),
       (1, 'C', '13'),
       (1, 'C', '14'),
       (1, 'C', '15'),
       (1, 'D', '16'),
       (1, 'D', '17'),
	   (1, 'D', '18'),
       (1, 'D', '19'),
	   (1, 'D', '20');

-- Inserção de dados na tabela Cliente
INSERT INTO Cliente (nome, email, telefone)
VALUES ('BP', 'cliente1@example.com', '1234567890'),
       ('Piruzin', 'cliente2@example.com', '9876543210');

-- Inserção de dados na tabela Reserva
INSERT INTO Reserva (sessao_id, assento_id, cliente_id, STATUS)
VALUES (1, 1, 1, 0),
       (1, 4, 2, 0);
-- Inserção de dados na tabela Filme
INSERT INTO Filme (titulo, descricao, duracao)
VALUES ('Filme 1', 'Descrição do Filme 1', '2h 30min'),
       ('Filme 2', 'Descrição do Filme 2', '1h 45min'),
       ('Filme 3', 'Descrição do Filme 3', '2h');

-- Inserção de dados na tabela Sala
INSERT INTO Sala (numero, capacidade)
VALUES ('Sala 1', 100),
       ('Sala 2', 80),
       ('Sala 3', 120);

-- Inserção de dados na tabela Sessao
INSERT INTO Sessao (filme_id, sala_id, data, horario, STATUS)
VALUES (1, 1, '2023-05-19', '14:00:00', 1);

-- Inserção de dados na tabela Assento
INSERT INTO Assento (sala_id, linha, coluna)
VALUES (1, 'A', '1'),
       (1, 'A', '2'),
       (1, 'B', '1'),
       (2, 'A', '1'),
       (2, 'A', '2'),
       (2, 'B', '1'),
       (3, 'A', '1'),
       (3, 'A', '2'),
       (3, 'B', '1');

-- Inserção de dados na tabela Cliente
INSERT INTO Cliente (nome, email, telefone)
VALUES ('BP', 'cliente1@example.com', '1234567890'),
       ('Gabi', 'cliente2@example.com', '9876543210');

-- Inserção de dados na tabela Reserva
INSERT INTO Reserva (sessao_id, assento_id, cliente_id, STATUS)
VALUES (1, 1, 1, 0),
       (1, 4, 2, 0);

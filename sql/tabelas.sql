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
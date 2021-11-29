CREATE DATABASE SenaiChamados;
USE SenaiChamados;

CREATE TABLE TipoUsuario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Descricao VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Setor (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Descricao VARCHAR(50) UNIQUE NOT NULL
);

CREATE TABLE Usuario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    IdTipoUsuario INT,
    IdSetor INT,
    Nome VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    Senha VARCHAR(50) NOT NULL,
    Telefone CHAR(15) NOT NULL,
    FOREIGN KEY (IdTipoUsuario)
        REFERENCES TipoUsuario (Id),
    FOREIGN KEY (IdSetor)
        REFERENCES Setor (Id)
);

CREATE TABLE Material (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    Descricao VARCHAR(50) NOT NULL,
    Tipo VARCHAR(50) NOT NULL,
    Quantidade VARCHAR(50) NOT NULL
);

CREATE TABLE Prioridade (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Descricao VARCHAR(30) NOT NULL
);

CREATE TABLE StatusChamado (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Descricao VARCHAR(30) NOT NULL
);

CREATE TABLE Chamado (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    IdPrioridade INT,
    IdStatus INT,
    IdAutor INT,
    IdResponsavel INT,
    Descricao VARCHAR(50) NOT NULL,
    Lugar VARCHAR(50) UNIQUE NOT NULL,
    DataAbertura DATE NOT NULL,
    DataDeFinalicao DATE NOT NULL,
    FOREIGN KEY (IdPrioridade)
        REFERENCES Prioridade (Id),
    FOREIGN KEY (IdStatus)
        REFERENCES StatusChamado (Id),
    FOREIGN KEY (IdAutor)
        REFERENCES Usuario (Id),
    FOREIGN KEY (IdResponsavel)
        REFERENCES Usuario (Id)
);

CREATE TABLE RegistroMateriais (
    IdMaterial INT,
    IdChamado INT,
    Quantidade INT,
    FOREIGN KEY (IdMaterial)
        REFERENCES Material (Id),
    FOREIGN KEY (IdChamado)
        REFERENCES Chamado (Id)
);
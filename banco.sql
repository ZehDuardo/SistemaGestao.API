-- =============================================
-- ESTACIONAMENTO CENTRAL PARK
-- Script de criação do banco de dados
-- =============================================

-- 1. Criar o banco de dados
CREATE DATABASE SistemaGestao;
GO

USE SistemaGestao;
GO

-- =============================================
-- 2. Tabela de Usuários
-- =============================================
CREATE TABLE Usuarios (
    Id            INT IDENTITY(1,1) PRIMARY KEY,
    Nome          NVARCHAR(100) NOT NULL,
    Email         NVARCHAR(100) NOT NULL,
    SenhaHash     NVARCHAR(255) NOT NULL,
    DataCadastro  DATETIME2     NOT NULL DEFAULT GETDATE(),
    Ativo         BIT           NOT NULL DEFAULT 1,
    IsAdmin       BIT           NOT NULL DEFAULT 0
);
GO

-- =============================================
-- 3. Tabela de Veículos
-- =============================================
CREATE TABLE Veiculos (
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    Tipo         NVARCHAR(50)  NOT NULL,
    Placa        NVARCHAR(20)  NOT NULL,
    Modelo       NVARCHAR(100) NOT NULL,
    Cor          NVARCHAR(50)  NOT NULL,
    DataCadastro DATETIME2     NOT NULL DEFAULT GETDATE()
);
GO

-- =============================================
-- 4. Tabela de Clientes
-- =============================================
CREATE TABLE Clientes (
    Id           INT IDENTITY(1,1) PRIMARY KEY,
    Nome         NVARCHAR(100) NOT NULL,
    CPF          NVARCHAR(20)  NOT NULL,
    Telefone     NVARCHAR(20)  NOT NULL,
    Email        NVARCHAR(100) NOT NULL,
    DataCadastro DATETIME2     NOT NULL DEFAULT GETDATE()
);
GO

-- =============================================
-- 5. Tabela de Ocupações (Entradas e Saídas)
-- =============================================
CREATE TABLE Ocupacoes (
    Id          INT IDENTITY(1,1) PRIMARY KEY,
    NumeroVaga  INT       NOT NULL,
    VeiculoId   INT       NOT NULL,
    ClienteId   INT       NOT NULL,
    DataEntrada DATETIME2 NOT NULL DEFAULT GETDATE(),
    DataSaida   DATETIME2 NULL,
    FOREIGN KEY (VeiculoId) REFERENCES Veiculos(Id),
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);
GO

-- =============================================
-- 6. Criar usuário Admin padrão
-- Usuário: admin
-- Senha:   admin123
-- =============================================
INSERT INTO Usuarios (Nome, Email, SenhaHash, DataCadastro, Ativo, IsAdmin)
VALUES (
    'Administrador',
    'admin',
    '240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9',
    GETDATE(),
    1,
    1
);
GO

-- =============================================
-- Pronto! Banco criado com sucesso.
-- Acesse o sistema em: http://localhost:5105
-- Login: admin | Senha: admin123
-- =============================================

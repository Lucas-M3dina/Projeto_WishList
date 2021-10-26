create database WishList;
GO

USE WishList;
GO

CREATE TABLE Usuario(
IdUsuario INT PRIMARY KEY IDENTITY,
email VARCHAR(200),
senha VARCHAR(200),
);
GO

CREATE TABLE Desejo(
IdDesejo INT PRIMARY KEY IDENTITY,
IdUsuario INT FOREIGN KEY REFERENCES Usuario (IdUsuario),
descricao VARCHAR(200)
);
GO

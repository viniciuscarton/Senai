--criação do banco de dados
CREATE DATABASE TesteSegurancaBE12;

USE TesteSegurancaBE12;

CREATE TABLE Usuarios
(
	Id INT PRIMARY KEY IDENTITY,
	Email VARCHAR(100) UNIQUE NOT NULL,
	Senha VARCHAR(50) NOT NULL
);

SELECT * FROM Usuarios;
INSERT INTO Usuarios VALUES ('emailteste@email.com', 1234);
INSERT INTO Usuarios VALUES ('carlinhos@email.com', '431carlos');
INSERT INTO Usuarios VALUES ('maiasol@email.com', 'aboboravermelha');
INSERT INTO Usuarios VALUES ('drhouse@email.com', 884722);

SELECT Id, Email, HASHBYTES('MD2', Senha) FROM Usuarios;
SELECT Id, Email, HASHBYTES('MD2', Senha) FROM Usuarios WHERE Id = 2; 
SELECT Id, Email, HASHBYTES('MD2', Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;
SELECT Id, Email, HASHBYTES('MD4', Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;
SELECT Id, Email, HASHBYTES('MD5', Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;
SELECT Id, Email, HASHBYTES('SHA', Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;
SELECT Id, Email, HASHBYTES('SHA1', Senha) AS 'Senha Hash' FROM Usuarios WHERE Id = 1;

--DELETE FROM Usuarios;
--DBCC CHECKIDENT (Usuarios, RESEED, 0)
--GO
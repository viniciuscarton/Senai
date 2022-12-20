--ENCONTRO REMOTO 2--
CREATE DATABASE UC13TABELAS;

USE UC13TABELAS;

CREATE TABLE Usuarios
(
	UsuarioId INT PRIMARY KEY IDENTITY,
	Usuario VARCHAR (100) UNIQUE NOT NULL,
	Senha VARCHAR (300) NOT NULL
);

CREATE TABLE Classes
(
	ClasseId INT PRIMARY KEY IDENTITY,
	NomeClasse VARCHAR (100) UNIQUE NOT NULL,
	DescricaoClasse VARCHAR (300) NOT NULL
);

CREATE TABLE Habilidade
(
	HabilidadeId INT PRIMARY KEY IDENTITY,
	Nome VARCHAR (100) UNIQUE NOT NULL,
);

CREATE TABLE Personagens
(
	PersonagensId INT PRIMARY KEY IDENTITY,
	NomePersonagem VARCHAR (50) UNIQUE NOT NULL,
	UsuarioId INT FOREIGN KEY REFERENCES Usuarios(UsuarioId), 
	ClasseId INT FOREIGN KEY REFERENCES Classes(ClasseId)
);

CREATE TABLE ClassesHabilidades
(
	ClasseId INT FOREIGN KEY REFERENCES Classes(ClasseId),
	HabilidadeId INT FOREIGN KEY REFERENCES Habilidade(HabilidadeId)
)
--ATIVIDADE ONLINE 3--
INSERT INTO Usuarios VALUES ('Mr. Fantastic', '123ABC'),('Princesa Perdida', 'luxlux'), ('Cérbero', '666#black'), ('StephenKing', 'pennywise'), ('TrollXD', 'trololo');
INSERT INTO Classes VALUES ('Mago', 'Um alquimista experiente'), ('Ninfa', 'Uma criatura de luz'), ('Guerreiro', 'Um bravo defensor'), ('Ogro', 'Um monstro imparável'), ('Ladrão', 'Um ardiloso trapaceiro');
INSERT INTO Habilidade VALUES ('Raio executor'), ('Invocação onírica'), ('Cura em área'), ('Escudo de luz'), ('Arremeço de machado'), ('Posição defensiva'), ('Avanço mortal'), ('Escudo adaptativo'), ('Salto'), ('Invisibildade');
INSERT INTO Personagens VALUES ('Soraka', 2, 2),('ReiEsquecido', 3, 3),('URGHH', 4, 4),('RobinHood', 5, 5);
INSERT INTO ClassesHabilidades VALUES (1,1), (1,2), (1,3), (2,3), (2,4), (3,5), (3,6), (4,7), (4,8), (5,9), (5,10);

--ATIVIDADE ONLINE 4--
CREATE LOGIN blizard WITH PASSWORD = 'aaaa'

CREATE USER blizard FOR LOGIN blizard;

GRANT SELECT TO blizard



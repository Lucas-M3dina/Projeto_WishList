USE WishList;
GO

INSERT INTO Usuario (nome,email,senha)
VALUES ('Guilherme Cardoso','cardoso@gmail.com','senai132'),
       ('Marcaum','marcaum@gmail.com','dev132'),
	   ('Pedro Henrique','pedro@gmail.com','fic132'),
	   ('Lucas Medina','medina@gmail.com','medina132')
GO

INSERT INTO Desejo(IdUsuario,descricao)
VALUES ('1','Virar um empresario de sucesso'),
       ('2','Comprar uma casa'),
	   ('3','Ser empregado'),
	   ('4','Ser rico')
GO

SELECT * FROM Usuario;
SELECT * FROM Desejo;
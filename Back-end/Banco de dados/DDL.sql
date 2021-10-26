USE WishList;
GO

INSERT INTO Usuario (email,senha)
VALUES ('cardoso@gmail.com','senai132'),
       ('marcaum@gmail.com','dev132'),
	   ('pedro@gmail.com','fic132'),
	   ('medina@gmail.com','medina132')
GO

INSERT INTO Desejo(IdUsuario,descricao)
VALUES ('1','Virar um empresario de sucesso'),
       ('2','Comprar uma casa'),
	   ('3','Ser empregado'),
	   ('4','Ser rico')
GO

SELECT * FROM Usuario;
SELECT * FROM Desejo;
USE WishList;
GO

--Listar todos os usu�rios;
SELECT * FROM Usuario;

--Listar todos os Desejos;
SELECT * FROM Desejo;

--Buscar um usu�rio por e-mail e senha (login);
SELECT IdUsuario,email
FROM Usuario
WHERE email = 'cardoso@gmail.com' and senha = 'senai132';
GO

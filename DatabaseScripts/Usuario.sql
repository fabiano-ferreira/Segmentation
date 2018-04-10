/*
	Script para inserir na tabela Usuario, Linha de Negocio e tabelas Auxiliares
*/

--Tabela Usuario
INSERT INTO Usuario (Nome, NomeUsuario, Senha, MudarSenha, Email, IdTipoStatusUsuario, DataCriacao, DataModificacao, LogUsuario) VALUES ('Administrador', 'admin', 'b09c600fddc573f117449b3723f23d64', 0,'email@email.com.br', 1,getdate(), getdate(), 'ADMIN')
GO

--Tabela LinhaNegocio
INSERT INTO LinhaNegocio (Nome, RazaoSocial, CNPJ, DataCriacao, DataModificacao, IdUsuario) VALUES ('EDITORA SARAIVA', 'EDITORA SARAIVA S/A', '111111111111111', getdate(), getdate(), 1)
GO

--Tabela LinhaNegocioUsuario
INSERT INTO LinhaNegocioUsuario (IdLinhaNegocio, IdUsuario) VALUES (1, 1)
GO

--Tabela LinhaNegocioProdutoNivel
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 1)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 2)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 3)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 4)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 5)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 6)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 7)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 8)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 9)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 10)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 11)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 12)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 13)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 14)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 15)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 16)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 17)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 18)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 19)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 20)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 21)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 22)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 23)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 24)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 25)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 26)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 27)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 28)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 29)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 30)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 31)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 32)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 33)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 34)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 35)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 36)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 37)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 38)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 39)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 40)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 41)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 42)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 43)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 44)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 45)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 46)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 47)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 48)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 49)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 50)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 51)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 52)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 53)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 54)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 55)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 56)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 57)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 58)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 59)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 60)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 61)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 62)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 63)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 64)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 65)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 66)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 67)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 68)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 69)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 70)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 71)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 72)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 73)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 74)
GO
INSERT INTO LinhaNegocioProdutoNivel (IdLinhaNegocio, IdProdutoNivel) VALUES (1, 75)
GO


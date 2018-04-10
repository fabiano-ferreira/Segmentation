/*
	Script para inserir nas tabelas de Dom�nio
*/

--TipoCriterioVariavel

INSERT INTO TipoCriterioVariavel (IdTipoCriterioVariavel, Descricao, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'AT�', getdate(), getdate(), 1)
GO
INSERT INTO TipoCriterioVariavel (IdTipoCriterioVariavel, Descricao, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'ENTRE', getdate(), getdate(), 1)
GO
INSERT INTO TipoCriterioVariavel (IdTipoCriterioVariavel, Descricao, DataCriacao, DataModificacao, IdUsuario) VALUES (3,'MAIOR QUE', getdate(), getdate(), 1)
GO
INSERT INTO TipoCriterioVariavel (IdTipoCriterioVariavel, Descricao, DataCriacao, DataModificacao, IdUsuario) VALUES (4,'IGUAL', getdate(), getdate(), 1)
GO
INSERT INTO TipoCriterioVariavel (IdTipoCriterioVariavel, Descricao, DataCriacao, DataModificacao, IdUsuario) VALUES (5,'MENOR QUE', getdate(), getdate(), 1)
GO

--Tipo Dado Variavel
INSERT INTO TipoDadoVariavel (IdTipoDadoVariavel, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'IMPORTADO', getdate(), getdate(), 1)
GO
INSERT INTO TipoDadoVariavel (IdTipoDadoVariavel, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'DEDUZIDO', getdate(), getdate(), 1)
GO
INSERT INTO TipoDadoVariavel (IdTipoDadoVariavel, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (3,'CALCULADO', getdate(), getdate(), 1)
GO


--Tipo Fator
INSERT INTO TipoFator (IdTipoFator, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'ATRATIVIDADE', getdate(), getdate(), 1)
GO
INSERT INTO TipoFator (IdTipoFator, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'POSICIONAMENTO', getdate(), getdate(), 1)
GO

--Tipo Operador Calculo
INSERT INTO TipoOperadorCalculo(IdTipoOperadorCalculo, Nome, Simbolo, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'SOMA', '+', getdate(), getdate(), 1)
GO
INSERT INTO TipoOperadorCalculo(IdTipoOperadorCalculo, Nome, Simbolo, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'SUBTRA��O', '-', getdate(), getdate(), 1)
GO
INSERT INTO TipoOperadorCalculo(IdTipoOperadorCalculo, Nome, Simbolo, DataCriacao, DataModificacao, IdUsuario) VALUES (3,'MULTIPLICA��O', '*', getdate(), getdate(), 1)
GO
INSERT INTO TipoOperadorCalculo(IdTipoOperadorCalculo, Nome, Simbolo, DataCriacao, DataModificacao, IdUsuario) VALUES (4,'DIVIS�O', '/', getdate(), getdate(), 1)
GO
INSERT INTO TipoOperadorCalculo(IdTipoOperadorCalculo, Nome, Simbolo, DataCriacao, DataModificacao, IdUsuario) VALUES (5,'ABRIR PAR�NTESES', '(', getdate(), getdate(), 1)
GO
INSERT INTO TipoOperadorCalculo(IdTipoOperadorCalculo, Nome, Simbolo, DataCriacao, DataModificacao, IdUsuario) VALUES (6,'FECHAR PAR�NTESES', ')', getdate(), getdate(), 1)
GO

--Tipo de Sa�da
INSERT INTO TipoSaida (IdTipoSaida, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'VARI�VEL', getdate(), getdate(), 1)
GO
INSERT INTO TipoSaida (IdTipoSaida, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'OUTPUT', getdate(), getdate(), 1)
GO
INSERT INTO TipoSaida (IdTipoSaida, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (3,'OUTPUT GLOBAL', getdate(), getdate(), 1)
GO

--Tipo de Segmento
INSERT INTO TipoSegmento (IdTipoSegmento, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'Universit�rio', getdate(), getdate(), 1)
GO
INSERT INTO TipoSegmento (IdTipoSegmento, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'Jur�dico', getdate(), getdate(), 1)
GO


--Tipo Status da Entidade
INSERT INTO TipoStatusEntidade (IdTipoStatusEntidade, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'IMPORTADO', getdate(), getdate(), 1)
GO
INSERT INTO TipoStatusEntidade (IdTipoStatusEntidade, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'SEGMENTADO', getdate(), getdate(), 1)
GO
INSERT INTO TipoStatusEntidade (IdTipoStatusEntidade, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (3,'SEGMENTO N�O ENCONTRADO', getdate(), getdate(), 1)
GO

--Tipo Status do Usu�rio
INSERT INTO TipoStatusUsuario (IdTipoStatusUsuario, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'ATIVO', getdate(), getdate(), 1)
GO
INSERT INTO TipoStatusUsuario (IdTipoStatusUsuario, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'INATIVO', getdate(), getdate(), 1)
GO

--Tipo de Variavel
INSERT INTO TipoVariavel (IdTipoVariavel, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'QUALITATIVA', getdate(), getdate(), 1)
GO
INSERT INTO TipoVariavel (IdTipoVariavel, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'QUANTITATIVA', getdate(), getdate(), 1)
GO
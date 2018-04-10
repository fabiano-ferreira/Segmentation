/*
	Script para inserir nas tabelas de Domínio
*/

--TipoCriterioVariavel

INSERT INTO TipoCriterioVariavel (IdTipoCriterioVariavel, Descricao, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'ATÉ', getdate(), getdate(), 1)
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
INSERT INTO TipoOperadorCalculo(IdTipoOperadorCalculo, Nome, Simbolo, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'SUBTRAÇÃO', '-', getdate(), getdate(), 1)
GO
INSERT INTO TipoOperadorCalculo(IdTipoOperadorCalculo, Nome, Simbolo, DataCriacao, DataModificacao, IdUsuario) VALUES (3,'MULTIPLICAÇÃO', '*', getdate(), getdate(), 1)
GO
INSERT INTO TipoOperadorCalculo(IdTipoOperadorCalculo, Nome, Simbolo, DataCriacao, DataModificacao, IdUsuario) VALUES (4,'DIVISÃO', '/', getdate(), getdate(), 1)
GO
INSERT INTO TipoOperadorCalculo(IdTipoOperadorCalculo, Nome, Simbolo, DataCriacao, DataModificacao, IdUsuario) VALUES (5,'ABRIR PARÊNTESES', '(', getdate(), getdate(), 1)
GO
INSERT INTO TipoOperadorCalculo(IdTipoOperadorCalculo, Nome, Simbolo, DataCriacao, DataModificacao, IdUsuario) VALUES (6,'FECHAR PARÊNTESES', ')', getdate(), getdate(), 1)
GO

--Tipo de Saída
INSERT INTO TipoSaida (IdTipoSaida, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'VARIÁVEL', getdate(), getdate(), 1)
GO
INSERT INTO TipoSaida (IdTipoSaida, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'OUTPUT', getdate(), getdate(), 1)
GO
INSERT INTO TipoSaida (IdTipoSaida, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (3,'OUTPUT GLOBAL', getdate(), getdate(), 1)
GO

--Tipo de Segmento
INSERT INTO TipoSegmento (IdTipoSegmento, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'Universitário', getdate(), getdate(), 1)
GO
INSERT INTO TipoSegmento (IdTipoSegmento, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'Jurídico', getdate(), getdate(), 1)
GO


--Tipo Status da Entidade
INSERT INTO TipoStatusEntidade (IdTipoStatusEntidade, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'IMPORTADO', getdate(), getdate(), 1)
GO
INSERT INTO TipoStatusEntidade (IdTipoStatusEntidade, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'SEGMENTADO', getdate(), getdate(), 1)
GO
INSERT INTO TipoStatusEntidade (IdTipoStatusEntidade, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (3,'SEGMENTO NÃO ENCONTRADO', getdate(), getdate(), 1)
GO

--Tipo Status do Usuário
INSERT INTO TipoStatusUsuario (IdTipoStatusUsuario, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'ATIVO', getdate(), getdate(), 1)
GO
INSERT INTO TipoStatusUsuario (IdTipoStatusUsuario, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'INATIVO', getdate(), getdate(), 1)
GO

--Tipo de Variavel
INSERT INTO TipoVariavel (IdTipoVariavel, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (1,'QUALITATIVA', getdate(), getdate(), 1)
GO
INSERT INTO TipoVariavel (IdTipoVariavel, Nome, DataCriacao, DataModificacao, IdUsuario) VALUES (2,'QUANTITATIVA', getdate(), getdate(), 1)
GO
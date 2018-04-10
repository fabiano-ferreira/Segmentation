/* 
Script para inserir os menus do sistema de Segmenta��o
*/

INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (1, 'Seguran�a', NULL, 0, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (2, 'Usu�rio', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (3, 'Manuten��o', '../Seguranca/ManutencaoUsuario.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (4, 'Permiss�o', '../Seguranca/PermissaoUsuario.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (5, 'Perfil', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (6, 'Manuten��o', '../Seguranca/ManutencaoPerfil.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (7, 'Permiss�o', '../Seguranca/PermissaoPerfil.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (8, 'Dados B�sicos', NULL, 1, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (9, 'Campanha', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (10, 'Manuten��o', '../DadosBasicos/CampanhaManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (11, 'V�nculo a usu�rio', '../DadosBasicos/CampanhaAssociarUsuario.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (12, 'Modelo', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (13, 'Manuten��o', '../DadosBasicos/ModeloManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (14, 'V�nculo a usu�rio', '../DadosBasicos/ModeloAssociarUsuario.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (15, 'V�nculo a Fator', NULL, 999, 0, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (16, 'V�nculo a Vari�vel', NULL, 999, 0, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (17, 'Crit�rio', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (18, 'Manuten��o', '../DadosBasicos/CriterioManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (19, 'V�nculo a Fator', '../DadosBasicos/CriterioFator.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (20, 'V�nculo a Vari�vel', '../DadosBasicos/CriterioVariavel.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (21, 'Vincular a Ader�ncia', '../DadosBasicos/CriterioAtratividade.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (22, 'Produto', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (23, 'Manuten��o de Categorias', '../DadosBasicos/ProdutosManutencaoCategorias.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (24, 'Manuten��o de Produtos', '../DadosBasicos/ProdutosManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (25, 'Ader�ncia', '../DadosBasicos/ProdutosAtratividade.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (26, 'Tipo de Segmento de Mercado', '../DadosBasicos/TipoSegmentoMercado.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (27, 'Linha de Neg�cio', '../DadosBasicos/LinhaNegocio.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (28, 'Classe de Vari�vel', '../DadosBasicos/ClasseVariavelManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (29, 'Dados Vari�veis', NULL, 2, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (30, 'Fator', '../DadosVariaveis/FatorManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (31, 'Vari�vel', '../DadosVariaveis/VariavelManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (32, 'Valor de Fator de Posicionamento', '../DadosVariaveis/FatorPosicionamentoSegmento.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (33, 'Valor de Fator de Atratividade', '../DadosVariaveis/FatorAtratividadeSegmento.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (34, 'Gera��o de Segmento', '../DadosVariaveis/GeracaoSegmentos.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (35, 'Segmenta��o de Clientes', '../DadosVariaveis/SegmentacaoClientesImportados.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (36, 'Vers�o de Fator de Posicionamento', '../DadosVariaveis/VersaoFatorPosicionamento.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (37, 'Importa��o', NULL, 3, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (38, 'Importar Clientes', '../Importacao/Clientes.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (39, 'Relat�rio', NULL, 4, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (40, 'Configura��o de Gr�fico', '../Relatorios/ConfiguracaoGrafico.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (41, 'Lista de Clientes por Segmento', '../Relatorios/ClientesSegmento.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (42, 'Matriz de Sa�da', '../Relatorios/MatrizSaida.aspx', 999, 1, getdate(), getdate(), 1)
GO
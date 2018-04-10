/* 
Script para inserir os menus do sistema de Segmentação
*/

INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (1, 'Segurança', NULL, 0, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (2, 'Usuário', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (3, 'Manutenção', '../Seguranca/ManutencaoUsuario.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (4, 'Permissão', '../Seguranca/PermissaoUsuario.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (5, 'Perfil', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (6, 'Manutenção', '../Seguranca/ManutencaoPerfil.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (7, 'Permissão', '../Seguranca/PermissaoPerfil.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (8, 'Dados Básicos', NULL, 1, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (9, 'Campanha', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (10, 'Manutenção', '../DadosBasicos/CampanhaManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (11, 'Vínculo a usuário', '../DadosBasicos/CampanhaAssociarUsuario.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (12, 'Modelo', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (13, 'Manutenção', '../DadosBasicos/ModeloManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (14, 'Vínculo a usuário', '../DadosBasicos/ModeloAssociarUsuario.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (15, 'Vínculo a Fator', NULL, 999, 0, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (16, 'Vínculo a Variável', NULL, 999, 0, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (17, 'Critério', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (18, 'Manutenção', '../DadosBasicos/CriterioManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (19, 'Vínculo a Fator', '../DadosBasicos/CriterioFator.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (20, 'Vínculo a Variável', '../DadosBasicos/CriterioVariavel.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (21, 'Vincular a Aderência', '../DadosBasicos/CriterioAtratividade.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (22, 'Produto', NULL, 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (23, 'Manutenção de Categorias', '../DadosBasicos/ProdutosManutencaoCategorias.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (24, 'Manutenção de Produtos', '../DadosBasicos/ProdutosManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (25, 'Aderência', '../DadosBasicos/ProdutosAtratividade.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (26, 'Tipo de Segmento de Mercado', '../DadosBasicos/TipoSegmentoMercado.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (27, 'Linha de Negócio', '../DadosBasicos/LinhaNegocio.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (28, 'Classe de Variável', '../DadosBasicos/ClasseVariavelManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (29, 'Dados Variáveis', NULL, 2, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (30, 'Fator', '../DadosVariaveis/FatorManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (31, 'Variável', '../DadosVariaveis/VariavelManutencao.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (32, 'Valor de Fator de Posicionamento', '../DadosVariaveis/FatorPosicionamentoSegmento.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (33, 'Valor de Fator de Atratividade', '../DadosVariaveis/FatorAtratividadeSegmento.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (34, 'Geração de Segmento', '../DadosVariaveis/GeracaoSegmentos.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (35, 'Segmentação de Clientes', '../DadosVariaveis/SegmentacaoClientesImportados.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (36, 'Versão de Fator de Posicionamento', '../DadosVariaveis/VersaoFatorPosicionamento.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (37, 'Importação', NULL, 3, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (38, 'Importar Clientes', '../Importacao/Clientes.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (39, 'Relatório', NULL, 4, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (40, 'Configuração de Gráfico', '../Relatorios/ConfiguracaoGrafico.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (41, 'Lista de Clientes por Segmento', '../Relatorios/ClientesSegmento.aspx', 999, 1, getdate(), getdate(), 1)
GO
INSERT INTO MenuAplicacao (IdMenuAplicacao, Nome, Endereco, Ordem, Exibir, DataCriacao, DataModificacao, IdUsuario) VALUES (42, 'Matriz de Saída', '../Relatorios/MatrizSaida.aspx', 999, 1, getdate(), getdate(), 1)
GO
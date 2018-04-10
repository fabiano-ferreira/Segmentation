using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;
using System.IO;

namespace BLL
{
    public class EntidadeBLL
    {
        private EntidadeDAO _entidade ;

        public EntidadeBLL()
        {
            if (_entidade == null)
                _entidade = new EntidadeDAO();
        }

        public void Novo(Entidade entidade)
        {
            _entidade.Novo(entidade);
        }

        public void Remover(Entidade entidade)
        {
            _entidade.Remover(entidade);
        }

        public void Editar(Entidade entidade)
        {
            _entidade.Editar(entidade);
        }

        public Entidade Listar(Entidade entidade)
        {
            return _entidade.Listar(entidade);
        }

        public List<Entidade> Listar()
        {
            return _entidade.Listar();
        }

        public void NovoVariavel(Entidade entidade)
        {
            _entidade.NovoVariavel(entidade);
        }

        public void RemoverVariavel(Entidade entidade)
        {
            _entidade.RemoverVariavel(entidade);
        }

        public Entidade ListarVariavel(Entidade entidade)
        {
            return _entidade.ListarVariavel(entidade);
        }

        public List<Entidade> ListarVariavel()
        {
            return _entidade.ListarVariavel();
        }

        public void LerArquivoEntidade(string arquivoLocal, Modelo entidadeModelo)
        {
            string variavel;
            int idEntidade;
            Modelo dadosModelo = new Modelo();
            ModeloBLL oModelo = new ModeloBLL();
            LogImportacaoEntidade dadosLogImportacaoEntidade = new LogImportacaoEntidade();
            LogImportacaoEntidadeBLL oLogImportacaoEntidade = new LogImportacaoEntidadeBLL();
            Entidade dadosEntidade = new Entidade();
            EntidadeBLL oEntidade = new EntidadeBLL();
            Criterio dadosCriterio = new Criterio();
            CriterioBLL oCriterio = new CriterioBLL();

            //Atribui o CSV no StreamReader passando o local do arquivo como parâmetro 
            StreamReader stream = new StreamReader(arquivoLocal);
            //Pula o Header
            string linha = stream.ReadLine();
            //Laço de cada linha
            while ((linha = stream.ReadLine()) != null)
            {
                //Quebra a linha nas colunas correspondentes que estiverem separadas por ";"
                string[] linhaSeparada = linha.Split(';');
                //Invoca método ListarVariavelImportacao passando o IdTipoDadoVariavel como importada
                dadosModelo.TipoDadoVariavel = new TipoDadoVariavel() { IDTipoDadoVariavel = 1 };
                dadosModelo = oModelo.ListarVariavelImportacao(entidadeModelo);
                //Foreach para ler cada ColunaImportacao na lista de ModelosVariaveis
                foreach (ModeloVariavel list in dadosModelo.ModeloVariavel)
                {
                    //Se valor informado estiver nulo no arquivo CSV, Criticar a mesma
                    if (linhaSeparada[list.Variavel.ColunaImportacao] == null)
                    {
                        dadosLogImportacaoEntidade.CodigoVariavel = list.Variavel.Codigo;
                        dadosLogImportacaoEntidade.DocumentoEntidade = linhaSeparada[0].ToString();
                        dadosLogImportacaoEntidade.Mensagem = "Valor de Variável não informado para a variável " + list.Variavel.IDVariavel;
                        oLogImportacaoEntidade.Novo(dadosLogImportacaoEntidade);
                    }
                    //Caso tenha conteúdo, fazer as seguintes verificações
                    else
                    {
                        //Invoca método Novo da EntidadeBLL passando as 3 primeiras colunas como parametros
                        dadosEntidade.Documento = linhaSeparada[0].ToString();
                        dadosEntidade.Nome = linhaSeparada[1].ToString();
                        dadosEntidade.Regiao = linhaSeparada[2].ToString();
                        dadosEntidade.Modelo = new Modelo() { IDModelo = entidadeModelo.IDModelo };
                        oEntidade.Novo(dadosEntidade);
                        //Atribui ao idEntidade o @@Identity do método novo
                        idEntidade = dadosEntidade.IDEntidade;
                        //Atribui a variavel o conteúdo correspondente da ColunaImportacao
                        variavel = linhaSeparada[list.Variavel.ColunaImportacao].ToString();
                        //Caso os primeiros caracteres comecem com "de"
                        if(variavel.StartsWith("de"))
                        {
                            //Quebra a Variavel para capturar os valores 1 e 2 
                            string[] variavelSeparada = variavel.Split(' ');
                            //Invoca método ListarVariavel e retorna IDCriterio
                            dadosCriterio.CriterioVariavel = new CriterioVariavel()
                            {
                                Valor1 = Convert.ToInt32(variavelSeparada[1]),
                                Valor2 = Convert.ToInt32(variavelSeparada[3])
                            };
                            dadosCriterio.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                            dadosCriterio.TipoCriterioVariavel = new TipoCriterioVariavel() { IDTipoCriterioVariavel = 2 };
                            dadosCriterio = oCriterio.ListarVariavel(dadosCriterio);
                            //Invoca método NovoVariavel da EntidadeBLL
                            dadosEntidade.Criterio = new Criterio() { IDCriterio = dadosCriterio.IDCriterio };
                            dadosEntidade.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                            dadosEntidade.IDEntidade = idEntidade;
                            oEntidade.NovoVariavel(dadosEntidade);
                        }
                        //Caso os primeiros caracteres comecem com "até"
                        else if (variavel.StartsWith("até"))
                        {
                            //Quebra a Variavel para capturar o valor 1
                            string[] variavelSeparada = variavel.Split('$');
                            //Invoca método ListarVariavel e retorna IDCriterio
                            dadosCriterio.CriterioVariavel = new CriterioVariavel()
                            {
                                Valor1 = Convert.ToDouble(variavelSeparada[1].Replace(',', '.'))
                            };
                            dadosCriterio.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                            dadosCriterio.TipoCriterioVariavel = new TipoCriterioVariavel() { IDTipoCriterioVariavel = 2 };
                            dadosCriterio = oCriterio.ListarVariavel(dadosCriterio);
                            //Invoca método NovoVariavel da EntidadeBLL
                            dadosEntidade.Criterio = new Criterio() { IDCriterio = dadosCriterio.IDCriterio };
                            dadosEntidade.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                            dadosEntidade.IDEntidade = idEntidade;
                            oEntidade.NovoVariavel(dadosEntidade);
                        }
                        //Caso seja um valor numérico
                        else if(variavel.GetType() == typeof(Int32))
                        {
                            //Invoca método ListarVariavel e retorna IDCriterio
                            dadosCriterio.CriterioVariavel = new CriterioVariavel()
                            {
                                Valor1 = Convert.ToDouble(variavel)
                            };
                            dadosCriterio.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                            dadosCriterio.TipoCriterioVariavel = new TipoCriterioVariavel() { IDTipoCriterioVariavel = 2 };
                            dadosCriterio = oCriterio.ListarVariavel(dadosCriterio);
                            //Caso o IdCriterio não seja encontrado
                            if (dadosCriterio.IDCriterio == 0)
                            {
                                //Invoca método NovoVariavel da EntidadeBLL
                                dadosEntidade.EntidadeVariavelObject = new EntidadeVariavel() { Valor = Convert.ToDouble(variavel) };
                                dadosEntidade.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                                dadosEntidade.IDEntidade = idEntidade;
                                oEntidade.NovoVariavel(dadosEntidade);
                            }
                            else
                            {
                                //Invoca método NovoVariavel da EntidadeBLL
                                dadosEntidade.Criterio = new Criterio() { IDCriterio = dadosCriterio.IDCriterio };
                                dadosEntidade.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                                dadosEntidade.IDEntidade = idEntidade;
                                oEntidade.NovoVariavel(dadosEntidade);
                            }
                        }
                        //Caso os primeiros caracteres comecem com "abaixo de"
                        else if (variavel.StartsWith("abaixo de"))
                        {
                            //Quebra a Variavel para capturar o valor 1
                            string[] variavelSeparada = variavel.Split(' ');
                            //Invoca método ListarVariavel e retorna IDCriterio
                            dadosCriterio.CriterioVariavel = new CriterioVariavel()
                            {
                                Valor1 = Convert.ToDouble(variavelSeparada[3])
                            };
                            dadosCriterio.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                            dadosCriterio.TipoCriterioVariavel = new TipoCriterioVariavel() { IDTipoCriterioVariavel = 5 };
                            dadosCriterio = oCriterio.ListarVariavel(dadosCriterio);
                            //Invoca método NovoVariavel da EntidadeBLL
                            dadosEntidade.Criterio = new Criterio() { IDCriterio = dadosCriterio.IDCriterio };
                            dadosEntidade.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                            dadosEntidade.IDEntidade = idEntidade;
                            oEntidade.NovoVariavel(dadosEntidade);
                        }
                        //Caso os primeiros caracteres comecem com "acima de"
                        else if (variavel.StartsWith("acima de"))
                        {
                            //Quebra a Variavel para capturar o valor 1
                            string[] variavelSeparada = variavel.Split(' ');
                            //Invoca método ListarVariavel e retorna IDCriterio
                            dadosCriterio.CriterioVariavel = new CriterioVariavel()
                            {
                                Valor1 = Convert.ToDouble(variavelSeparada[3])
                            };
                            dadosCriterio.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                            dadosCriterio.TipoCriterioVariavel = new TipoCriterioVariavel() { IDTipoCriterioVariavel = 3 };
                            dadosCriterio = oCriterio.ListarVariavel(dadosCriterio);
                            //Invoca método NovoVariavel da EntidadeBLL
                            dadosEntidade.Criterio = new Criterio() { IDCriterio = dadosCriterio.IDCriterio };
                            dadosEntidade.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                            dadosEntidade.IDEntidade = idEntidade;
                            oEntidade.NovoVariavel(dadosEntidade);
                        }
                        //Caso seja uma String
                        else if (variavel.GetType() == typeof(String))
                        {
                            //Invoca método ListarVarivelImportacao e retorna IDCriterio
                            dadosCriterio.Nome = linhaSeparada[1].ToString().Trim();
                            dadosCriterio.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                            dadosCriterio = oCriterio.ListarVariavelImportacao(dadosCriterio);
                            //Invoca método NovoVariavel da EntidadeBLL
                            dadosEntidade.Criterio = new Criterio() { IDCriterio = dadosCriterio.IDCriterio };
                            dadosEntidade.Variavel = new Variavel() { IDVariavel = list.Variavel.IDVariavel };
                            dadosEntidade.IDEntidade = idEntidade;
                            oEntidade.NovoVariavel(dadosEntidade);
                        }
                        //Caso não se encaixe em nenhuma das situações, Criticar
                        else
                        {
                            dadosLogImportacaoEntidade.CodigoVariavel = list.Variavel.Codigo;
                            dadosLogImportacaoEntidade.DocumentoEntidade = linhaSeparada[0].ToString();
                            dadosLogImportacaoEntidade.Mensagem = "Domínio informado para a variável " + list.Variavel.IDVariavel + " e Coluna Importação " + variavel +  "inexistente no software segmentação";
                            oLogImportacaoEntidade.Novo(dadosLogImportacaoEntidade);
                        }
                    }
                }
            }
            //Fecha a conexão do Stream
            stream.Close();
            
        }
    }
}

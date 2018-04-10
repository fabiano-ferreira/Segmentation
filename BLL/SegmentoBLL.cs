using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using DAL;
using VO;
using LoreSoft.MathExpressions;
using LoreSoft.MathExpressions.UnitConversion;
using LoreSoft.MathExpressions.Metadata;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BLL
{
    public class SegmentoBLL
    {
        private SegmentoDAO _segmento;

        public SegmentoBLL()
        {
            if(_segmento == null)
                _segmento = new SegmentoDAO();
        }

        public void Novo(Segmento entidade)
        {
            _segmento.Novo(entidade);
        }

        public void Remover(Segmento entidade)
        {
            _segmento.Remover(entidade);
        }

        public void Editar(Segmento entidade)
        {
            _segmento.Editar(entidade);
        }

        public List<Segmento> Listar()
        {
            return _segmento.Listar();
        }

        public Segmento Listar(Segmento entidade)
        {
            return _segmento.Listar(entidade);
        }

        public Segmento ListarEntidade(Segmento entidade)
        {
            return _segmento.ListarEntidade(entidade);
        }

        public void NovaEntidade(Segmento entidade)
        {
            _segmento.NovaEntidade(entidade);
        }

        public void RemoverEntidade(string idSegmento, string idEntidade)
        {
            _segmento.RemoverEntidade(idSegmento, idEntidade);
        }

        public Segmento ListarFator(Segmento entidade)
        {
            return _segmento.ListarFator(entidade);
        }

        public void NovoFator(Segmento entidade)
        {
            _segmento.NovoFator(entidade);
        }

        public void RemoverFator(Segmento entidade)
        {
            _segmento.RemoverFator(entidade);
        }

        public Segmento ListarModelo(Segmento entidade)
        {
            return _segmento.ListarModelo(entidade);
        }

        public Segmento ListarProdutoCriterioAderencia(Segmento entidade)
        {
            return _segmento.ListarProdutoCriterioAderencia(entidade);
        }

        public Segmento ListarProdutoNivelCriterioAderencia(Segmento entidade)
        {
            return _segmento.ListarProdutoNivelCriterioAderencia(entidade);
        }

        public Segmento ListarRegraLogica(Segmento entidade)
        {
            return _segmento.ListarRegraLogica(entidade);
        }

        public void ControleTamanhoMercado(Segmento entidade)
        {
            _segmento.ControleTamanhoMercado(entidade);
        }

        public void NovoRegraLogica(Segmento entidade)
        { 
            _segmento.NovoRegraLogica(entidade);
        }

        public Segmento ListarRazaoAderenciaProduto(Segmento entidade)
        {
            return _segmento.ListarRazaoAderenciaProduto(entidade);
        }

        public Segmento ListarRazaoAderenciaProdutoNivel(Segmento entidade)
        {
            return _segmento.ListarRazaoAderenciaProdutoNivel(entidade);
        }

        public void RemoverRegraLogica(Segmento entidade)
        {
            _segmento.RemoverRegraLogica(entidade);
        }

        public void GerarCodigoSegmento(Modelo entidadeModelo)
        {
            string codigo;
            Modelo dadosModelo = new Modelo();
            TipoSegmentoBLL oTipoSegmento = new TipoSegmentoBLL();
            Variavel dadosVariavel = new Variavel();
            VariavelBLL oVariavel = new VariavelBLL();
            Criterio dadosCriterio = new Criterio();
            CriterioBLL oCriterio = new CriterioBLL();
            RegraLogica dadosRegraLogica = new RegraLogica();
            RegraLogicaBLL oRegraLogica = new RegraLogicaBLL();
            Segmento dadosSegmento = new Segmento();

            //Invoca Método para retornar OutputGlobal
            dadosVariavel.Modelo = new Modelo() { IDModelo = entidadeModelo.IDModelo };
            dadosVariavel.TipoSaida = new TipoSaida() { IDTipoSaida = 3 };
            dadosVariavel.ClasseVariavel = new ClasseVariavel()
            {
                IDClasseVariavel = null
            };
            dadosVariavel = oVariavel.ListarOutputGlobal(dadosVariavel);
            if (dadosVariavel.IDVariavel == 0)
                throw new Exceptions.RegraLogicaInvalida("NÃO EXISTE NENHUM OUTPUT GLOBAL VINCULADO A ESSE MODELO. IMPOSSÍVEL GERAR SEGMENTOS.");

            //Invoca Método para retornar RegraLógica
            dadosRegraLogica.Variavel = new Variavel() { IDVariavel = dadosVariavel.IDVariavel };
            dadosRegraLogica = oRegraLogica.Listar(dadosRegraLogica);
            if (dadosRegraLogica.RegraLogicaLista.Count == 0)
                throw new Exceptions.RegraLogicaInvalida("NÃO EXISTE NENHUMA REGRA LÓGICA VINCULADA AO OUTPUT GLOBAL DO MODELO. IMPOSSÍVEL GERAR SEGMENTOS.");

            //Pegar o IdRegraLogica de cada indice da lista RegraLogica
            foreach (RegraLogica listRegraLogica in dadosRegraLogica.RegraLogicaLista)
            {
                if (listRegraLogica.IdRegraLogica == null)
                {
                    throw new Exceptions.RegraLogicaInvalida("REGRA LÓGICA NÃO CADASTRADA");
                }
                
                //Invoca Método para retornar o Nome Modelo.
                dadosModelo = oTipoSegmento.Listar(entidadeModelo);
                //Atribui a primeira letra do Nome Modelo no Código.
                codigo = dadosModelo.Nome[0].ToString();
                //Concatena abre colchetes no Código.
                codigo += "[";

                //Invoca Método para retornar Nome Critério.
                dadosCriterio.IDCriterio = listRegraLogica.Criterio.IDCriterio;
                dadosCriterio.LinhaNegocio = new LinhaNegocio()
                {
                    IDLinhaNegocio = null
                };
                dadosCriterio = oCriterio.Listar(dadosCriterio);

                //Concatena as 3 primeiras Letras do Nome Critério no Código.
                codigo += dadosCriterio.Nome[0];
                codigo += dadosCriterio.Nome[1];
                codigo += dadosCriterio.Nome[2];
                //Concatena abre parenteses no Código.
                codigo += "(";

                //Invoca Método para retornar uma lista de VariavelRegraLogica.
                dadosVariavel.TipoSaida = new TipoSaida() { IDTipoSaida = 3 };
                dadosVariavel.Modelo = new Modelo() { IDModelo = entidadeModelo.IDModelo };
                dadosVariavel.RegraLogica = new RegraLogica() { IdRegraLogica = listRegraLogica.IdRegraLogica };
                dadosVariavel.ClasseVariavel = new ClasseVariavel()
                {
                    IDClasseVariavel = null
                };
                dadosVariavel = oVariavel.ListarRegraLogicaProcessoSegmento(dadosVariavel);

                //Pegar o IdCriterio de cada indice da lista VariavelRegraLogica
                foreach (VariavelRegraLogica list in dadosVariavel.VariavelRegraLogicaLista)
                {
                    //Invoca Método para retornar Nome Critério.
                    dadosCriterio.IDCriterio = list.Criterio.IDCriterio;
                    dadosCriterio.LinhaNegocio = new LinhaNegocio()
                    {
                        IDLinhaNegocio = null
                    };
                    dadosCriterio = oCriterio.Listar(dadosCriterio);
                    //Concatena as 2 primeiras Letras do Nome Critério no Código.
                    codigo += dadosCriterio.Nome[0];
                    codigo += dadosCriterio.Nome[1] + ", ";
                }

                //Concatena fecha parenteses no Código.
                codigo += ")";
                //Concatena fecha colchetes no Código.
                codigo += "]";

                //Verifica se existe algum relacionamento com o SegmentoRegraLogica e o exclui
                dadosSegmento.Modelo = new Modelo() { IDModelo = entidadeModelo.IDModelo };
                dadosSegmento = Listar(dadosSegmento);
                foreach (Segmento listSegmento in dadosSegmento.SegmentoLista)
                {
                    dadosSegmento.IDSegmento = listSegmento.IDSegmento;
                    RemoverRegraLogica(dadosSegmento);
                }
                dadosSegmento.Modelo = new Modelo() { IDModelo = entidadeModelo.IDModelo };
                dadosSegmento.IDSegmento = null;
                dadosSegmento.Codigo = null;
                dadosSegmento.Usuario = new Usuario()
                {
                    IDUsuario = null
                };
                try
                {
                    Remover(dadosSegmento);
                }
                catch (Exception)
                {
                    throw new Exceptions.RegraLogicaInvalida("EXISTEM RELACIONAMENTOS PENDENTES PARA ESTE SEGMENTO. IMPOSSÍVEL GERAR SEGMENTOS.");
                    
                }
                

                //Invoca Método para inserir o Código Segmento.
                dadosSegmento.TamanhoMercado = null;
                dadosSegmento.Codigo = codigo;
                dadosSegmento.FatorAtratividade = null;
                dadosSegmento.Modelo = new Modelo() { IDModelo = entidadeModelo.IDModelo };
                dadosSegmento.Usuario = new Usuario()
                {
                    IDUsuario = entidadeModelo.Usuario.IDUsuario
                };
                Novo(dadosSegmento);

                //Invoca Método para inserir a relação Segmento e RegraLógica
                dadosSegmento.RegraLogica = new RegraLogica()
                {
                    IdRegraLogica = listRegraLogica.IdRegraLogica
                };
                NovoRegraLogica(dadosSegmento);

            }
        }

        public void CalculaFatorAtratividade(Modelo entidadeModelo)
        {
            double resultado = 0;
            double valor;
            double peso;
            Segmento dadosSegmento = new Segmento();
            Fator dadosFator = new Fator();
            FatorBLL oFator = new FatorBLL();
            Criterio dadosCriterio = new Criterio();
            CriterioBLL oCriterio = new CriterioBLL();

            //Invoca Método SegmentoListar
            dadosSegmento.Modelo = new Modelo() { IDModelo = entidadeModelo.IDModelo };
            dadosSegmento = Listar(dadosSegmento);
            
            //Encontrar os Fatores relacionados para cada indice da lista Segmento
            foreach (Segmento listSegmento in dadosSegmento.SegmentoLista)
            {
                //Invoca Método FatorSegmentoListar
                dadosFator.Segmento = new Segmento() { IDSegmento = listSegmento.IDSegmento };
                dadosFator = oFator.ListarSegmento(dadosFator);
                
                //Encontrar o IdCriterio para cada indice da lista Fator
                foreach (Fator listFator in dadosFator.FatorFilho)
                {
                    //Invoca Método CriterioFatorListar
                    dadosCriterio.IDCriterio = listFator.Criterio.IDCriterio;
                    dadosCriterio.Fator = new Fator() { IDFator = listFator.IDFator };
                    dadosCriterio = oCriterio.ListarFator(dadosCriterio);
                    valor = dadosFator.Valor;

                    //Invoca Método FatorListar
                    dadosFator.IDFator = listFator.IDFator;
                    dadosFator = oFator.Listar(dadosFator);
                    peso = dadosFator.Peso;

                    resultado = (valor * peso) + resultado;

                }
                dadosSegmento.FatorAtratividade = Convert.ToInt32(Math.Round(resultado));
                dadosSegmento.IDSegmento = listSegmento.IDSegmento;
                Editar(dadosSegmento);
            }

        }

        /// <summary>
        /// metodo localiza a variavel Output Global e seus filhos diretos
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public void SegmentarEntidade(Entidade entidade)
        {
            VariavelBLL oVariavel = new VariavelBLL();
            EntidadeBLL oEntidade = new EntidadeBLL();
            RegraLogicaBLL oRegraLogica = new RegraLogicaBLL();
            Variavel dadosVariavelLista = new Variavel();
            Segmento dadosSeguimento = new Segmento();
            RegraLogica dadosRegraLogica = new RegraLogica();
            List<RegraLogica> dadosRegraLogicaLista = new List<RegraLogica>();

            //retorna a variavel OutputGlobal
            dadosVariavelLista = oVariavel.ListarOutputGlobal(entidade.Variavel);
            //retorna lista de filhos do OutputGlobal
            //dadosVariavelLista = oVariavel.ListarRelacao(dadosVariavelLista);

            //retorna Critérios das variaveis recursivamente
            for (int i = 0; i < dadosVariavelLista.VariavelFilho.Count; i++)
            {
                //Variavel com Tipo de dado Importado
                if (dadosVariavelLista.VariavelFilho[i].TipoDadoVariavel.IDTipoDadoVariavel == 1 )
                {
                    entidade.Variavel.IDVariavel = dadosVariavelLista.VariavelFilho[i].IDVariavel;
                    entidade = oEntidade.ListarVariavel(entidade);
                    if (entidade.Variavel.Criterio.IDCriterio != 0)
                    {
                        dadosVariavelLista.VariavelFilho[i].Criterio.IDCriterio = entidade.Variavel.Criterio.IDCriterio;
                    }
                    else
                    {
                        dadosVariavelLista.VariavelFilho[i].Criterio.Valor = entidade.Variavel.Criterio.Valor;
                    }
                }
                //Variavel com Tipo de dado Deduzido ou Calculo
                else
                {
                    //Recursivamente Procura Filhos e seus criterios
                    dadosVariavelLista.VariavelFilho[i].Criterio = RetornaCriterio(dadosVariavelLista.VariavelFilho[i], entidade);
                }
            }

            dadosRegraLogica.Variavel = entidade.Variavel;
            //carrega todas as regras logicas do OutputGlobal
            dadosRegraLogicaLista = oRegraLogica.ListarPorVariavel(dadosRegraLogica);

            //percorre a lista de regra logica até encontrar a regra válida
            for (int i = 0; i < dadosRegraLogicaLista.Count; i++)
            {
                for (int j = 0; j < dadosVariavelLista.VariavelFilho.Count; j++)
                {
                    dadosVariavelLista.VariavelFilho[j].RegraLogica.IdRegraLogica = dadosRegraLogicaLista[i].IdRegraLogica;
                    //testa Variaveis para encontrar a regra lógica válida
                    dadosVariavelLista.VariavelFilho[j].RegraLogica = oRegraLogica.ValidarVariavel(dadosVariavelLista.VariavelFilho[j]);
                    //Regra Lógica falsa interrompe o laço
                    if (dadosVariavelLista.VariavelFilho[j].RegraLogica.Valido == false)
                    {
                        break;
                    }

                    //Regra lógica válida prepara o critério para retorno
                    else if (j + 1 == dadosVariavelLista.VariavelFilho.Count)
                    {
                        //Consome a Regra Logica
                        entidade.Segmento.RegraLogica.IdRegraLogica = dadosRegraLogicaLista[i].IdRegraLogica;
                        //Retorna Segmento basiado na Regra Logica
                        entidade.Segmento = ListarRegraLogica(entidade.Segmento);
                        //Cadastra a Entidade em um Segmento
                        NovaEntidade(entidade.Segmento);
                        //Incrementa o tamanho do mercado de um segmento
                        ControleTamanhoMercado(entidade.Segmento);
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Metodo testa todas as variaveis filho e busca seus criterios
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public Criterio RetornaCriterio(Variavel entidadeVariavel, Entidade entidade)
        {
            EntidadeBLL oEntidade = new EntidadeBLL();
            VariavelCalculoVariavelBLL oCalculoVariavel = new VariavelCalculoVariavelBLL(); 
            VariavelBLL oVariavel = new VariavelBLL();
            Criterio dadosCriterio = new Criterio();
            Variavel dadosVariavelLista = new Variavel();

            //Retorna lista de filhos das variáveis
            //dadosVariavelLista = oVariavel.ListarRelacao(entidadeVariavel);

            for (int i = 0; i < dadosVariavelLista.VariavelFilho.Count; i++)
            {
                //Variavel com Tipo de dado Importado
                if (dadosVariavelLista.VariavelFilho[i].TipoDadoVariavel.IDTipoDadoVariavel == 1)
                {
                    entidade.Variavel.IDVariavel = dadosVariavelLista.VariavelFilho[i].IDVariavel;
                    entidade = oEntidade.ListarVariavel(entidade);
                    if (entidade.Variavel.Criterio.IDCriterio != 0)
                    {
                        dadosVariavelLista.VariavelFilho[i].Criterio.IDCriterio = entidade.Variavel.Criterio.IDCriterio;
                    }
                    else
                    {
                        dadosVariavelLista.VariavelFilho[i].Criterio.Valor = entidade.Variavel.Criterio.Valor;
                    }
                }
                //Variavel com Tipo de dado Deduzido ou Calculado
                else
                {
                    //Recursivamente Procura Filhos e seus criterios ou valores
                    dadosVariavelLista.VariavelFilho[i].Criterio = RetornaCriterio(dadosVariavelLista.VariavelFilho[i], entidade);
                }
            }
            //Variavel com Tipo de dado Calculo
            if (entidadeVariavel.TipoDadoVariavel.IDTipoDadoVariavel == 3)
            {
                //retorna o critério Utilizando o Calculo das variaveis filhas
                dadosCriterio = CalculaVariavel(dadosVariavelLista.VariavelFilho, entidadeVariavel);
            }
            //Variavel com Tipo de dado Deduzido
            else
            {
                //Retorna o criterio Utilizando a RegraLogica com base nos critérios das variaveis filhas
                dadosCriterio = TestaRegraLogica(dadosVariavelLista.VariavelFilho, entidadeVariavel);
            }
            
            return dadosCriterio;
        }

        /// <summary>
        /// Metodo testa a regra lógica a fim de enquadrar a atual variavel em um critério
        /// </summary>
        /// <param name="entidadeFilha"></param>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public Criterio TestaRegraLogica(List<Variavel> entidadeFilha, Variavel entidade)
        {
            RegraLogicaBLL oRegraLogica = new RegraLogicaBLL();
            List<RegraLogica> dadosRegraLogicaLista = new List<RegraLogica>();
            RegraLogica dadosRegraLogica = new RegraLogica();
            Criterio dadosCriterio = new Criterio();
            MapeamentoCriterioRegraLogica dadosMapeamento = new MapeamentoCriterioRegraLogica();
            MapeamentoCriterioRegraLogicaBLL oMapeamento = new MapeamentoCriterioRegraLogicaBLL();
            
            dadosRegraLogica.Variavel = entidade;
            //carrega todas as regras logicas da variavel pai
            dadosRegraLogicaLista = oRegraLogica.ListarPorVariavel(dadosRegraLogica);

            //percorre a lista de regra logica até encontrar a regra válida
            for (int i = 0; i < dadosRegraLogicaLista.Count; i++)
            {
                for (int j = 0; j < entidadeFilha.Count; j++)
                {
                    entidadeFilha[j].RegraLogica.IdRegraLogica = dadosRegraLogicaLista[i].IdRegraLogica;
                    //testa Variaveis para encontrar a regra lógica válida
                    entidadeFilha[j].RegraLogica = oRegraLogica.ValidarVariavel(entidadeFilha[j]);
                    //Regra Lógica falsa interrompe o laço
                    if (entidadeFilha[j].RegraLogica.Valido == false)
                    {
                        break; 
                    }
                    //Regra lógica válida prepara o critério para retorno
                    else if (j + 1 == entidadeFilha.Count)
                    {
                        if (dadosRegraLogicaLista[i].VariavelHerdado.IDVariavel == 0)
                        {
                            dadosCriterio.IDCriterio = dadosRegraLogicaLista[i].Criterio.IDCriterio;
                        }
                        else
                        {
                            //Consome o Critério Original
                            dadosMapeamento.IdCriterioOriginal = Convert.ToInt32(dadosRegraLogicaLista[i].Criterio.IDCriterio);
                            //carrega o Critério Transformado
                            dadosMapeamento = oMapeamento.Listar(dadosMapeamento);
                            dadosCriterio.IDCriterio = dadosMapeamento.IdCriterioTrasnformado;
                        }
                        return dadosCriterio;
                    }
                }    
            }
            return dadosCriterio;
        } 

        /// <summary>
        /// Metodo testa o valor da variavel a fim de enquadrar em um critério
        /// </summary>
        /// <param name="entidadeFilha"></param>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public Criterio CalculaVariavel(List<Variavel> entidadeFilha, Variavel entidade)
        {
            Criterio dadosCriterio = new Criterio();
            List<Criterio> dadosCriterioLista = new List<Criterio>();
            CalculoVariavel dadosCalculoVariavel = new CalculoVariavel();
            VariavelCalculoVariavel dadosVariavelCalculo = new VariavelCalculoVariavel();
            VariavelCalculoVariavelBLL oVariavelCalculo = new VariavelCalculoVariavelBLL();
            CriterioBLL oCriterio = new CriterioBLL();

            dadosCriterio.Variavel = entidade;
            dadosCalculoVariavel.Variavel = entidade;

            //retorna todos os valores e operadores para uma expressão
            dadosCalculoVariavel.VariavelCalculoVariavel = oVariavelCalculo.ListarCalculo(dadosVariavelCalculo);

            //Concatena todos os valores e operadores da expressão
            for (int i = 0; i < dadosCalculoVariavel.VariavelCalculoVariavel.Count; i++)
            {
                entidade.Expressão += dadosCalculoVariavel.VariavelCalculoVariavel[i].TipoOperadorCalculo.Simbolo;
                entidade.Expressão += dadosCalculoVariavel.VariavelCalculoVariavel[i].Variavel.Criterio.Valor.ToString();
            }

            //Retorna o valor da expressão calculada
            entidade.Criterio.Valor = Convert.ToInt32(Eval(entidade.Expressão));

            //lista todas os Criterios para a variavel
            dadosCriterioLista = oCriterio.ListarVariavelLista(dadosCriterio);

            //Testa todas os critérios variaveis até encontrar o correto
            for (int j = 0; j < dadosCriterioLista.Count; j++)
            {
                //Menor ou igual ao valor do critério atual (Até)
                if (dadosCriterioLista[j].TipoCriterioVariavel.IDTipoCriterioVariavel == 1 &&
                    entidade.Criterio.Valor <= dadosCriterioLista[j].CriterioVariavel.Valor1)
                {
                    entidade.Criterio.IDCriterio = dadosCriterioLista[j].CriterioVariavel.Criterio.IDCriterio;
                    break;
                }
                //Entre os valores do Critério atual (Entre)
                else if (dadosCriterioLista[j].TipoCriterioVariavel.IDTipoCriterioVariavel == 2 &&
                    entidade.Criterio.Valor >= dadosCriterioLista[j].CriterioVariavel.Valor1 &&
                    entidade.Criterio.Valor <= dadosCriterioLista[j].CriterioVariavel.Valor2)
                {
                    entidade.Criterio.IDCriterio = dadosCriterioLista[j].CriterioVariavel.Criterio.IDCriterio;
                    break;
                }
                //Menor que o valor do critério atual (Maior que)
                else if (dadosCriterioLista[j].TipoCriterioVariavel.IDTipoCriterioVariavel == 3 &&
                    entidade.Criterio.Valor > dadosCriterioLista[j].CriterioVariavel.Valor1)
                {
                    entidade.Criterio.IDCriterio = dadosCriterioLista[j].CriterioVariavel.Criterio.IDCriterio;
                    break;
                }
                //Igual ao valor do critério atual (Igual)
                else if (dadosCriterioLista[j].TipoCriterioVariavel.IDTipoCriterioVariavel == 4 &&
                    entidade.Criterio.Valor == dadosCriterioLista[j].CriterioVariavel.Valor1)
                {
                    entidade.Criterio.IDCriterio = dadosCriterioLista[j].CriterioVariavel.Criterio.IDCriterio;
                    break;
                }
                //Menor que o valor do criterio atual (Manor que)
                else if (dadosCriterioLista[j].TipoCriterioVariavel.IDTipoCriterioVariavel == 5 && 
                    entidade.Criterio.Valor < dadosCriterioLista[j].CriterioVariavel.Valor1)
                {
                    entidade.Criterio.IDCriterio = dadosCriterioLista[j].CriterioVariavel.Criterio.IDCriterio;
                    break;
                }                
            }
            return dadosCriterio;
        }

        /// <summary>
        /// Calcula a expressão das variaveis calculadas
        /// </summary>
        /// <param name="input"></param>
        private double Eval(string input)
        {
            MathEvaluator _eval = new MathEvaluator();
            Stopwatch watch = new Stopwatch();

            string answer;

            watch.Reset();
            watch.Start();
            try
            {
                answer = _eval.Evaluate(input).ToString();
            }
            catch (Exception ex)
            {
                answer = ex.Message;
            }

            watch.Stop();

            return Convert.ToDouble(answer);
        }

        public void CalculaFatorPosicionamento(Modelo entidadeModelo, VersaoProdutoFator entidadeVersaoProdutoFator)
        {
            double fatorPosicionamento = 0;
            Fator dadosFator = new Fator();
            FatorBLL oFator = new FatorBLL();
            Segmento dadosSegmento = new Segmento();
            Criterio dadosCriterio = new Criterio();
            CriterioBLL oCriterio = new CriterioBLL();
            VersaoProdutoFator dadosVersaoProdutoFator = new VersaoProdutoFator();
            VersaoProdutoFatorBLL oVersaoProdutoFator = new VersaoProdutoFatorBLL();

            //Invoca método Listar do Segmento passando os parametros recebidos
            dadosSegmento.Modelo = new Modelo()
            {
                IDModelo = entidadeModelo.IDModelo
            };
            dadosSegmento = Listar(dadosSegmento);
            //Foreach para cada IDsegmento dentro da lista SegmentoLista
            foreach (Segmento listSegmento in dadosSegmento.SegmentoLista)
            {
                //Invoca método ListarPosicionamentoSemProduto passando os parametros recebidos
                dadosFator.VersaoProdutoFator = new VersaoProdutoFator()
                {
                    IdVersaoProdutoFator = entidadeVersaoProdutoFator.IdVersaoProdutoFator
                };
                dadosFator.Modelo = new Modelo()
                {
                    IDModelo = entidadeModelo.IDModelo
                };
                dadosFator.TipoFator = new TipoFator()
                {
                    IDTipoFator = 2
                };
                dadosFator = oFator.ListarPosicionamentoSemProduto(dadosFator);
                //Foreach para cada IDFator dentro da lista FatorFilho
                foreach (Fator listFator in dadosFator.FatorFilho)
                {
                    //Invoca método ListarFator do Segmento
                    dadosSegmento.IDSegmento = listSegmento.IDSegmento;
                    dadosSegmento.Fator = new Fator()
                    {
                        IDFator = listFator.IDFator
                    };
                    dadosSegmento = ListarFator(dadosSegmento);
                    //Foreach para lista SegmentoFator 
                    foreach(SegmentoFator listSegmentoFator in dadosSegmento.SegmentoFator)
                    {
                        //Invoca Método CriterioFatorListar
                        dadosCriterio.IDCriterio = listFator.Criterio.IDCriterio;
                        dadosCriterio.Fator = new Fator() { IDFator = listFator.IDFator };
                        dadosCriterio = oCriterio.ListarFator(dadosCriterio);
                        //Invoca Método FatorListar
                        dadosFator.IDFator = listFator.IDFator;
                        dadosFator = oFator.Listar(dadosFator);
                        //Variável que faz a somatória de Valor x Peso
                        fatorPosicionamento += Convert.ToInt32(dadosCriterio.Valor * dadosFator.Peso);
                        //Invoca método ListarSegmentoProdutoFatorProduto
                        dadosVersaoProdutoFator.IdVersaoProdutoFator = entidadeVersaoProdutoFator.IdVersaoProdutoFator;
                        dadosVersaoProdutoFator.Segmento = new Segmento()
                        {
                            IDSegmento = listSegmento.IDSegmento
                        };
                        dadosVersaoProdutoFator = oVersaoProdutoFator.ListarSegmentoProdutoFatorProduto(dadosVersaoProdutoFator);
                        //Verifica se o retorno do método ListarSegmentoProdutoFatorProduto tem algum registro
                        if (dadosVersaoProdutoFator.VersaoSegmentoProdutoFatorProduto.Criterio.IDCriterio == 0)
                        {
                            //Invoca Método CriterioFatorListar
                            dadosCriterio.IDCriterio = dadosVersaoProdutoFator.VersaoSegmentoProdutoFatorProduto.Criterio.IDCriterio;
                            dadosCriterio.Fator = new Fator() 
                            { 
                                IDFator = dadosVersaoProdutoFator.VersaoSegmentoProdutoFatorProduto.Fator.IDFator
                            };
                            dadosCriterio = oCriterio.ListarFator(dadosCriterio);
                            //Invoca Método FatorListar
                            dadosFator.IDFator = dadosVersaoProdutoFator.VersaoSegmentoProdutoFatorProduto.Fator.IDFator;
                            dadosFator = oFator.Listar(dadosFator);
                            //Invoca método ListarRazaoAderenciaProdutoNivel
                            dadosSegmento.IDSegmento = listSegmento.IDSegmento;
                            dadosSegmento.ProdutoNivel.IDProdutoNivel = dadosVersaoProdutoFator.VersaoSegmentoProdutoFatorProduto.Produto.IdProduto;
                            dadosSegmento.VersaoProdutoFator.IdVersaoProdutoFator = entidadeVersaoProdutoFator.IdVersaoProdutoFator;
                            dadosSegmento = ListarRazaoAderenciaProdutoNivel(dadosSegmento);
                            //Variável que faz a somatória de fatorPosicionamento x (Valor x Peso)
                            fatorPosicionamento += Convert.ToInt32(dadosSegmento.FatorPosicionamento*(dadosCriterio.Valor * dadosFator.Peso));
                        }
                        else
                        {
                            //Invoca Método CriterioFatorListar
                            dadosCriterio.IDCriterio = dadosVersaoProdutoFator.VersaoSegmentoProdutoFatorProduto.Criterio.IDCriterio;
                            dadosCriterio.Fator = new Fator()
                            {
                                IDFator = dadosVersaoProdutoFator.VersaoSegmentoProdutoFatorProduto.Fator.IDFator
                            };
                            dadosCriterio = oCriterio.ListarFator(dadosCriterio);
                            //Invoca Método FatorListar
                            dadosFator.IDFator = dadosVersaoProdutoFator.VersaoSegmentoProdutoFatorProduto.Fator.IDFator;
                            dadosFator = oFator.Listar(dadosFator);
                            //Invoca método ListarRazaoAderenciaProduto
                            dadosSegmento.IDSegmento = listSegmento.IDSegmento;
                            dadosSegmento.ProdutoNivel.IDProdutoNivel = dadosVersaoProdutoFator.VersaoSegmentoProdutoFatorProduto.Produto.IdProduto;
                            dadosSegmento.VersaoProdutoFator.IdVersaoProdutoFator = entidadeVersaoProdutoFator.IdVersaoProdutoFator;
                            dadosSegmento = ListarRazaoAderenciaProduto(dadosSegmento);
                            //Variável que faz a somatória de fatorPosicionamento x (Valor x Peso)
                            fatorPosicionamento += Convert.ToInt32(dadosSegmento.FatorPosicionamento * (dadosCriterio.Valor * dadosFator.Peso));
                        }
                    }
                }
            }
            //Invoca método Editar da VersaoProdutoFator passando o IdVersaoProdutoFator e o fatorPosicionamento
            dadosVersaoProdutoFator.IdVersaoProdutoFator = entidadeVersaoProdutoFator.IdVersaoProdutoFator;
            dadosVersaoProdutoFator.FatorPosicionamento = Convert.ToInt32(fatorPosicionamento);
            oVersaoProdutoFator.Editar(dadosVersaoProdutoFator);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;
using System.Collections;

namespace BLL
{
    public class VariavelBLL
    {
        private VariavelDAO _variavel;

        public VariavelBLL()
        {
            if (_variavel == null)
                _variavel = new VariavelDAO();
        }


        private void Novo(Variavel entidade)
        {
            _variavel.Novo(entidade);
        }

        public void Remover(Variavel entidade)
        {
            _variavel.Remover(entidade);
        }

        private void Editar(Variavel entidade)
        {
            _variavel.Editar(entidade);
        }

        public List<Variavel> Listar()
        {
            return _variavel.Listar();
        }

        public Variavel Listar(Variavel entidade)
        {
            return _variavel.Listar(entidade);
        }

        public Variavel ListarCriterio(Variavel entidade)
        {
            return _variavel.ListarCriterio(entidade);
        }

        public void NovaRegraLogica(Variavel entidade)
        {
            _variavel.NovaRegraLogica(entidade);
        }

        public void RemoverRegraLogico(Variavel entidade)
        {
            _variavel.RemoverRegraLogico(entidade);
        }

        public Variavel ListarRegraLogicaProcessoSegmento(Variavel entidade)
        {
            return _variavel.ListarRegraLogicaProcessoSegmento(entidade);
        }

        public Variavel ListarOutputGlobal(Variavel entidade)
        {
            return _variavel.ListarOutputGlobal(entidade);
        }

        public List<Variavel> ListarRelacao(Variavel entidade)
        {
            return _variavel.ListarRelacao(entidade);
        }

        public List<Variavel> ListarRelacaoModelo(Variavel entidade)
        {
            return _variavel.ListarRelacaoModelo(entidade);
        }

        public List<Variavel> ListarLinhaNegocioModelo(Variavel entidade)
        {
            return _variavel.ListarLinhaNegocioModelo(entidade);
        }

        public List<Variavel> ListarModelo(Variavel entidade)
        {
            return _variavel.ListarModelo(entidade);
        }

        public void RemoverRelacao(Variavel entidade)
        {
            _variavel.RemoverRelacao(entidade);
        }

        public void NovaRelacao(Variavel entidade)
        {
            _variavel.NovaRelacao(entidade);
        }

        /// <summary>
        /// Metodo valida todas as regras de negocio para inserção de Variaveis
        /// </summary>
        /// <param name="entidade"></param>
        public void Persistir(List<Variavel> entidade)
        {
            //testa existencia de filhos de uma variável
            //int quantFilhos = 0;

            for (int i = 0; i < entidade.Count; i++)
            {
                if (entidade[i].TipoDadoVariavel.IDTipoDadoVariavel == 1)
                {
                    for (int j = 0; j < entidade.Count; j++)
                    {
                        if (entidade[i].IdPai == entidade[j].IDVariavel && 
                            entidade[j].TipoDadoVariavel.IDTipoDadoVariavel == 1 &&
                            entidade[i].IdPai != 0)
                        {
                            throw new Exceptions.VariavelInvalida("Variáveis Importadas não podem possuir Filhos, verifique: " + entidade[j].Codigo);
                        }
                    }
                }
                //else
                //{
                //    for (int l = 0; l < entidade.Count; l++)
                //    {
                //        if (entidade[l].IdPai == entidade[i].IDVariavel)
                //        {
                //            quantFilhos++;
                //        }
                //    }
                //    if (quantFilhos < 1)
                //    {
                //        throw new Exceptions.VariavelInvalida("Variáveis Deduzidas devem possuir pelo menos um Filho, verifique: " + entidade[i].Codigo);
                //    }
                //}
                
                //atributo Status, sinaliza Nova Variavel a ser 1(cadastrada) e Variavel existente a ser 2(Editada)
                if (entidade[i].Status == 1)
                {
                    Novo(entidade[i]);
                    if (entidade[i].IdPai != 0)
                    {
                        NovaRelacao(entidade[i]);
                    }
                }
                else if (entidade[i].Status == 2)
                {
                    Editar(entidade[i]);
                    if (entidade[i].IdPai != 0)
                    {
                        Remover(entidade[i]);
                        NovaRelacao(entidade[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Metodo gera codigo de Variavel, quando este possui "Pai", chamar este metodo no momento da escolha da Variavel Pai
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="idPai"></param>
        /// <returns></returns>
        public Variavel GeraCodigo(List<Variavel> entidade, string idPai)
        {
            //variavel usada para retornar o Codigo
            string codigo = string.Empty;

            List<Variavel> dadosVariavelLista = new List<Variavel>();
            VariavelBLL oVariavel = new VariavelBLL();
            Variavel dadosVariavel = new Variavel();
            //variaval geradora de Codigo novo
            int codigoNovo = 0;

            for (int i = 0; i < entidade.Count; i++)
            {
                if (entidade[i].IDVariavel.ToString() == idPai)
                {
                    dadosVariavelLista = oVariavel.ListarRelacao(entidade[i]);

                    dadosVariavel.IdPai = Convert.ToInt32(idPai);
                    codigoNovo = Convert.ToInt32(entidade[i].VariavelFilho.Count) + 1 + dadosVariavelLista.Count;
                    dadosVariavel.Codigo = entidade[i].Codigo + "." + codigoNovo.ToString();
                }
            }
            return dadosVariavel;
        }

        /// <summary>
        /// Gera Código para variáveis com Tipo de Saída "Output Global" e valída Duplicidade de Variáveis Globais, Chamar método na Escolha do Tipo de Saída, se Output GLobal
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="entidadeADD"></param>
        /// <returns></returns>
        public string GeraCodigoOutput(List<Variavel> entidade, Variavel entidadeADD)
        {
            //variavel usada para retornar o Codigo
            string codigo = string.Empty;

            string codigoTipo = string.Empty;
            ClasseVariavelBLL oClasseVariavel = new ClasseVariavelBLL();
            List<ClasseVariavel> dadosClasseVariavel = new List<ClasseVariavel>();
            
            dadosClasseVariavel = oClasseVariavel.Listar();

            TipoSaidaBLL oTipoSaida = new TipoSaidaBLL();
            List<TipoSaida> dadosTipoSaida = new List<TipoSaida>();

            dadosTipoSaida = oTipoSaida.ListarTodos();
            

            for (int i = 0; i < entidade.Count; i++)
            {
                if (entidadeADD.TipoSaida.IDTipoSaida == 3 && entidade[i].TipoSaida.IDTipoSaida == entidadeADD.TipoSaida.IDTipoSaida)
                {
                    throw new Exceptions.VariavelInvalida("Ja existe um Output Global para este modelo, verifique: " + entidade[i].Descricao);
                }
            }
            for (int j = 0; j < dadosClasseVariavel.Count; j++)
            {
                if (dadosClasseVariavel[j].IDClasseVariavel == entidadeADD.ClasseVariavel.IDClasseVariavel)
                {
                    codigo = dadosClasseVariavel[j].Codigo;
                    break;
                }
            }

            for (int l = 0; l < dadosTipoSaida.Count; l++)
            {
                if (dadosTipoSaida[l].IDTipoSaida == entidadeADD.TipoSaida.IDTipoSaida)
                {
                    codigoTipo = dadosTipoSaida[l].Nome;
                    break;
                }
            }
            codigo += string.Concat(Convert.ToString(codigoTipo[0]),"1");

            return codigo;
        }

        /// <summary>
        /// Verifica se Tipo de Saída possui divergencia com entidades Pai e/ou Filho 
        /// </summary>
        /// <param name="entidade"></param>
        public void ValidaTipoSaida(List<Variavel> entidade, Variavel entidadeAdd)
        {
            if (entidadeAdd.TipoSaida.IDTipoSaida != 3)
            {
                for (int j = 0; j < entidade.Count; j++)
                {
                    if (entidade[j].IDVariavel == entidadeAdd.IdPai)
                    {
                        if (entidade[j].TipoSaida.IDTipoSaida == 3 && entidadeAdd.TipoSaida.IDTipoSaida == 1)
                        {
                            throw new Exceptions.VariavelInvalida("Variáveis com tipo de saída \"VARIÁVEL\", não podem estar ligadas, diretamente, a um \"Output Global\".");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Retorna o Output Global da lista gerado por Modelo/ClasseVariavel
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public Variavel RetornaOutpuGlobal(List<Variavel> entidade)
        {
            var variavel = new Variavel();

            foreach (Variavel Listavarivael in entidade)
            {
                if (Listavarivael.TipoSaida.IDTipoSaida == 3)
                {
                    variavel = Listavarivael;
                    break;
                }
            }
            return variavel;
        }

        /// <summary>
        /// retorna os Filhos de variaveis por IdPai
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="IdVariavel"></param>
        /// <returns></returns>
        public List<Variavel> retornaVariaveisFilhos(List<Variavel> entidade, int IdVariavel)
        {
            List<Variavel> variavelLista = new List<Variavel>();

            foreach (Variavel Variavel in entidade)
            {
                if (Variavel.IdPai == IdVariavel)
                {
                    variavelLista.Add(Variavel);
                }
            }
            return variavelLista;
        }
    }
}

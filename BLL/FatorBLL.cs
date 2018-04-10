using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class FatorBLL
    {
        private FatorDAO _fator;

        public FatorBLL()
        {
            if (_fator == null)
                _fator = new FatorDAO();
        }

        private void Novo(Fator entidade)
        {
            _fator.Novo(entidade);
        }

        public void Remover(Fator entidade)
        {
            _fator.Remover(entidade);
        }

        private void Editar(Fator entidade)
        {
            _fator.Editar(entidade);
        }

        public Fator Listar(Fator entidade)
        {
            return _fator.Listar(entidade);
        }

        public List<Fator> Listar()
        {
            return _fator.Listar();
        }

        public Fator ListarCriterio(Fator entidade)
        {
            return _fator.ListarCriterio(entidade);
        }

        public List<Fator> ListarCriterio()
        {
            return _fator.ListarCriterio();
        }

        public Fator ListarCriterioNivelSuperior(Fator entidade)
        {
            return _fator.ListarCriterioNivelSuperior(entidade);
        }

        public Fator ListarSub(Fator entidade)
        {
            return _fator.ListarSub(entidade);
        }

        public List<Fator> ListarSub()
        {
            return _fator.ListarSub();
        }

        public void NovoProdutoNivel(Fator entidade)
        {
            _fator.NovoProdutoNivel(entidade);
        }

        public void NovoProduto(Fator entidade)
        {
            _fator.NovoProduto(entidade);
        }

        public void RemoverProdutoNivel(Fator entidade)
        {
            _fator.RemoverProdutoNivel(entidade);
        }

        public void RemoverProduto(Fator entidade)
        {
            _fator.RemoverProduto(entidade);
        }

        public Fator ListarProdutoNivel(Fator entidade)
        {
            return _fator.ListarProdutoNivel(entidade);
        }

        public Fator ListarSegmento(Fator entidade)
        {
            return _fator.ListarSegmento(entidade);
        }

        public Fator ListarProduto(Fator entidade)
        {
            return _fator.ListarProduto(entidade);
        }

        public Fator ListarPosicionamentoSemProduto(Fator entidade)
        {
            return _fator.ListarPosicionamentoSemProduto(entidade);
        }

        public List<Fator> ListarModeloFator(Fator entidade)
        {
            return _fator.ListarModeloFator(entidade);
        }

        public List<Fator> ListarFiltroFator(Fator entidade)
        {
            return _fator.ListarFiltroFator(entidade);
        }

        public void RemoverRelacao(Fator entidade)
        {
            _fator.RemoverRelacao(entidade);
        }

        public void NovaRelacao(Fator entidade)
        {
            _fator.NovaRelacao(entidade);
        }

        public List<Fator> ListarRelacao(Fator entidade)
        {
            return _fator.ListarRelacao(entidade);
        }

        public List<Fator> ListarFatorModeloFator(Fator entidade)
        {
            return _fator.ListarFatorModeloFator(entidade);
        }

        /// <summary>
        /// Metodo valida todas as regras de negocio para inserção de Fatores
        /// </summary>
        /// <param name="entidade"></param>
        public void Persistir(List<Fator> entidade)
        {
            //Variavel utilizada para Validar o peso maximo para os Filhos

            for (int i = 0; i < entidade.Count; i++)
            {
                int pesoTotal = 0;
                if (entidade[i].IdPai == 0)
                {
                    if (entidade.Count == 1 && entidade[i].Peso != 100)
                    {
                        throw new Exceptions.PesoInvalido("Peso deve ser 100%, verifique: " + entidade[i].Codigo);
                    }
                    else
                    {
                        //soma todos os pesos e gera um codigo com base no relacionamento Modelo/TipoFator/LinhaNegocio
                        for (int j = 0; j < entidade.Count; j++)
                        {
                            if (entidade[i].Modelo.IDModelo == entidade[j].Modelo.IDModelo &&
                                entidade[i].TipoFator.IDTipoFator == entidade[j].TipoFator.IDTipoFator &&
                                entidade[i].LinhaNegocio.IDLinhaNegocio == entidade[j].LinhaNegocio.IDLinhaNegocio && 
                                entidade[j].IdPai == 0)
                            {
                                pesoTotal += entidade[j].Peso;
                            }
                        }

                        if (pesoTotal != 100)
                        {
                            throw new Exceptions.PesoInvalido("A soma de todos os pesos deve ser 100%, verifique: " + entidade[i].Codigo);
                        }
                    }
                }
                else
                {
                    //Calcula peso de todos os Fatores relacionados
                    for (int l = 0; l < entidade.Count; l++)
                    {
                        if (entidade[i].IdPai == entidade[l].IdPai)
                        {
                            pesoTotal += entidade[l].Peso;
                        }
                    }

                    if (entidade[i].TipoFator.IDTipoFator == 1)
                    {
                        for (int m = 0; m < entidade.Count; m++)
                        {
                            if (entidade[m].IDFator == entidade[i].IdPai)
                            {
                                if (pesoTotal != entidade[m].Peso)
                                {
                                    throw new Exceptions.PesoInvalido("A soma de todos os pesos deve ser " + entidade[m].Peso + ", verifique: " + entidade[i].Codigo);
                                }

                            }
                        }
                    }
                    else
                    {
                        if (pesoTotal != 100)
                        {
                            throw new Exceptions.PesoInvalido("A soma de todos os pesos deve ser 100%, verifique: " + entidade[i].Codigo);
                        }
                    }
                }


                //atributo Status, sinaliza Novo Fator a ser cadastrado(1) e Fator existente a ser Editado(2)
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
                        RemoverRelacao(entidade[i]);
                        NovaRelacao(entidade[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Metodo gera codigo de fator, quando este é um fator Raiz, chamar este metodo no momento de inserção na threeview
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="entidadeAdd"></param>
        /// <returns></returns>
        public string GeraCodigoRaiz(Fator entidade, List<Fator> entidadeLista)
        {
            //Gera Novo codigo para o fatores Raiz
            int codigoNovo = 1;

            //Calcula o max de fatores raiz por Modelo/TipoFator/LinhaNegocio
            for (int i = 0; i < entidadeLista.Count; i++)
            {
                if (entidadeLista[i].Modelo.IDModelo == entidade.Modelo.IDModelo &&
                    entidadeLista[i].TipoFator.IDTipoFator == entidade.TipoFator.IDTipoFator &&
                    entidadeLista[i].LinhaNegocio.IDLinhaNegocio == entidade.LinhaNegocio.IDLinhaNegocio &&
                    entidadeLista[i].IdPai == 0)
                {
                    codigoNovo++;
                }
            }
            return codigoNovo.ToString();
        }

        /// <summary>
        /// Metodo gera codigo de Fator, quando este possui "Pai", chamar este metodo no momento da escolha do Fator Pai
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="idPai"></param>
        /// <returns></returns>
        public Fator GeraCodigo(List<Fator> entidade, string idPai)
        {
            Fator dadosFator = new Fator();
            //variavel usada para retornar o Codigo
            string codigo = string.Empty;

            //variaval geradora de Codigo novo
            int codigoNovo = 0;
            //busca todos os filhos do fator pai
            List<Fator> dadosFatorPai = new List<Fator>();
            FatorBLL oFator = new FatorBLL();

            
            //busca o codigo existente na arvore do fator
            for (int i = 0; i < entidade.Count; i++)
            {
                if (entidade[i].IDFator.ToString() == idPai)
                {
                    dadosFatorPai = oFator.ListarRelacao(entidade[i]);
                    
                    dadosFator.IdPai = Convert.ToInt16(idPai);
                    codigoNovo = Convert.ToInt32(entidade[i].FatorFilho.Count) + dadosFatorPai.Count + 1;
                    dadosFator.Codigo = entidade[i].Codigo + "." + codigoNovo.ToString();

                    //}
                    //else
                    //{
                    //    dadosFator.IdPai = Convert.ToInt16(idPai);
                    //    codigoNovo = +dadosFatorPai.Count + 1;
                    //    dadosFator.Codigo = entidade[i].Codigo + "." + codigoNovo.ToString();
                    //}
                }
            }
            return dadosFator;
        }

        /// <summary>
        /// Retorna todos os Fatores Raiz
        /// </summary>
        /// <param name="entidade"></param>
        /// <returns></returns>
        public List<Fator> RetornaFatorRaiz(List<Fator> entidade)
        {
            List<Fator> fatorLista = new List<Fator>();
            foreach (Fator fator in entidade)
            {
                if (fator.IdPai == 0)
                {
                    fatorLista.Add(fator); 
                }
            }
            return fatorLista;
        }

        /// <summary>
        /// Retorno Fatores Filhos por IdPai
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="idPai"></param>
        /// <returns></returns>
        public List<Fator> RetornaFatorFilho(List<Fator> entidade, int idPai)
        {
            List<Fator> fatorLista = new List<Fator>();

            foreach (Fator fator in entidade)
            {
                if (fator.IdPai == idPai)
                {
                    fatorLista.Add(fator);        
                }
            }
            return fatorLista;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using VO;

namespace BLL
{
    public class ProdutoNivelBLL
    {
        private ProdutoNivelDAO _produtoNivel;

        public ProdutoNivelBLL()
        {
            if (_produtoNivel == null)
                _produtoNivel = new ProdutoNivelDAO();
        }

        public void Novo(ProdutoNivel entidade)
        {
            _produtoNivel.Novo(entidade);
        }

        public void Remover(ProdutoNivel entidade)
        {
            _produtoNivel.Remover(entidade);
        }

        public void Editar(ProdutoNivel entidade)
        {
            _produtoNivel.Editar(entidade);
        }

        public List<ProdutoNivel> ListarNivel()
        {
            return _produtoNivel.ListarNivel();
        }

        public List<ProdutoNivel> ListarNivel(string nome)
        {
            return _produtoNivel.ListarNivel(nome);
        }

        public ProdutoNivel ListarNivel(int id)
        {
            return _produtoNivel.ListarNivel(id);
        }

        public List<ProdutoNivel> ListarPais()
        {
            return _produtoNivel.ListarPais();
        }

        public List<ProdutoNivel> ListarFilhos(int idPai)
        {
            return _produtoNivel.ListarFilhos(idPai);
        }

        public List<ProdutoNivel> Listar()
        {
            return _produtoNivel.Listar();
        }

        public ProdutoNivel Listar(ProdutoNivel entidade)
        {
            return _produtoNivel.Listar(entidade);
        }

        public void NovoRelacaoProdutoNivel(ProdutoNivel entidade)
        {
            _produtoNivel.NovoRelacaoProdutoNivel(entidade);
        }

        public void RemoverRelacaoProdutoNivel(ProdutoNivel entidade)
        {
            _produtoNivel.RemoverRelacaoProdutoNivel(entidade);
        }

        public void NovoRelacaoProdutoNivelProduto(ProdutoNivel entidade)
        {
            _produtoNivel.NovoRelacaoProdutoNivelProduto(entidade);
        }

        public void RemoverRelacaoProdutoNivelProduto(ProdutoNivel entidade)
        {
            _produtoNivel.RemoverRelacaoProdutoNivelProduto(entidade);
        }

        public ProdutoNivel ListarRelacaoProdutoNivel(ProdutoNivel entidade)
        {
            return _produtoNivel.ListarRelacaoProdutoNivel(entidade);
        }

        public void NovoCriterioAderenciaSegmento(ProdutoNivel entidade)
        {
            _produtoNivel.NovoCriterioAderenciaSegmento(entidade);
        }

        public void RemoverCriterioAderenciaSegmento(ProdutoNivel entidade)
        {
            _produtoNivel.RemoverCriterioAderenciaSegmento(entidade);
        }

        public ProdutoNivel ListarCriterioAderenciaSegmento(ProdutoNivel entidade)
        {
            return _produtoNivel.ListarCriterioAderenciaSegmento(entidade);
        }

        public ProdutoNivel ListarRelacaoProdutoNivelProduto(ProdutoNivel entidade)
        {
            return _produtoNivel.ListarRelacaoProdutoNivelProduto(entidade);
        }

        public List<ProdutoNivel> ListarRelacaoLinhaNegocio(ProdutoNivel entidade)
        {
            return _produtoNivel.ListarRelacaoLinhaNegocio(entidade);
        }
        
        public void HerdarCriterioAderencia(ProdutoNivel entidadeProdutoNivel, Segmento entidadeSegmento, CriterioAderencia entidadeCriterioAderencia)
        {
            ProdutoNivel dadosProdutoNivel = new ProdutoNivel();
            Produto dadosProduto = new Produto();
            ProdutoBLL oProduto = new ProdutoBLL();

            //Invoca método ListarRelacaoProdutoNivel passando como parâmetro o IDProdutoNivel
            dadosProdutoNivel.IDProdutoNivel = entidadeProdutoNivel.IDProdutoNivel;
            dadosProdutoNivel = ListarRelacaoProdutoNivel(dadosProdutoNivel);

            //Se o método ListarRelacaoProdutoNivel retornar algum conteúdo
            if (dadosProdutoNivel.RelacaoProdutoNivelLista.Count > 0)
            {
                //Foreach para pegar cada IDFIlho dentro da lista RelacaoProdutoNivelLista
                foreach (RelacaoProdutoNivel listRelacaoProdutoNivel in dadosProdutoNivel.RelacaoProdutoNivelLista)
                {
                    if (listRelacaoProdutoNivel.IdFilho != null)
                    {
                        //Invoca método ListarCriterioAderenciaSegmento para verificar se existe algum registro baseado nos parametros passados
                        dadosProdutoNivel.CriterioAderencia.IDCriterioAderencia = entidadeCriterioAderencia.IDCriterioAderencia;
                        dadosProdutoNivel.Segmento.IDSegmento = entidadeSegmento.IDSegmento;
                        dadosProdutoNivel.IDProdutoNivel = listRelacaoProdutoNivel.IdFilho;
                        dadosProdutoNivel = ListarCriterioAderenciaSegmento(dadosProdutoNivel);

                        //Caso tenha algum registro, excluir
                        if (dadosProdutoNivel.IDProdutoNivel != null)
                        {
                            dadosProdutoNivel.CriterioAderencia.IDCriterioAderencia = entidadeCriterioAderencia.IDCriterioAderencia;
                            dadosProdutoNivel.Segmento.IDSegmento = entidadeSegmento.IDSegmento;
                            dadosProdutoNivel.IDProdutoNivel = listRelacaoProdutoNivel.IdFilho;
                            RemoverCriterioAderenciaSegmento(dadosProdutoNivel);
                        }
                        //Invoca método NovoCriterioAderenciaSegmento e insere um novo registro com os parametros passados
                        dadosProdutoNivel.CriterioAderencia.IDCriterioAderencia = entidadeCriterioAderencia.IDCriterioAderencia;
                        dadosProdutoNivel.Segmento.IDSegmento = entidadeSegmento.IDSegmento;
                        dadosProdutoNivel.IDProdutoNivel = listRelacaoProdutoNivel.IdFilho;
                        dadosProdutoNivel.VersaoProdutoFator = new VersaoProdutoFator()
                        {
                            IdVersaoProdutoFator = entidadeProdutoNivel.VersaoProdutoFator.IdVersaoProdutoFator
                        };
                        NovoCriterioAderenciaSegmento(dadosProdutoNivel);
                    }
                    else
                    {
                        //Invoca método ListarRelacaoProdutoNivelProduto para retornar uma lista com IdProduto
                        dadosProdutoNivel.RelacaoProdutoNivelProduto = new RelacaoProdutoNivelProduto()
                        {
                            IDProduto = listRelacaoProdutoNivel.IdRelacaoProdutoNivel
                        };
                        dadosProdutoNivel = ListarRelacaoProdutoNivelProduto(dadosProdutoNivel);
                        //Foreach para ler cada IdProduto da lista
                        foreach (RelacaoProdutoNivelProduto listRelacaoProdutoNivelProduto in dadosProdutoNivel.RelacaoProdutoNivelProdutoLista)
                        {
                            //Invoca método NovocriterioAderenciaSegmento
                            dadosProduto.IdProduto = listRelacaoProdutoNivelProduto.IDProduto;
                            dadosProduto.CriterioAderencia = new CriterioAderencia()
                            {
                                IDCriterioAderencia = entidadeCriterioAderencia.IDCriterioAderencia
                            };
                            dadosProduto.Segmento = new Segmento()
                            {
                              IDSegmento = entidadeSegmento.IDSegmento
                            };
                            dadosProduto.VersaoProdutoFator = new VersaoProdutoFator()
                            {
                                IdVersaoProdutoFator = entidadeProdutoNivel.VersaoProdutoFator.IdVersaoProdutoFator
                            };
                            oProduto.NovoCriterioAderenciaSegmento(dadosProduto);
                        }


                    }
                }
            }
        }
    }
}

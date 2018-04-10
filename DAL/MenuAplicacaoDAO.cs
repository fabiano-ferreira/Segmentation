using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ApplicationBlocks.Data;
using VO;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DAL
{
    public class MenuAplicacaoDAO:BaseCRUD<MenuAplicacao>
    {

        #region BaseCRUD<MenuAplicacao> Members

        public void Novo(MenuAplicacao entidade)
        {
            throw new NotImplementedException();
        }

        public void Remover(MenuAplicacao entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(MenuAplicacao entidade)
        {
            throw new NotImplementedException();
        }

        public MenuAplicacao Listar(MenuAplicacao entidade)
        {
            throw new NotImplementedException();
        }

        public List<MenuAplicacao> Listar()
        {
            throw new NotImplementedException();
        }

        public List<MenuAplicacao> ListarPermissao(Usuario entidade)
        {
            List<MenuAplicacao> dadosMenuAplicacao = new List<MenuAplicacao>();

            SqlParameter parm = new SqlParameter()
             {
                 DbType = DbType.Int32,
                 Direction = ParameterDirection.Input,
                 ParameterName = "@IDUsuario",
                 Value = entidade.IDUsuario
             };
            using (IDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, CommandType.StoredProcedure, "UsuarioPermissaoListar", parm))
            {
                while (reader.Read())
                {
                    dadosMenuAplicacao.Add(new MenuAplicacao()
                    {
                        Nome = reader["Nome"].ToString(),
                        Endereco = reader["Endereco"].ToString(),
                        IdPai = (reader["IdPai"] is DBNull) ? 0 : Convert.ToInt32(reader["IdPai"]),
                        IdMenuAplicacao = (reader["IdMenuAplicacao"] is DBNull) ? 0 : Convert.ToInt32(reader["IdMenuAplicacao"])
                    });
                }
                return dadosMenuAplicacao;
            }
        }


        #endregion
    }
}

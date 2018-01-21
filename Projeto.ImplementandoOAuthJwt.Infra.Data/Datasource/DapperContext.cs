using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Projeto.ImplementandoOAuthJwt.Infra.Data.Datasource
{
    public class DapperContext
    {
        public IDbConnection DbConnection { get; set; }

        public DapperContext()
        {
            DbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString);
            DbConnection.Open();
        }
    }
}
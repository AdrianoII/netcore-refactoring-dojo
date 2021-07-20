using System.Data;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.Interfaces.ConnectionHandlers;

namespace MeuAcerto.Selecao.KataGildedRose.Infrastructure.ConnectionHandlers
{
    public class PostgresConnectionHandler : IDbConnectionHandler
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; private set; }

        public PostgresConnectionHandler(IDbConnection dbConnection)
        {
            Connection = dbConnection;
            Connection.Open();
        }

        public void BeginTransaction()
        {
            Transaction = Connection?.BeginTransaction();
        }

        public void Commit()
        {
            Transaction?.Commit();
        }

        public void Rollback()
        {
            Transaction?.Rollback();
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Connection?.Dispose();
        }
    }
}
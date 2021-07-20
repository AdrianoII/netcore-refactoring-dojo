using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.UnityOfWork;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.Interfaces.ConnectionHandlers;

namespace MeuAcerto.Selecao.KataGildedRose.Infrastructure.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly IDbConnectionHandler _dbConnectionHandler;

        public UnityOfWork(IDbConnectionHandler dbConnectionHandler)
        {
            _dbConnectionHandler = dbConnectionHandler;
        }

        public void BeginTransaction()
        {
            _dbConnectionHandler.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _dbConnectionHandler.Commit();
            }
            catch
            {
                Rollback();
            }
        }

        public void Rollback()
        {
            _dbConnectionHandler.Rollback();
        }
    }
}
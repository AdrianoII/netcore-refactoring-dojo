using System;
using System.Data;

namespace MeuAcerto.Selecao.KataGildedRose.Infrastructure.Interfaces.ConnectionHandlers
{
    public interface IDbConnectionHandler : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
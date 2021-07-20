using System.Collections.Generic;
using System.Reflection;
using Dapper;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Repositories;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.Exceptions;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.Interfaces.ConnectionHandlers;

namespace MeuAcerto.Selecao.KataGildedRose.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly string DataBaseTableName = typeof(T).Name;

        private const BindingFlags OnlyEntityFields =
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly;

        protected readonly PropertyInfo[] DataBaseCols = typeof(T).GetProperties(OnlyEntityFields);

        protected readonly IDbConnectionHandler DbConnectionHandler;

        protected RepositoryBase(IDbConnectionHandler dbConnectionHandler)
        {
            DbConnectionHandler = dbConnectionHandler;
        }

        public T Read(long id)
        {
            string readQuery = $"SELECT * FROM {DataBaseTableName} WHERE id = {id}";
            T entiy = DbConnectionHandler.Connection.QueryFirstOrDefault<T>(readQuery);

            if (entiy is null)
            {
                throw new EntityNotFoundException<T>();
            }

            return entiy;
        }

        public IEnumerable<T> All()
        {
            string allQuery = $"SELECT * FROM {DataBaseTableName}";
            return DbConnectionHandler.Connection.Query<T>(allQuery);
        }

        public IEnumerable<long> GetIds()
        {
            string selectIdsQuery = $"SELECT id FROM {DataBaseTableName}";
            return DbConnectionHandler.Connection.Query<long>(selectIdsQuery);
        }
    }
}
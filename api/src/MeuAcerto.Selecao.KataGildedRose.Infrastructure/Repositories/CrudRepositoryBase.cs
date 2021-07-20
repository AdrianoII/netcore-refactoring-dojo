using System;
using System.Linq;
using Dapper;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.Exceptions;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.Interfaces.ConnectionHandlers;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Repositories;

namespace MeuAcerto.Selecao.KataGildedRose.Infrastructure.Repositories
{
    public abstract class CrudRepositoryBase<T> : RepositoryBase<T>, ICrudRepositoryBase<T> where T : EntityBase, new()
    {
        protected CrudRepositoryBase(IDbConnectionHandler dbConnectionHandler) : base(dbConnectionHandler)
        {
        }

        public void Create(T entity)
        {
            string colNames = String.Join(", ", DataBaseCols.Select(c => c.Name));
            string paramNames = String.Join(", ", DataBaseCols.Select(c => $"@{c.Name}"));
            string createQuery = $"INSERT INTO {DataBaseTableName}({colNames}) VALUES({paramNames})";

            int rowsAffected =  DbConnectionHandler.Connection.Execute(createQuery, entity,
                transaction: DbConnectionHandler.Transaction);

            if (rowsAffected != 1)
            {
                throw new InsertFailedException<T>();
            }
        }

        public void Update(T entity)
        {
            string sets = String.Join(", ", DataBaseCols.Select(c => $"{c.Name} = @{c.Name}"));
            string updateQuery = $"UPDATE {DataBaseTableName} SET {sets} WHERE id = @id";
            int rowsAffected = DbConnectionHandler.Connection.Execute(updateQuery, entity,
                transaction: DbConnectionHandler.Transaction);
            
            if (rowsAffected != 1)
            {
                throw new UpdateFailedException<T>();
            }
        }

        public void Delete(long id)
        {
            var deleteQuery = $"DELETE FROM {DataBaseTableName} WHERE id = {id}";
            int rowsAffected = DbConnectionHandler.Connection.Execute(deleteQuery, transaction: DbConnectionHandler.Transaction);
            
            if (rowsAffected != 1)
            {
                throw new DeleteFailedException<T>();
            }
        }
    }
}
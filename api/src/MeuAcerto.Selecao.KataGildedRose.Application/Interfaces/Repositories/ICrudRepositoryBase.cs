using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;

namespace MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Repositories
{
    public interface ICrudRepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(long id);

    }
}
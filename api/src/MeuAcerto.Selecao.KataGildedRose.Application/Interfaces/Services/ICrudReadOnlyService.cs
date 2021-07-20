using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;

namespace MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services
{
    public interface ICrudReadOnlyService<T> : IReadOnlyService<T> where T : EntityBase
    {
        void Create(T entity, bool isIndependentOp = true);
        void Update(T entity, bool isIndependentOp = true);
        void Delete(long id, bool isIndependentOp = true);
    }
}
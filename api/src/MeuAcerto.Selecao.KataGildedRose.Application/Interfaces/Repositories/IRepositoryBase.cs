using System.Collections.Generic;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;

namespace MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        T Read(long id);
        IEnumerable<T> All();
        IEnumerable<long> GetIds();
    }
}
using System.Collections.Generic;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;

namespace MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services
{
    public interface IReadOnlyService<T> where T : EntityBase
    {
        T Read(long id);
        IEnumerable<T> All();
        IEnumerable<long> GetIds();
    }
}
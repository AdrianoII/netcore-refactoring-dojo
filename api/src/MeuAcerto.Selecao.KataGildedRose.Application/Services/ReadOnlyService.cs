using System.Collections.Generic;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Repositories;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.UnityOfWork;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;

namespace MeuAcerto.Selecao.KataGildedRose.Application.Services
{
    public abstract class ReadOnlyService<T> : ServiceBase,  IReadOnlyService<T> where T : EntityBase
    {
        private readonly IRepositoryBase<T> _repository;

        protected ReadOnlyService(IRepositoryBase<T> repository, IUnityOfWork uow) : base(uow)
        {
            _repository = repository;
        }

        public T Read(long id)
        {
            return _repository.Read(id);
        }

        public IEnumerable<T> All()
        {
            return _repository.All();
        }

        public IEnumerable<long> GetIds()
        {
            return _repository.GetIds();
        }
    }
}
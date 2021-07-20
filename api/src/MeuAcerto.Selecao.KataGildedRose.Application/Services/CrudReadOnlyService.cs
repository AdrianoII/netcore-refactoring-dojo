using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Repositories;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.UnityOfWork;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;

namespace MeuAcerto.Selecao.KataGildedRose.Application.Services
{
    public abstract class CrudReadOnlyService<T> : ReadOnlyService<T>, ICrudReadOnlyService<T> where T : EntityBase
    {
        private readonly ICrudRepositoryBase<T> _repository;

        protected CrudReadOnlyService(ICrudRepositoryBase<T> repository, IUnityOfWork uow) : base(repository, uow)
        {
            _repository = repository;
        }

        public void Create(T entity, bool isIndependentOp = true)
        {
            if (isIndependentOp)
            {
                Uow.BeginTransaction();
            }

            _repository.Create(entity);

            if (isIndependentOp)
            {
                Uow.Commit();
            }
        }

        public void Update(T entity, bool isIndependentOp = true)
        {
            if (isIndependentOp)
            {
                Uow.BeginTransaction();
            }

            _repository.Update(entity);

            if (isIndependentOp)
            {
                Uow.Commit();
            }
        }

        public void Delete(long id, bool isIndependentOp = true)
        {
            if (isIndependentOp)
            {
                Uow.BeginTransaction();
            }

            _repository.Delete(id);

            if (isIndependentOp)
            {
                Uow.Commit();
            }
        }
    }
}
using System;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Repositories;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.UnityOfWork;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Domain.Interfaces.UseCases;

namespace MeuAcerto.Selecao.KataGildedRose.Application.Services
{
    public class ItemService : CrudReadOnlyService<Item>, IItemService
    {
        private readonly IItemRepository _repository;
        private readonly IAtualizarItemQualidadeUseCase _atualizarItemQualidadeUseCase;

        public ItemService(IItemRepository repository,
            IAtualizarItemQualidadeUseCase atualizarItemQualidadeUseCase, IUnityOfWork uow) : base(repository, uow)
        {
            _repository = repository;
            _atualizarItemQualidadeUseCase = atualizarItemQualidadeUseCase;
        }

        public Item AtualizarQualidade(long id, bool isIndependentOp = true)
        {
            return AtualizarQualidade(id, DateTime.Today, isIndependentOp);
        }
        
        public Item AtualizarQualidade(long id, DateTime compareDay, bool isIndependentOp = true)
        {
            if (isIndependentOp)
            {
                Uow.BeginTransaction();
            }
            
            Item item = _repository.Read(id);
            
            _atualizarItemQualidadeUseCase.AtualizarQualidade(item, compareDay);

            _repository.Update(item);
            if (isIndependentOp)
            {
                Uow.Commit();
            }
            return  item;
        }
    }
}
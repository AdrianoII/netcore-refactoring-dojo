using System;
using System.Collections.Generic;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.UnityOfWork;

namespace MeuAcerto.Selecao.KataGildedRose.Application.Services
{
    public class EstoqueService : ServiceBase, IEstoqueService

    {
        private readonly IItemService _itemService;

        public EstoqueService(IItemService itemService, IUnityOfWork uow) : base(uow)
        {
            _itemService = itemService;
        }


        public void AtualizarQualidadeEstoque(int dias, bool isIndependentOp = true)
        {
            IEnumerable<long> estoque = _itemService.GetIds();

            Uow.BeginTransaction();

            for (int day = 0; day < dias; day++)
            {
                try
                {
                    foreach (var item in estoque)
                    {
                        _itemService.AtualizarQualidade(item, DateTime.Today.AddDays(day - 1), false);
                    }
                }
                catch
                {
                    // Caso ocorra alguma falha ao atualizar qualidade de um item, reverte as mudanças feitas
                    Uow.Rollback();
                    throw;
                }
            }

            Uow.Commit();
        }
    }
}
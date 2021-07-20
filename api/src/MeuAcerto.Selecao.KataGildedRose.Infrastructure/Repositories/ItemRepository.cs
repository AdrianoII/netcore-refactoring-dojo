using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Repositories;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Infrastructure.Interfaces.ConnectionHandlers;

namespace MeuAcerto.Selecao.KataGildedRose.Infrastructure.Repositories
{
    public class ItemRepository : CrudRepositoryBase<Item>, IItemRepository
    {
        public ItemRepository(IDbConnectionHandler dbConnectionHandler) : base(dbConnectionHandler)
        {
        }
    }
}
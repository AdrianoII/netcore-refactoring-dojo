using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services;
using MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.UnityOfWork;

namespace MeuAcerto.Selecao.KataGildedRose.Application.Services
{
    public abstract class ServiceBase : IServiceBase
    {
        protected readonly IUnityOfWork Uow;

        protected ServiceBase(IUnityOfWork uow)
        {
            Uow = uow;
        }
    }
}
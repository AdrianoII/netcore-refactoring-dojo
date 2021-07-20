namespace MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.UnityOfWork
{
    public interface IUnityOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
namespace MeuAcerto.Selecao.KataGildedRose.Application.Interfaces.Services
{
    public interface IEstoqueService
    {
        /// <summary>
        /// Atualiza a qualidade de todos os itens do estoque
        /// </summary>
        /// <returns>Booleano representando o resultado da operação</returns>
        void AtualizarQualidadeEstoque(int dias, bool isIndependentOp = true);
    }
}
namespace MeuAcerto.Selecao.KataGildedRose.Domain.Enums
{
    /// <summary>
    /// Representação das possíveis categorias que um item pode ter.
    /// </summary>
    public enum ItemCategoria
    {
        /// <summary>
        /// Engloba itens comuns, que não possuem específicidades
        /// </summary>
        Comum,
        /// <summary>
        /// Itens que não precisam de um prazo de validade e que não perdem qualidade
        /// </summary>
        Lendario,
        /// <summary>
        /// Itens que ganham qualidade com o passar do tempo
        /// </summary>
        Temporal,
        /// <summary>
        /// Itens que valorizam com o tempo, porém perdem totalmente seu valor após o prazo de validade
        /// </summary>
        Ingresso,
        /// <summary>
        /// Itens que perdem qualidade duas vezes mais rápido do que itens comuns
        /// </summary>
        Conjurado
    }
}
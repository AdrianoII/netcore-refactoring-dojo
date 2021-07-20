namespace MeuAcerto.Selecao.KataGildedRose.Domain.Entities
{   
    /// <summary>
    /// Abstração contendo os campos bases de um entidade
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Identificador da entidade
        /// </summary>
        /// <example>1</example>
        public long Id { get; set; }
    }
}
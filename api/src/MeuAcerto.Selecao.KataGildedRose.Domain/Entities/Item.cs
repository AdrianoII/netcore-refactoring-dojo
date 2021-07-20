using System;
using MeuAcerto.Selecao.KataGildedRose.Domain.Enums;

namespace MeuAcerto.Selecao.KataGildedRose.Domain.Entities
{    /// <summary>
    /// Representação dos itens comercializados em nossa belissíma pousada
    /// </summary>
    public class Item : EntityBase
    {
        /// <summary>
        /// Nome do item
        /// </summary>
        /// <example>Corselete +5 DEX</example>
        public string Nome { get; set; }

        /// <summary>
        /// Prazo de validade do item
        /// </summary>
        /// <example>2021-07-25</example>
        public DateTime? PrazoValidade { get; set; }

        /// <summary>
        /// Qualidade do Item
        /// </summary>
        /// <example>20</example>
        public int Qualidade { get; set; }
        
        /// <summary>
        /// Categoria do item
        /// </summary>
        /// <example>0</example>
        public ItemCategoria Categoria { get; set; }
    }
}

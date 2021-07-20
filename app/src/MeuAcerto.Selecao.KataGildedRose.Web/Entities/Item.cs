using System;

namespace MeuAcerto.Selecao.KataGildedRose.Web.Entities
{
    public class Item
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public int Qualidade { get; set; }
        public DateTime? PrazoValidade { get; set; }
        public string Categoria { get; set; }
    }
}
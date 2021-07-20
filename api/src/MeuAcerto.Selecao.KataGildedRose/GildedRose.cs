using System.Collections.Generic;

namespace MeuAcerto.Selecao.KataGildedRose
{
    class GildedRose
    {
        IList<Item> Itens;
        public GildedRose(IList<Item> Itens)
        {
            this.Itens = Itens;
        }

        public void AtualizarQualidade()
        {
            for (var i = 0; i < Itens.Count; i++)
            {
                if (Itens[i].Nome != "Queijo Brie Envelhecido" && Itens[i].Nome != "Ingressos para o concerto do TAFKAL80ETC")
                {
                    if (Itens[i].Qualidade > 0)
                    {
                        if (Itens[i].Nome != "Sulfuras, a Mão de Ragnaros")
                        {
                            Itens[i].Qualidade = Itens[i].Qualidade - 1;
                        }
                    }
                }
                else
                {
                    if (Itens[i].Qualidade < 50)
                    {
                        Itens[i].Qualidade = Itens[i].Qualidade + 1;

                        if (Itens[i].Nome == "Ingressos para o concerto do TAFKAL80ETC")
                        {
                            if (Itens[i].PrazoValidade < 11)
                            {
                                if (Itens[i].Qualidade < 50)
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade + 1;
                                }
                            }

                            if (Itens[i].PrazoValidade < 6)
                            {
                                if (Itens[i].Qualidade < 50)
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade + 1;
                                }
                            }
                        }
                    }
                }

                if (Itens[i].Nome != "Sulfuras, a Mão de Ragnaros")
                {
                    Itens[i].PrazoValidade = Itens[i].PrazoValidade - 1;
                }

                if (Itens[i].PrazoValidade < 0)
                {
                    if (Itens[i].Nome != "Queijo Brie Envelhecido")
                    {
                        if (Itens[i].Nome != "Ingressos para o concerto do TAFKAL80ETC")
                        {
                            if (Itens[i].Qualidade > 0)
                            {
                                if (Itens[i].Nome != "Sulfuras, a Mão de Ragnaros")
                                {
                                    Itens[i].Qualidade = Itens[i].Qualidade - 1;
                                }
                            }
                        }
                        else
                        {
                            Itens[i].Qualidade = Itens[i].Qualidade - Itens[i].Qualidade;
                        }
                    }
                    else
                    {
                        if (Itens[i].Qualidade < 50)
                        {
                            Itens[i].Qualidade = Itens[i].Qualidade + 1;
                        }
                    }
                }
            }
        }
    }
}

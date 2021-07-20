using FluentValidation;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;
using MeuAcerto.Selecao.KataGildedRose.Domain.Enums;

namespace MeuAcerto.Selecao.KataGildedRose.Domain.Validators
{
    public class ItemValidator : AbstractValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(item => item.Categoria).IsInEnum();
            RuleFor(item => item.Qualidade).GreaterThanOrEqualTo(0);

            When(item => item.Categoria != ItemCategoria.Lendario, () =>
            {
                RuleFor(item => item.PrazoValidade).NotNull();
                RuleFor(item => item.Qualidade).LessThanOrEqualTo(50);
            });
        }
    }
}
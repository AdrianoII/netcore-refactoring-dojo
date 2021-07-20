using System;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;

namespace MeuAcerto.Selecao.KataGildedRose.Infrastructure.Exceptions
{
    [Serializable]
    public class UpdateFailedException<T> : Exception where T : EntityBase
    {
        public UpdateFailedException()
        {
        }

        public UpdateFailedException(string message)
            : base(message)
        {
        }

        public UpdateFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
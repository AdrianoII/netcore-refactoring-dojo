using System;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;

namespace MeuAcerto.Selecao.KataGildedRose.Infrastructure.Exceptions
{
    [Serializable]
    public class InsertFailedException<T> : Exception where T : EntityBase
    {
        public InsertFailedException()
        {
        }

        public InsertFailedException(string message)
            : base(message)
        {
        }

        public InsertFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
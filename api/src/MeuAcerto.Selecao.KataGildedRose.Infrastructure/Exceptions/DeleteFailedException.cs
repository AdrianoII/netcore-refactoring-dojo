using System;
using MeuAcerto.Selecao.KataGildedRose.Domain.Entities;

namespace MeuAcerto.Selecao.KataGildedRose.Infrastructure.Exceptions
{
    [Serializable]
    public class DeleteFailedException<T> : Exception where T : EntityBase 
    {
        public DeleteFailedException()
        {
        }

        public DeleteFailedException(string message)
            : base(message)
        {
        }

        public DeleteFailedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
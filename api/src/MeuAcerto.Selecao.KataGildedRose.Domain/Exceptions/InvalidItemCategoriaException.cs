using System;

namespace MeuAcerto.Selecao.KataGildedRose.Domain.Exceptions
{
    [Serializable]
    public class InvalidItemCategoriaException : Exception
    {
        public InvalidItemCategoriaException() { }

        public InvalidItemCategoriaException(string message)
            : base(message) { }

        public InvalidItemCategoriaException(string message, Exception inner)
            : base(message, inner) { }

    }
}
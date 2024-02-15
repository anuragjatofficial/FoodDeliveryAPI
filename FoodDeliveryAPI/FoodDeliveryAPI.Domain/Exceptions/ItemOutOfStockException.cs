using System.Runtime.Serialization;

namespace FoodDeliveryAPI.Domain.Exceptions
{
    [Serializable]
    internal class ItemOutOfStockException : Exception
    {
        public ItemOutOfStockException()
        {
        }

        public ItemOutOfStockException(string? message) : base(message)
        {
        }

        public ItemOutOfStockException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ItemOutOfStockException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
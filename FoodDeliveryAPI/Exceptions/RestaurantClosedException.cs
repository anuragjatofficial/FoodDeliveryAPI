using System.Runtime.Serialization;

namespace FoodDeliveryAPI.Exceptions
{
    [Serializable]
    internal class RestaurantClosedException : Exception
    {
        public RestaurantClosedException()
        {
        }

        public RestaurantClosedException(string? message) : base(message)
        {
        }

        public RestaurantClosedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RestaurantClosedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
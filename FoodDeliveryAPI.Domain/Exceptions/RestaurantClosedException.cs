using System.Runtime.Serialization;

namespace FoodDeliveryAPI.Domain.Exceptions
{
    [Serializable]
    public class RestaurantClosedException : Exception
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
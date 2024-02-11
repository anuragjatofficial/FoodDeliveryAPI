using System.Runtime.Serialization;

namespace FoodDeliveryAPI.Domain.Exceptions
{
    [Serializable]
    public class RestaurantNotFoundException : Exception
    {
        public RestaurantNotFoundException()
        {
        }

        public RestaurantNotFoundException(string? message) : base(message)
        {
        }

        public RestaurantNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected RestaurantNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
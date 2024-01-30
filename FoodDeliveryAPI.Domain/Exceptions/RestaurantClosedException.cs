using System.Runtime.Serialization;

<<<<<<< HEAD:FoodDeliveryAPI.Domain/Exceptions/RestaurantClosedException.cs
namespace FoodDeliveryAPI.Domain.Exceptions
{
    [Serializable]
    public class RestaurantClosedException : Exception
=======
namespace FoodDeliveryAPI.Exceptions
{
    [Serializable]
    internal class RestaurantClosedException : Exception
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/Exceptions/RestaurantClosedException.cs
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
using System.Runtime.Serialization;

namespace FoodDeliveryAPI.Domain.Exceptions
{
    [Serializable]
    public class AdminNotFoundException : Exception
    {
        public AdminNotFoundException()
        {
        }

        public AdminNotFoundException(string? message) : base(message)
        {
        }

        public AdminNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected AdminNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
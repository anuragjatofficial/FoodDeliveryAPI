using System.Runtime.Serialization;

namespace FoodDeliveryAPI.Domain.Exceptions
{
    [Serializable]
    public class StatusAlreadyUpdatedException : Exception
    {
        public StatusAlreadyUpdatedException()
        {
        }

        public StatusAlreadyUpdatedException(string? message) : base(message)
        {
        }

        public StatusAlreadyUpdatedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected StatusAlreadyUpdatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
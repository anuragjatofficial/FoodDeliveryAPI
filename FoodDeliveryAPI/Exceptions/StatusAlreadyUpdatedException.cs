using System.Runtime.Serialization;

namespace FoodDeliveryAPI.Exceptions
{
    [Serializable]
    internal class StatusAlreadyUpdatedException : Exception
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
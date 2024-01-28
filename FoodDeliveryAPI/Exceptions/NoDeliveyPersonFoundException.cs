using System.Runtime.Serialization;

namespace FoodDeliveryAPI.Exceptions
{
    [Serializable]
    internal class NoDeliveyPersonFoundException : Exception
    {
        public NoDeliveyPersonFoundException()
        {
        }

        public NoDeliveyPersonFoundException(string? message) : base(message)
        {
        }

        public NoDeliveyPersonFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoDeliveyPersonFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
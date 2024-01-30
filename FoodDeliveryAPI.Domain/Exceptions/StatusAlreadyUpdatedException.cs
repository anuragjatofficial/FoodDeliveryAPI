using System.Runtime.Serialization;

<<<<<<< HEAD:FoodDeliveryAPI.Domain/Exceptions/StatusAlreadyUpdatedException.cs
namespace FoodDeliveryAPI.Domain.Exceptions
{
    [Serializable]
    public class StatusAlreadyUpdatedException : Exception
=======
namespace FoodDeliveryAPI.Exceptions
{
    [Serializable]
    internal class StatusAlreadyUpdatedException : Exception
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/Exceptions/StatusAlreadyUpdatedException.cs
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
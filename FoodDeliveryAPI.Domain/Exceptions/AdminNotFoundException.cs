using System.Runtime.Serialization;

<<<<<<< HEAD:FoodDeliveryAPI.Domain/Exceptions/AdminNotFoundException.cs
namespace FoodDeliveryAPI.Domain.Exceptions
{
    [Serializable]
    public class AdminNotFoundException : Exception
=======
namespace FoodDeliveryAPI.Exceptions
{
    [Serializable]
    internal class AdminNotFoundException : Exception
>>>>>>> 77c3c8d3869beb5d7929c4f1d13c2e05bd9b2655:FoodDeliveryAPI/Exceptions/AdminNotFoundException.cs
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
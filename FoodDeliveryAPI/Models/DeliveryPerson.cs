namespace FoodDeliveryAPI.Models
{
    public class DeliveryPerson : User
    {
        public List<Order> OrdersAssigned;
        public List<Order> OrdersDelivered;
        public List<Order> AllOrders;
    }
}
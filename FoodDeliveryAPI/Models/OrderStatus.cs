namespace FoodDeliveryAPI.Models
{
    public class OrderStatus
    {
        public static readonly string PLACED = "PLACED";
        public static readonly string ASSIGNED = "ASSIGNED";
        public static readonly string PREPARED = "PREPARED";
        public static readonly string PICKEDUP = "PICKEDUP";
        public static readonly string REACHED = "REACHED";
        public static readonly string DELIVERED = "DELIVERED";
        public static readonly string CANCELLED = "CANCELLED";
    }
}

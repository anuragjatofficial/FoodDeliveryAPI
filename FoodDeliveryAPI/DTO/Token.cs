namespace FoodDeliveryAPI.DTO
{
    public class Token
    {
        public string authToken {  get; set; }
        public DateTime IssuedAt { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}

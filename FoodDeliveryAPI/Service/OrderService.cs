using FoodDeliveryAPI.Data;
using FoodDeliveryAPI.Exceptions;
using FoodDeliveryAPI.Input;
using FoodDeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryAPI.Service
{
    public class OrderService : IOrderService
    {
        private readonly FoodDeliveryAPIContext _context;

        public OrderService(FoodDeliveryAPIContext context)
        {
            _context = context;
        }

        public async Task<Order> PlaceOrder(OrderDTO order)
        {
            List<Item> items = new List<Item>();
            foreach(Guid Id in order.ItemsId)
            {
                items.Add(FindOrderItemById(Id));
            }

            Order o = new Order()
            {
                CustomerId = order.CustomerId,
                RestaurantId = order.RestaurantId,
                Items = items,
                DeliveryPersonId = AssignDeliveryPerson().UserId,
                OrderStatus = OrderStatus.PLACED
            };

            await _context.Orders.AddAsync(o);
            await _context.SaveChangesAsync(); 
            return o;
        }

        public Item FindOrderItemById(Guid itemId)
        {
            return _context.Items.FirstOrDefault(o=>o.ItemId==itemId) ?? throw new ItemNotFoundException($"can't find any item with id {itemId}");
        }

        private DeliveryPerson AssignDeliveryPerson()
        {
            Random random = new Random();
            int toSkip = random.Next(0, _context.DeliveryPersons.Count());
            return _context.DeliveryPersons.OrderBy(r => Guid.NewGuid()).Skip(toSkip).Take(1).FirstOrDefault() ?? throw new NoDeliveyPersonFoundException($"can't find any available deliveryperson please try again later !");
        }

        public async Task<string> UpdateOrderStatus(string status,Guid orderId)
        {
            var order = await GetOrderByID(orderId);
            order.OrderStatus = status;
            await _context.SaveChangesAsync();
            return $"Order status maked as {status} succesfully";
        }

        public async Task<Order> GetOrderByID(Guid orderId)
        {
            return await _context.Orders.Include(a=>a.Items).FirstOrDefaultAsync(o => o.OrderId==orderId)?? throw new OrderNotFoundException($"can't find any order with id {orderId}");
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context.Orders.Include(a => a.Items).Include(a=>a.Restaurant).ToListAsync();
        }
    }
}

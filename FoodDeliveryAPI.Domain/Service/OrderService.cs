using FoodDeliveryAPI;
using Microsoft.EntityFrameworkCore;
using FoodDeliveryAPI.DataAcces.Data;
using FoodDeliveryAPI.DataAcces.Models;
using FoodDeliveryAPI.Domain.DTO;
using FoodDeliveryAPI.Domain.Exceptions;

namespace FoodDeliveryAPI.Domain.Service
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
            var restaurant = _context.Restaurants.FirstOrDefault(u=>u.RestaurantId==order.RestaurantId) ?? throw new RestaurantNotFoundException($"can't find any restaurant with id {order.RestaurantId}");
            var customer = _context.Customers.FirstOrDefault(u => u.UserId == order.CustomerId) ?? throw new CustomerNotFoundException($"can't find customer with id {order.CustomerId}");
            if (restaurant.IsClosed)
            {
                throw new RestaurantClosedException($"can't place order because restaurant is closed");
            }
            var deliveryPerson = AssignDeliveryPerson();
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
                DeliveryPersonId = deliveryPerson.UserId,
                OrderStatus = OrderStatus.RECEIVED
            };
            deliveryPerson.AllOrders.Add(o);
            customer.Orders.Add(o);
            await _context.Orders.AddAsync(o);
            await _context.SaveChangesAsync(); 
            return o;
        }

        // linq 

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
            if(order.OrderStatus ==  status)
            {
                throw new StatusAlreadyUpdatedException($"status is already updated as {status}");
            }

            if (order.ValidStatuses.Contains(status))
            {
                switch(status)
                {
                    case "PLACED":
                        order.ValidStatuses.Remove(OrderStatus.PLACED);
                        order.ValidStatuses.Add(OrderStatus.ASSIGNED);
                        break;
                    case "ASSIGNED":
                        order.ValidStatuses.Remove(OrderStatus.ASSIGNED);
                        order.ValidStatuses.Add(OrderStatus.PREPARED);
                        break;
                    case "PREPARED":
                        order.ValidStatuses.Remove(OrderStatus.PREPARED);
                        order.ValidStatuses.Add(OrderStatus.PICKEDUP);
                        break;
                    case "REACHED":
                        order.ValidStatuses.Remove(OrderStatus.REACHED);
                        order.ValidStatuses.Add(OrderStatus.DELIVERED);
                        break;
                    case "DELIVERED":
                        order.ValidStatuses.Clear();
                        break;
                    case "CANCELLED":
                        order.ValidStatuses.Clear();
                        break;
                    default: break;
                }
                order.OrderStatus = status;
                await _context.SaveChangesAsync();
                return $"Order status maked as {status} succesfully";
            }

            throw new StatusAlreadyUpdatedException($"can't update status from {order.OrderStatus} to {status}");
        }

        public async Task<Order> GetOrderByID(Guid orderId)
        {
            return await _context
                            .Orders
                            .Include(a=>a.Items)
                            .FirstOrDefaultAsync(o => o.OrderId==orderId)?? throw new OrderNotFoundException($"can't find any order with id {orderId}");
        }

        public async Task<List<Order>> GetAllOrders()
        {
            return await _context
                            .Orders
                            .Include(a => a.Items)
                            .Include(a=>a.Restaurant)
                            .ToListAsync();
        }
    }
}

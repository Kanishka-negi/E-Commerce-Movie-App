using Microsoft.AspNetCore.Components.Routing;
using Microsoft.EntityFrameworkCore;
using Movie_Web_Mvc.Models;

namespace Movie_Web_Mvc.Service
{
    public class OrderServices : IOrderServices
    {
        private readonly AppDbContext _context;
        public OrderServices(AppDbContext context)
        {
            _context = context;
        }

        public List<Order> GetOrdersByUserIdAndRole(string userId, string userRole)
        {
            var orders = _context.Order.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Include(n => n.UserId).ToList();
            if (userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }
    

        public void StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            _context.Order.Add(order);
            _context.SaveChanges();
            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    OrderId = order.Id,
                    Price = item.Movie.Price
                };
                _context.OrderItems.Add(orderItem);
            }
            _context.SaveChanges();
        }
    }
}

     ﻿
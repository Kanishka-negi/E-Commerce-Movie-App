using Movie_Web_Mvc.Models;
using System.Collections.Generic;

namespace Movie_Web_Mvc.Service
{
    public interface IOrderServices
    {
        void StoreOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress);
        List<Order> GetOrdersByUserIdAndRole(string userId, string userRole);
    }
}

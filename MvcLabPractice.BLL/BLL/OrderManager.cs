using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcLabPractice.Model.Model;
using MvcLabPractice.Repository.Repository;

namespace MvcLabPractice.BLL.BLL
{
   public class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();
        public bool Add(Order order)
        {
            return _orderRepository.Add(order);
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

    }
}

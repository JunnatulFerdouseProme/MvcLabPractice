using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using  MvcLabPractice.DatabaseContext.DatabaseContext;
using  MvcLabPractice.Model.Model;

namespace MvcLabPractice.Repository.Repository
{
   public  class OrderRepository
    {
        ProjectDbContext _dbContext=new ProjectDbContext();
        public bool Add(Order order)
        {
            _dbContext.Orders.Add(order);


            return _dbContext.SaveChanges() > 0;
        }

        public List<Order> GetAll()
        {

            return _dbContext.Orders.Include(c=>c.Member).ToList();
        }
    }
}

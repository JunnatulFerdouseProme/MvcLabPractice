using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLabPractice.Model.Model
{
    public class FoodItem
    {
        public FoodItem()
        {
            Orders = new List<Order>();
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Order> Orders { get; set; } // Lazy Loading
    }
}

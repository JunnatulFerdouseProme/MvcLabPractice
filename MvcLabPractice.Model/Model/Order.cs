using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLabPractice.Model.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int FoodItemId { get; set; }
        public int MemberItemId { get; set; }
        public int UnitPrice { get; set; }
        public int Qauntity { get; set; }
        public DateTime Date { get; set; }
        public FoodItem FoodItem { get; set; }
        public  Member Member { get; set; }
    }
}

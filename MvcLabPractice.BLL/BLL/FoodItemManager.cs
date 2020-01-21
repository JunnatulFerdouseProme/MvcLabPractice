using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcLabPractice.Model.Model;
using MvcLabPractice.Repository.Repository;

namespace MvcLabPractice.BLL.BLL
{
    public class FoodItemManager
    {
        FoodItemRepository _foodItemRepository=new FoodItemRepository();

        public List<FoodItem> GetAll()
        {
            return _foodItemRepository.GetAll();
        }
    }
}

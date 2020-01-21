using System;
using System.Collections.Generic;
using System.Linq;
using  System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using  MvcLabPractice.Model.Model;
using MvcLabPractice.DatabaseContext.DatabaseContext;
using Type = MvcLabPractice.Model.Model.Type;

namespace MvcLabPractice.Repository.Repository
{
    
    public class FoodItemRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public List<FoodItem> GetAll()
        {
            //return _dbContext.Departments.ToList();
            //return _dbContext.Departments.Include(c=>c.Students).ToList(); //Eagar Loading

            var fooditems = _dbContext.FoodItems.ToList();



            return fooditems;

        }


    }
}

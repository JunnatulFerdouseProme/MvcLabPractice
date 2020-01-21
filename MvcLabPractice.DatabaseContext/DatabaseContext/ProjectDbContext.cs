using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using MvcLabPractice.Model.Model;
using Type = MvcLabPractice.Model.Model.Type;

namespace MvcLabPractice.DatabaseContext.DatabaseContext
{
    public class ProjectDbContext: DbContext 
    {
        public ProjectDbContext()
        {
            Configuration.LazyLoadingEnabled = false; // Disable Lazy Loading
        }

        public DbSet<Student> Students { set; get; }
        public DbSet<Department> Departments { set; get; }
        public DbSet<Member> Members { set; get; }
        public DbSet<Type> Types { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<FoodItem> FoodItems { set; get; }
    }
}

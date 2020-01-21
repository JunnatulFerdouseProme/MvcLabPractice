using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using MvcLabPractice.Model.Model;
using  MvcLabPractice.DatabaseContext.DatabaseContext;
using Type = MvcLabPractice.Model.Model.Type;

namespace MvcLabPractice.Repository.Repository
{
    public class TypeRepository
    {
        
            ProjectDbContext _dbContext = new ProjectDbContext();

            public bool Add(Type type)
            {
                _dbContext.Types.Add(type);


                return _dbContext.SaveChanges() > 0;
            }

           
            public List<Type> GetAll()
            {
                //return _dbContext.Departments.ToList();
                //return _dbContext.Departments.Include(c=>c.Students).ToList(); //Eagar Loading

                var types = _dbContext.Types.ToList();



                return types;

            }

            public Type GetById(int id)
            {

                return _dbContext.Types.FirstOrDefault((c => c.Id == id));
            }
        }
    
}

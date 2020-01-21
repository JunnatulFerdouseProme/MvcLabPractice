using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcLabPractice.Model.Model;
using MvcLabPractice.Repository.Repository;
using Type = MvcLabPractice.Model.Model.Type;

namespace MvcLabPractice.BLL.BLL
{
    public class TypeManger
    {
        TypeRepository _typeRepository=new TypeRepository();


        public bool Add(Type type)
        {
            return _typeRepository.Add(type);
        }

        public List<Type> GetAll()
        {
            return _typeRepository.GetAll();
        }
    }
}

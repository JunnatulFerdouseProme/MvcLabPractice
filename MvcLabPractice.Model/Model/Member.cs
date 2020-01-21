using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLabPractice.Model.Model
{
   public  class Member
    {
        public int Id { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        
        public string Email { set; get; }
        public string ContactNo { set; get; }
        public string TypeId { set; get; }
        public Type Type { get; set; }
    }
}

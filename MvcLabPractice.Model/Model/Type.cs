using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcLabPractice.Model.Model
{
    public class Type
    {
        public Type()
        {
            Members = new List<Member>();
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Member> Members { get; set; } // Lazy Loading
    }
}

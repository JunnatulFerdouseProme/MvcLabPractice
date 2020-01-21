using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using MvcLabPractice.Model.Model;
using MvcLabPractice.DatabaseContext.DatabaseContext;

namespace MvcLabPractice.Repository.Repository
{
    public class MemberRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Member member)
        {
            _dbContext.Members.Add(member);


            return _dbContext.SaveChanges() > 0;
        }
       
        public List<Member> GetAll()
        {

            return _dbContext.Members.Include(c=>c.Type).ToList();
        }
        public Member GetById(int id)
        {

            return _dbContext.Members.FirstOrDefault((c => c.Id == id));
        }
    }
}

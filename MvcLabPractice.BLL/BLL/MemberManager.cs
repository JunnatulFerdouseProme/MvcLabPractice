using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  MvcLabPractice.Model.Model;
using  MvcLabPractice.Repository.Repository;

namespace MvcLabPractice.BLL.BLL
{
    public class MemberManager
    {
        MemberRepository _memberRepository = new MemberRepository();
        public bool Add(Member member)
        {
            return _memberRepository.Add(member);
        }

        public List<Member> GetAll()
        {
            return _memberRepository.GetAll();
        }

        public Member GetById(int id)
        {
            return _memberRepository.GetById(id);
        }
    }
}

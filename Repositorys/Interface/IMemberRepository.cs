using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositorys.Interface
{
    public interface IMemberRepository
    {
        public List<Member> GetMembers();
        public List<Member> GetAllFamyliById(int id);
        public Member GetById(int id);
        public Member GetMemberByAccountId(string id);
        public void Add(Member member);
        public void UpdateAttach(Member member);
    }
}

using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.Interface
{
	public interface IMemberRepository
	{
        public List<Member> GetAllFamyliById(int id);
		public Member GetById(int id);
		public Member GetMemberByAccountId(string id);
		public void Add(Member member);
		public bool AddMemberFamilyTree(Member member, int relationId, int relationMemberId);
		public void UpdateAttach(Member member);
	}
}

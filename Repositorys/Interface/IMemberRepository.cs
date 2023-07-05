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
		public Member GetMemberByAccountId(string id);
	}
}

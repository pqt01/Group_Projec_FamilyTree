using BusinessObjects.Models;
using DataAccessObjects;
using Repositorys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
	public class MemberRepository : IMemberRepository
	{
		private readonly MemberDAO _context = new MemberDAO();
		public List<Member> GetAllFamyliById(int id) => _context.GetAllByFamyliId(id);
		public Member GetById(int id) => _context.GetById(id);
		public Member GetMemberByAccountId(string id) => _context.GetMemberByAccountId(id);
		public void Add(Member member) => _context.Add(member);
		public void UpdateAttach(Member member) => _context.UpdateAttach(member);
	}
}

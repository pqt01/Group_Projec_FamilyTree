using BusinessObjects.Models;
using DataAccessObjects;
using Repositorys.Interface;
using System.Collections.Generic;

namespace Repositorys
{
	public class MemberRepository : IMemberRepository
	{
		private readonly MemberDAO _context = new MemberDAO();
		private readonly CoupleDAO _cpDao = new CoupleDAO();
		public List<Member> GetAllFamyliById(int id) => _context.GetAllByFamyliId(id);
		public Member GetById(int id) => _context.GetById(id);
		public Member GetMemberByAccountId(string id) => _context.GetMemberByAccountId(id);
		public void Add(Member member) => _context.Add(member);
		public void UpdateAttach(Member member) => _context.UpdateAttach(member);
		public bool AddMemberFamilyTree(Member member, int relationId, int relationMemberId)
		{
			bool result = true;
			Member child = _context.GetById(relationMemberId);
			Couple couple = new Couple();
			switch (relationId)
			{
				//parent of
				case 1:
					if (!_cpDao.ValidParent(member, child)) return false;
					//create member
					_context.Add(member);
					//create couple
					couple = new Couple();
					if (member.Gender == true) { couple.FaId = member.Id; }
					else { couple.MoId = member.Id; }
					_cpDao.Add(couple);
					//update member relationship
					int id = _cpDao.GetMaxId();
					if (_cpDao.IsExistCouple(child))
					{
						couple = _cpDao.GetById(child.Id);
						couple.ParentId = _cpDao.GetMaxId();
						_cpDao.UpdateAttach(couple);
					}
					else
					{
						child.CoupleId = id;
						_context.UpdateAttach(child);
					}
					break;
				//couple of
				case 2:
					if (!_cpDao.ValidCouple(member, child)) return false;
					//create member
					_context.Add(member);
					//create couple
					if (_cpDao.IsExistCouple(child))
					{
						couple = _cpDao.GetById((int)child.CoupleId);
						if (member.Gender == true) { couple.FaId = member.Id; }
						else { couple.MoId = member.Id; }
						//change parent
						_cpDao.UpdateAttach(couple);
						//update couple Id
						member.CoupleId = couple.Id;
						_context.UpdateAttach(member);
					}
					else
					{
						couple = new Couple();
						if (child.CoupleId != null)
						{
							couple.ParentId = child.CoupleId;
						}
						if (member.Gender == true)
						{
							couple.FaId = member.Id;
							couple.MoId = child.Id;
						}
						else
						{
							couple.MoId = member.Id;
							couple.FaId = child.Id;
						}
						//craete couple
						_cpDao.Add(couple);
						//update member
						int tmpId = _cpDao.GetMaxId();
						child.CoupleId = tmpId;
						member.CoupleId = tmpId;
						_context.UpdateAttach(child);
					}
					break;
				//child of
				case 3:
					break;
				default:
					break;
			}
			return result;
		}
		public List<Member> GetMembers() => _context.GetAll();
	}
}

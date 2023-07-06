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
            switch (relationId)
            {
                //parent of
                case 1:
                    Member relationMember = _context.GetById(relationMemberId);
                    if (relationMember.CoupleId != null)
                    {
                        if (member.Gender)
                        {
                            //if(_cpDao.GetByFaId() != null);
                        }
                    }

                    //create member
                    _context.Add(member);
                    //create couple
                    Couple couple = new Couple();
                    if (member.Gender == true) { couple.FaId = member.Id; }
                    else { couple.MoId = member.Id; }
                    _cpDao.Add(couple);
                    //update member relationship
                    int id = _cpDao.GetMaxId();

                    relationMember.CoupleId = id;
                    _context.UpdateAttach(relationMember);
                    break;
                //couple of
                case 2:
                    break;
                //child of
                case 3:
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}

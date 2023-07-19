using BusinessObjects.Models;
using DataAccessObjects;
using Repositorys.Interface;
using System.Collections.Generic;

namespace Repositorys
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MemberDAO _context = new MemberDAO();
        private readonly MateDAO _mateDao = new MateDAO();
        public List<Member> GetAllFamyliById(int id) => _context.GetAllByFamyliId(id);
        public Member GetById(int id) => _context.GetById(id);
        public Member GetMemberByAccountId(string id) => _context.GetMemberByAccountId(id);
        public void Add(Member member) => _context.Add(member);
        public void UpdateAttach(Member member) => _context.UpdateAttach(member);
        void InitMate(Member member)
        {
            if (member.MateId == null)
            {
                Mate mate = new Mate();
                _mateDao.Add(mate);
                int mateId = _mateDao.GetMaxId();
                member.MateId = mateId;
                _context.UpdateAttach(member);
            }
        }
        public bool CreateMateMember(Member member, Member relationMember)
        {
            if (_mateDao.GenderIsValid(member, relationMember))
            {
                _context.Add(member);
                return true;
            }
            return false;
        }
        public bool AddMemberFamilyTree(Member member, int relationId, int relationMemberId)
        {
            bool result = true;
            Member child = _context.GetById(relationMemberId);
            Mate mate = new Mate();
            try
            {
                InitMate(child);
                switch (relationId)
                {
                    //parent of
                    case 1:
                        mate = _mateDao.GetById((int)child.MateId);
                        if (mate.ParentId == null)
                        {
                            _context.Add(member);
                            member.Id = _context.GetMaxId();
                            InitMate(member);
                            int parentId = _mateDao.GetMaxId();
                            mate.ParentId = parentId;
                            _mateDao.UpdateAttach(mate);
                        }
                        else
                        {
                            List<Member> parents = _context.GetByMateId((int)mate.ParentId);
                            bool isGenderValid = false;
                            foreach (var item in parents)
                            {
                                if (_mateDao.GenderIsValid(member, item))
                                {
                                    isGenderValid = true;
                                }
                            }
                            if (isGenderValid)
                            {
                                member.MateId = mate.ParentId;
                                _context.Add(member);
                            }
                        }
                        break;
                    //couple of
                    case 2:
                        member.MateId = child.MateId;
                        result = CreateMateMember(member, child);
                        break;
                    //child of
                    case 3:
                        _context.Add(member);
                        member.Id = _context.GetMaxId();
                        InitMate(member);
                        mate = _mateDao.GetById((int)member.MateId);
                        mate.ParentId = child.MateId;
                        _mateDao.UpdateAttach(mate);
                        break;
                    default:
                        break;
                }
        }
            catch (System.Exception)
            {
                result = false;
            }
            return result;
        }
        public List<Member> GetMembers() => _context.GetAll();
    }
}

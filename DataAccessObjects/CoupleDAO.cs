using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CoupleDAO
    {
        private FUFamilyTreeContext _context;
        public CoupleDAO()
        {
            _context = new FUFamilyTreeContext();
        }
        public int GetMaxId()
        {
            return _context.Couples.Max(c => c.Id);
        }
        public Couple GetById(int id)
        {
            return _context.Couples.FirstOrDefault(c => c.Id == id);
        }
        public bool IsExistCouple(Member member)
        {
            if (member.Gender) return _context.Couples
                .FirstOrDefault(c => c.FaId == member.Id) != null ? true : false;
            return _context.Couples
                .FirstOrDefault(c => c.MoId == member.Id) != null ? true : false;
        }
        public bool IsExistParent(Member parent, Member child)
        {
            bool result = false;
            var couple = _context.Couples.FirstOrDefault(c => c.Id == child.CoupleId);
            if (parent.Gender && couple.FaId != null)
            {
                result = true;
            }
            else if (!parent.Gender && couple.MoId != null)
            {
                result = true;
            }
            return result;
        }
        public bool ValidParent(Member parent, Member child)
        {
            //chua co coupleId
            if (child.CoupleId == null) return true;
            //check is couple
            if (IsExistCouple(child)) return true;
            //check parent is correct
            if (!IsExistParent(parent, child)) return true;
            return false;
        }
        public bool ValidCouple(Member member, Member relationMember)
        {
            //chua co coupleId
            if (relationMember.CoupleId == null) return true;
            //check gender
            if (relationMember.Gender == member.Gender) return false;
            return true;
        }
        public void Add(Couple couple)
        {
            _context.Add(couple);
            _context.SaveChanges();
        }
        public void UpdateAttach(Couple couple)
        {
            _context.Attach(couple).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

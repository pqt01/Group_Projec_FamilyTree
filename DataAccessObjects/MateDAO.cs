using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class MateDAO
    {
        private FUFamilyTreeContext _context;
        public MateDAO()
        {
            _context = new FUFamilyTreeContext();
        }
        public int GetMaxId()
        {
            return _context.Mates.Max(c => c.Id);
        }
        public Mate GetById(int id)
        {
            return _context.Mates.FirstOrDefault(c => c.Id == id);
        }
        //public bool IsExistMate(Member member)
        //{
        //    if (member.Gender) return _context.Mates
        //        .FirstOrDefault(c => c.FaId == member.Id) != null ? true : false;
        //    return _context.Mates
        //        .FirstOrDefault(c => c.MoId == member.Id) != null ? true : false;
        //}
        //public bool IsExistParent(Member parent, Member child)
        //{
        //    bool result = false;
        //    var Mate = _context.Mates.FirstOrDefault(c => c.Id == child.MateId);
        //    if (parent.Gender && Mate.FaId != null)
        //    {
        //        result = true;
        //    }
        //    else if (!parent.Gender && Mate.MoId != null)
        //    {
        //        result = true;
        //    }
        //    return result;
        //}
        //public bool ValidParent(Member parent, Member child)
        //{
        //    //chua co MateId
        //    if (child.MateId == null) return true;
        //    //check is Mate
        //    if (IsExistMate(child)) return true;
        //    //check parent is correct
        //    if (!IsExistParent(parent, child)) return true;
        //    return false;
        //}
        public bool GenderIsValid(Member member, Member relationMember)
        {
            return member.Gender != relationMember.Gender ? true : false;
        }
        public bool ValidMate(Member member, Member relationMember)
        {
            //chua co MateId
            if (relationMember.MateId == null) return true;
            //check gender
            if (relationMember.Gender == member.Gender) return false;
            return true;
        }
        public void Add(Mate Mate)
        {
            _context.Add(Mate);
            _context.SaveChanges();
        }
        public void UpdateAttach(Mate Mate)
        {
            _context.Attach(Mate).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

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
        }public Couple GetByFaId(int id)
        {
            return _context.Couples.FirstOrDefault(c => c.FaId == id);
        }
        public Couple GetByMoId(int id)
        {
            return _context.Couples.FirstOrDefault(c => c.MoId == id);
        }
        //public Member GetById(int id)
        //{
        //    return _context.Members.FirstOrDefault(m => m.Id == id);
        //}
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

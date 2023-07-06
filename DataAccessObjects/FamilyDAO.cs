using BusinessObjects.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class FamilyDAO
    {
        private FUFamilyTreeContext _context;
        public FamilyDAO()
        {
            _context = new FUFamilyTreeContext();
        }
        public Family GetByCreatorIdId(int creatorIdId)
        {
            return _context.Families.FirstOrDefault(m => m.CreatorId == creatorIdId);
        }
        public void Add(Family family)
        {
            _context.Add(family);
            _context.SaveChanges();
        }
        public List<Family> GetAll()
        {
            return _context.Families.ToList();
        }
    }
}

using BusinessObjects.Models;
using DataAccessObjects;
using Repositorys.Interface;
using System.Collections.Generic;

namespace Repositorys
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly FamilyDAO _context = new FamilyDAO();

        public Family GetByCreatorIdId(int creatorIdId) => _context.GetByCreatorIdId(creatorIdId);
        public void Add(Family family) => _context.Add(family);
        public List<Family> GetFamilies() => _context.GetAll();
    }
}

using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositorys.Interface
{
    public interface IFamilyRepository
    {
        public void Add(Family family);
        public Family GetByCreatorIdId(int creatorIdId);
        public List<Family> GetFamilies();
    }
}

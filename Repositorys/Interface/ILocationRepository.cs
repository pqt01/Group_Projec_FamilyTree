using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositorys.Interface
{
    public interface ILocationRepository
    {
        Location GetLocationById(int id);
        List<Location> GetListLocationByName(string name);
        List<Location> GetAll();
        void Add(Location location);
        void Update(Location location);
        void Delete(int id);
    }
}

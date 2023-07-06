using BusinessObjects.Models;
using DataAccessObjects;
using Repositorys.Interface;
using System.Collections.Generic;

namespace Repositorys
{
    public class LocationRepository : ILocationRepository
    {
        private LocationDAO _locationDAO;

        public LocationRepository()
        {
            _locationDAO = new LocationDAO();
        }

        public Location GetLocationById(int id)
        {
            return _locationDAO.GetLocationById(id);
        }

        public List<Location> GetListLocationByName(string name)
        {
            return _locationDAO.GetListLocationByName(name);
        }

        public List<Location> GetAll()
        {
            return _locationDAO.GetAll();
        }

        public void Add(Location location)
        {
            _locationDAO.Add(location);
        }

        public void Update(Location location)
        {
            _locationDAO.Update(location);
        }

        public void Delete(int id)
        {
            _locationDAO.Delete(id);
        }
    }
}

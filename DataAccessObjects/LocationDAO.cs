using BusinessObjects.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class LocationDAO
    {
        private FUFamilyTreeContext _dbContext;
        public LocationDAO()
        {
            _dbContext = new FUFamilyTreeContext();
        }

        public Location GetLocationById(int Id)
        {
            return _dbContext.Locations.FirstOrDefault(c => c.Id == Id);
        }
        public List<Location> GetListLocationByName(string name)
        {
            return _dbContext.Locations.Where(c => c.Name.ToUpper().Contains(name.ToUpper())).ToList();
        }
        public List<Location> GetAll()
        {
            return _dbContext.Locations.ToList();
        }
        public void Add(Location e)
        {
            _dbContext.Locations.Add(e);
            _dbContext.SaveChanges();
        }
        public void Update(Location e)
        {
            var u = GetLocationById(e.Id);
            if (u != null)
            {
                u.Name = e.Name;
                u.Price = e.Price;
                u.Rating = e.Rating;
                _dbContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var d = GetLocationById(id);
            if (d != null)
            {
                _dbContext.Locations.Remove(d);
                _dbContext.SaveChanges();
            }
        }
    }
}


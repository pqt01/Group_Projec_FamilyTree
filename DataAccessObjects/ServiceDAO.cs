using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ServiceDAO
    {
        private readonly FUFamilyTreeContext _dbContext;
        public ServiceDAO()
        {
			_dbContext = new FUFamilyTreeContext();
        }
        public List<Service> GetAll()
        {
            return _dbContext.Services.ToList();
        }
        public Service GetServiceById(int Id)
        {
            return _dbContext.Services.FirstOrDefault(c => c.Id == Id);
        }
        public List<Service> GetListServiceByName(string name)
        {
            return _dbContext.Services.Where(c => c.Name.ToUpper().Contains(name.ToUpper())).ToList();
        }
        public void Add(Service e)
        {
            _dbContext.Services.Add(e);
            _dbContext.SaveChanges();
        }
        public void Update(Service e)
        {
            var u = GetServiceById(e.Id);
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
            var d = GetServiceById(id);
            if (d != null)
            {
                _dbContext.Services.Remove(d);
                _dbContext.SaveChanges();
            }
        }
    }
}

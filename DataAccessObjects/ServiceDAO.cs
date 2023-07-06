using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class ServiceDAO
    {
        private readonly FUFamilyTreeContext _context;
        public ServiceDAO()
        {
            _context = new FUFamilyTreeContext();
        }
        public List<Service> GetAll()
        {
            return _context.Services.ToList();
        }
    }
}

using BusinessObjects.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
    public class EventDAO
    {
        private FUFamilyTreeContext _context;
        public EventDAO()
        {
            _context = new FUFamilyTreeContext();
        }
        public List<Event> GetAll()
        {
            return _context.Events.ToList();
        }
    }
}

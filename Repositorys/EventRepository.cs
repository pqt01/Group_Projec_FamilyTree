using BusinessObjects.Models;
using DataAccessObjects;
using Repositorys.Interface;
using System.Collections.Generic;

namespace Repositorys
{
    public class EventRepository : IEventRepository
    {
        private EventDAO _dao;
        public EventRepository()
        {
            _dao = new EventDAO();
        }
        public List<Event> GetEvents() => _dao.GetAll();
		public List<Event> GetAll() => _dao.GetAll();
		public Event GetEventById(int id) => _dao.GetEventById(id);
		public List<Event> GetListEventByName(string name) => _dao.GetListEventByName(name);
		public void Add(Event e) => _dao.Add(e);
		public void Update(Event e) => _dao.Update(e);
		public void Delete(int id) => _dao.Delete(id);
		public List<Family> GetFamilies() => _dao.GetFamilies();
		public List<Service> GetServices() => _dao.GetServices();
		public List<Location> GetLocations() => _dao.GetLocations();
	}
}

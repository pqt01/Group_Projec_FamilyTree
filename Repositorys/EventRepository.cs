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
    }
}

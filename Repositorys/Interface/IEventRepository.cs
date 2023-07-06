using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositorys.Interface
{
    public interface IEventRepository
    {
        List<Event> GetAll();
        Event GetEventById(int id);
        List<Event> GetListEventByName(string name);
        void Add(Event e);
        void Update(Event e);
        void Delete(int id);
        List<Family> GetFamilies();
        List<Service> GetServices();
        List<Location> GetLocations();
    }
}

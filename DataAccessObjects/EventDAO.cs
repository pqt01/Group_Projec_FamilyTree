using BusinessObjects.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessObjects
{
	public class EventDAO
	{
		private FUFamilyTreeContext _dbContext;
		public EventDAO()
		{
			_dbContext = new FUFamilyTreeContext();
		}

		public Event GetEventById(int Id)
		{
			return _dbContext.Events.FirstOrDefault(c => c.Id == Id);
		}
		public List<Event> GetListEventByName(string name)
		{
			return _dbContext.Events.Where(c => c.Title.Equals(name)).ToList();
		}
		public List<Event> GetAll()
		{
			return _dbContext.Events.ToList();
		}
		public void Add(Event e)
		{
			_dbContext.Events.Add(e);
			_dbContext.SaveChanges();
		}
		public void Update(Event e)
		{
			var ev = GetEventById(e.Id);
			if (ev != null)
			{
				ev.Title = e.Title;
				ev.CreateDate = e.CreateDate;
				ev.OrganizeDate = e.OrganizeDate;
				ev.FamilyId = e.FamilyId;
				ev.ServiceId = e.ServiceId;
				ev.ServicePrice = e.ServicePrice;
				ev.LocationId = e.LocationId;
				ev.LocationPrice = e.LocationPrice;

				_dbContext.SaveChanges();
			}
		}
		public void Delete(int id)
		{
			var ev = GetEventById(id);
			if (ev != null)
			{
				_dbContext.Events.Remove(ev);
				_dbContext.SaveChanges();
			}
		}
		public List<Family> GetFamilies()
		{
			return _dbContext.Families.ToList();
		}
		public List<Service> GetServices()
		{
			return _dbContext.Services.ToList();
		}
		public List<Location> GetLocations()
		{
			return _dbContext.Locations.ToList();
		}
	}
}

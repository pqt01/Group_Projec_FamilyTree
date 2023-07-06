using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Group_Project_FamilyTree.Pages.AdminPage
{
    public class ViewEventModel : PageModel
    {
        private readonly IEventRepository _eventRepository;

        public ViewEventModel(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IList<Event> Event { get; set; }

        public void OnGetAsync()
        {
            Event = _eventRepository.GetEvents().ToList();
        }
    }
}

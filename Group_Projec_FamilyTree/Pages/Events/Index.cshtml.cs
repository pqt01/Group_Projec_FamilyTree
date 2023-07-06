using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Group_Projec_FamilyTree.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly IEventRepository _eventRepo;

        public IndexModel(IEventRepository eventRepository)
        {
            _eventRepo = eventRepository;
        }

        public IList<Event> Event { get; set; }

        public void OnGetAsync()
        {
            Event = _eventRepo.GetAll().ToList();
        }
    }
}

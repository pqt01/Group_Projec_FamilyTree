using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;

namespace Group_Projec_FamilyTree.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly IEventRepository _eventRepo;

        public DetailsModel(IEventRepository eventRepository)
        {
            _eventRepo = eventRepository;
        }

        public Event Event { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = _eventRepo.GetEventById(id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

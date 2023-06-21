using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System;

namespace Group_Projec_FamilyTree.Pages.Events
{
    public class EditModel : PageModel
    {
        private readonly IEventRepository _eventRepo;

        public EditModel(IEventRepository eventRepository)
        {
            _eventRepo = eventRepository;
        }

        [BindProperty]
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
            var listFamilies = _eventRepo.GetFamilies();
            var listServices = _eventRepo.GetServices();
            var listLocations = _eventRepo.GetLocations();
            //TempData["FamilyId"] = new SelectList(listFamilies, "Id", "Id", Event.FamilyId);
            //TempData["LocationId"] = new SelectList(listLocations, "Id", "Name", Event.LocationId);
            //TempData["ServiceId"] = new SelectList(listServices, "Id", "Name", Event.ServiceId);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                _eventRepo.Update(Event);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return RedirectToPage("./Index");
        }
    }
}

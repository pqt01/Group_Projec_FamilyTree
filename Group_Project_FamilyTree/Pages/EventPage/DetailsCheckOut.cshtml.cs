using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Group_Project_FamilyTree.Pages.EventPage
{
    public class DetailsChecOutModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFamilyTreeContext _context;

        public DetailsChecOutModel(BusinessObjects.Models.FUFamilyTreeContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            Event = JsonSerializer.Deserialize<Event>(HttpContext.Session.GetString("card"));

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            
            Event = JsonSerializer.Deserialize<Event>(HttpContext.Session.GetString("card"));
            Event.ServicePrice = Event.Service.Price ;
            Event.LocationPrice = Event.Location.Price;
            Event.Service = null;
            Event.Location = null;
            // Lay data DB
            Event.FamilyId = 4; 
            
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Group_Project_FamilyTree.Pages.EventPage
{
	[Authorize(Roles = "Member")]
	public class CreateModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFamilyTreeContext _context;

        public CreateModel(BusinessObjects.Models.FUFamilyTreeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["FamilyId"] = new SelectList(_context.Families, "Id", "Id");
        ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
        ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {   
           
            if (!ModelState.IsValid || Event.OrganizeDate < DateTime.Now)
            {
                ModelState.AddModelError(" " , "OrganizeDate invail");
                ViewData["LocationId"] = new SelectList(_context.Locations, "Id", "Name");
                ViewData["ServiceId"] = new SelectList(_context.Services, "Id", "Name");
                return Page();
            }
            Event.CreateDate = DateTime.Now;
   
            Event.Service = _context.Services.FirstOrDefault(s => s.Id == Event.ServiceId);
            Event.Location = _context.Locations.FirstOrDefault(s => s.Id == Event.LocationId);
            HttpContext.Session.SetString("card", JsonSerializer.Serialize(Event));

            //_context.Events.Add(Event);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./DetailsCheckOut");
        }
    }
}

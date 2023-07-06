using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Group_Project_FamilyTree.Pages.EventAttendeesPage
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
        ViewData["EventId"] = new SelectList(_context.Events.Where(e => e.OrganizeDate > DateTime.Now), "Id", "Id");
        ViewData["MemberId"] = new SelectList(_context.Members, "Id", "FullName");
            return Page();
        }

        [BindProperty]
        public EventAttendees EventAttendees { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.EventAttendees.Add(EventAttendees);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Group_Project_FamilyTree.Pages.EventAttendeesPage
{
	[Authorize(Roles = "Member")]
	public class DeleteModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFamilyTreeContext _context;

        public DeleteModel(BusinessObjects.Models.FUFamilyTreeContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EventAttendees EventAttendees { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventAttendees = await _context.EventAttendees
                .Include(e => e.Event)
                .Include(e => e.Member).FirstOrDefaultAsync(m => m.Id == id);

            if (EventAttendees == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EventAttendees = await _context.EventAttendees.FindAsync(id);

            if (EventAttendees != null)
            {
                _context.EventAttendees.Remove(EventAttendees);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

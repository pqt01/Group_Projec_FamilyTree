using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace Group_Project_FamilyTree.Pages.EventAttendeesPage
{
    public class DetailsModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFamilyTreeContext _context;

        public DetailsModel(BusinessObjects.Models.FUFamilyTreeContext context)
        {
            _context = context;
        }

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
    }
}

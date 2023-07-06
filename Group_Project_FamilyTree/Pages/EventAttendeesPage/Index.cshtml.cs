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
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFamilyTreeContext _context;

        public IndexModel(BusinessObjects.Models.FUFamilyTreeContext context)
        {
            _context = context;
        }

        public IList<EventAttendees> EventAttendees { get;set; }

        public async Task OnGetAsync()
        {
            EventAttendees = await _context.EventAttendees
                .Include(e => e.Event)
                .Include(e => e.Member).ToListAsync();
        }
    }
}

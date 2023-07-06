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

namespace Group_Project_FamilyTree.Pages.EventPage
{
	[Authorize(Roles = "Member")]
	public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFamilyTreeContext _context;

        public IndexModel(BusinessObjects.Models.FUFamilyTreeContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events
                .Include(a => a.Family)
                .Include(a => a.Location)
                .Include(a => a.Service).ToListAsync();
        }
    }
}

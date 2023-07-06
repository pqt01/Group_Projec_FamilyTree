using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace Group_Project_FamilyTree.Pages.MemberPage
{
    public class IndexModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFamilyTreeContext _context;

        public IndexModel(BusinessObjects.Models.FUFamilyTreeContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; }

        public async Task OnGetAsync()
        {
            Member = await _context.Members
                .Include(m => m.Account)
                .Include(m => m.Family)
                .Include(m => m.Parent).ToListAsync();
        }
    }
}

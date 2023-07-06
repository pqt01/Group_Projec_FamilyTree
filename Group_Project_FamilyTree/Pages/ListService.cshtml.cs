using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace Group_Project_FamilyTree.Pages
{
    public class ListServiceModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFamilyTreeContext _context;

        public ListServiceModel(BusinessObjects.Models.FUFamilyTreeContext context)
        {
            _context = context;
        }

        public IList<Service> Service { get;set; }

        public async Task OnGetAsync()
        {
            Service = await _context.Services.ToListAsync();
        }
    }
}

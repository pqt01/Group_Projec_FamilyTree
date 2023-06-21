using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace Group_Projec_FamilyTree.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFamilyTreeContext _context;

        public CreateModel(BusinessObjects.Models.FUFamilyTreeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "Email");
        ViewData["FamilyId"] = new SelectList(_context.Set<Family>(), "Id", "Id");
        ViewData["ParentId"] = new SelectList(_context.Set<Couple>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Members.Add(Member);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
    public class CreateMemberModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFamilyTreeContext _context;

        public CreateMemberModel(BusinessObjects.Models.FUFamilyTreeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AccountId"] = new SelectList(_context.Users, "Id", "Id");
        ViewData["FamilyId"] = new SelectList(_context.Families, "Id", "Id");
        ViewData["ParentId"] = new SelectList(_context.Couples, "Id", "Id");
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

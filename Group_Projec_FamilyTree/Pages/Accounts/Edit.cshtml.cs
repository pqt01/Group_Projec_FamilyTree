using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System;

namespace Group_Projec_FamilyTree.Pages.Accounts
{
    public class EditModel : PageModel
    {
        private readonly IAccountRepository _accountRepo;

        public EditModel(IAccountRepository accountRepository)
        {
            _accountRepo = accountRepository;
        }

        [BindProperty]
        public Account Account { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account = _accountRepo.GetAccountById(id);

            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _accountRepo.Update(Account);
            }
            catch (Exception e)
            {
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}

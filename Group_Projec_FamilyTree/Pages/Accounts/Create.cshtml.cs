using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;

namespace Group_Projec_FamilyTree.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly IAccountRepository _accountRepo;

        public CreateModel(IAccountRepository accountRepository)
        {
            _accountRepo = accountRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _accountRepo.Add(Account);

            return RedirectToPage("./Index");
        }
    }
}

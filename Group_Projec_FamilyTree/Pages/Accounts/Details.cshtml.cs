using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;

namespace Group_Projec_FamilyTree.Pages.Accounts
{
    public class DetailsModel : PageModel
    {
        private readonly IAccountRepository _accountRepository;

        public DetailsModel(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account Account { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Account = _accountRepository.GetAccountById(id);

            if (Account == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

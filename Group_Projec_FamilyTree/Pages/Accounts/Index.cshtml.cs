using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Group_Projec_FamilyTree.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly IAccountRepository _accountRepo;

        public IndexModel(IAccountRepository accountRepository)
        {
            _accountRepo = accountRepository;
        }

        public IList<Account> Account { get; set; }

        public void OnGetAsync()
        {
            Account = _accountRepo.GetAll().ToList();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys;
using Repositorys.Interface;
using System.Linq;

namespace Group_Projec_FamilyTree.Pages
{
    public class LoginModel : PageModel
    {
        private IAccountRepository _accountRepository;
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
        public LoginModel()
        {
            _accountRepository = new AccountRepository();
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            var user = _accountRepository.GetAll().FirstOrDefault(u => u.Email.Equals(Email) && u.Password.Equals(Password));
            if (user != null)
            {
                if (user.Role == "ADMIN")
                {
                    HttpContext.Session.SetString("Role", "ADMIN");
                    return RedirectToPage("/Accounts/Index");
                }
                else if (user.Role == "MEMBER")
                {
                    HttpContext.Session.SetString("Role", "MEMBER");
                    return RedirectToPage("/Accounts/Index"); ;

                }
                else
                {
                    ErrorMessage = "You are not allowed to do this function!";
                    return Page();

                }
            }
            else
            {
                ErrorMessage = "You must type data in form";
                return Page();
            }


        }
    }
}

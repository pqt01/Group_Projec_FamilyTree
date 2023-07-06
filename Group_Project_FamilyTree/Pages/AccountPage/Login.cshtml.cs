using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using BusinessObjects.Models;
using DataAccessObjects;

namespace Group_Project_FamilyTree.Pages.AccountPage
{
	[AllowAnonymous]
	public class LoginModel : PageModel
	{
		private readonly UserManager<Account> _userManager;
		private readonly SignInManager<Account> _signInManager;
		private readonly AccountDAO _accRepo;

		public LoginModel(SignInManager<Account> signInManager,
			UserManager<Account> userManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_accRepo = new AccountDAO();
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		public string ReturnUrl { get; set; }

		[TempData]
		public string ErrorMessage { get; set; }

		public class InputModel
		{
			[Required]
			//[EmailAddress]
			[Display(Name = "Username or email")]
			public string UserNameOrEmail { get; set; }

			[Required]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Password { get; set; }

			[Display(Name = "Remember?")]
			public bool RememberMe { get; set; }
		}

		public async Task OnGetAsync(string returnUrl = null)
		{
			if (!string.IsNullOrEmpty(ErrorMessage))
			{
				ModelState.AddModelError(string.Empty, ErrorMessage);
			}

			//returnUrl ??= Url.Content("~/");

			// Clear the existing external cookie to ensure a clean login process
			await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			//ReturnUrl = returnUrl;
		}

		public async Task<IActionResult> OnPostAsync()
		{
			//returnUrl ??= Url.Content("~/");

			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			if (ModelState.IsValid)
			{
				// This doesn't count login failures towards account lockout
				// To enable password failures to trigger account lockout, set lockoutOnFailure: true

				//_signInManager.SignInAsync()

				var result = await _signInManager.PasswordSignInAsync(Input.UserNameOrEmail, Input.Password, Input.RememberMe, lockoutOnFailure: true);
				//if(result.Succeeded) { return RedirectToPage("/Privacy"); }
				// Tìm UserName theo Email, đăng nhập lại
				if (!result.Succeeded)
				{
					var user = await _userManager.FindByEmailAsync(Input.UserNameOrEmail);
					if (user != null)
					{
						result = await _signInManager.PasswordSignInAsync(user.UserName, Input.Password, Input.RememberMe, lockoutOnFailure: true);
					}
				}

				if (result.Succeeded)
				{
					return LocalRedirect("/");
				}

				//if (result.RequiresTwoFactor)
				//{
				//	return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, Input.RememberMe });
				//}

				if (result.IsLockedOut)
				{
					return RedirectToPage("./Lockout");
				}
				else
				{
					ModelState.AddModelError(string.Empty, "Login failed! Account does not exist or username and password is not correct!");
					return Page();
				}
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}
	}
}

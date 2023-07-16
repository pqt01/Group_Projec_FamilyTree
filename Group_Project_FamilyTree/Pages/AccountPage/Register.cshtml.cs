using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using BusinessObjects.Models;
using Repositorys.Interface;
using Repositorys;
using Microsoft.EntityFrameworkCore;

namespace Group_Project_FamilyTree.Pages.AccountPage
{
	[AllowAnonymous]
	//[Authorize(Roles = "Admin")]
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<Account> _signInManager;
		private readonly UserManager<Account> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IMemberRepository _memRepo;
		private readonly IFamilyRepository _faRepo;

		public RegisterModel(
			UserManager<Account> userManager,
			SignInManager<Account> signInManager,
			RoleManager<IdentityRole> roleManager)
		{
			_memRepo = new MemberRepository();
			_faRepo = new FamilyRepository();
			_userManager = userManager;
			_signInManager = signInManager;
			_roleManager = roleManager;
		}

		[BindProperty]
		public InputModel Input { get; set; }

		public string ReturnUrl { get; set; }

		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		public class InputModel
		{
			[Required]
			[EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

			[Required]
			[StringLength(100, MinimumLength = 2)]
			[DataType(DataType.Password)]
			public string Password { get; set; }

			[DataType(DataType.Password)]
			[Compare("Password")]
			public string ConfirmPassword { get; set; }

			[DataType(DataType.Text)]
			[Display(Name = "Username")]
			[Required]
			[StringLength(100, MinimumLength = 3)]
			public string UserName { get; set; }

		}

		public async Task OnGetAsync(string returnUrl = null)
		{
			ReturnUrl = returnUrl;
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			returnUrl ??= Url.Content("~/");
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

			if (ModelState.IsValid)
			{
				var user = new Account { UserName = Input.UserName, Email = Input.Email };

				var result = await _userManager.CreateAsync(user, Input.Password);


				if (result.Succeeded)
				{
					//create default member
					string accountId = user.Id;
					//_userManager.GetUserId(user);
					Member member = new Member();
					member.FullName = "Not updated yet";
					member.AccountId = accountId;
					member.LinkAvatar = "urserImage_default.png";
					_memRepo.Add(member);

					//create default family
					member = _memRepo.GetMemberByAccountId(accountId);
					Family family = new Family();
					family.CreatorId = member.Id;
					_faRepo.Add(family);

					//add famyliId
					family = _faRepo.GetByCreatorIdId(member.Id);
					member.FamilyId = family.Id;
					_memRepo.UpdateAttach(member);

					//role
					List<string> roleNames = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
					var resultAdd = await _userManager.AddToRolesAsync(user, roleNames.Where(r => r == "Member"));

					if (_userManager.Options.SignIn.RequireConfirmedAccount)
					{
						return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl });
					}
					else
					{
						await _signInManager.SignInAsync(user, isPersistent: false);
						
						return LocalRedirect(returnUrl);
					}

				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}
	}
}

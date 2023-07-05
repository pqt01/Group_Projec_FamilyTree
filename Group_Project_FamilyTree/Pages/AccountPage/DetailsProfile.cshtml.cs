using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Identity;
using Repositorys.Interface;
using Repositorys;

namespace Group_Project_FamilyTree.Pages.AccountPage
{
    public class DetailsProfileModel : PageModel
    {
        private readonly IMemberRepository _memRepo;
        private readonly IFamilyRepository _faRepo;
        private readonly UserManager<Account> _userManager;

        public DetailsProfileModel(UserManager<Account> userManager)
        {
            _memRepo = new MemberRepository();
            _faRepo = new FamilyRepository();
            _userManager = userManager;
        }

        public Member Member { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
				string accountId = _userManager.GetUserId(User);
				Member = _memRepo.GetMemberByAccountId(accountId);
            }
            else
            {
				Member = _memRepo.GetById((int)id);
			}
            
            if (Member == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

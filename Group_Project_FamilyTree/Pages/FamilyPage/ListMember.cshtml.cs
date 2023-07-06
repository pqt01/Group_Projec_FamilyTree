using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositorys.Interface;
using Repositorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
    public class ListMemberModel : PageModel
    {
        private readonly IMemberRepository _memRepo;
		private readonly UserManager<Account> _userManager;

		public ListMemberModel(UserManager<Account> userManager)
        {
			_memRepo = new MemberRepository();
			_userManager = userManager;
        }

        public IList<Member> Member { get;set; }
		
		public void OnGet()
		{
			string id = _userManager.GetUserId(User);
			Member m = _memRepo.GetMemberByAccountId(id);
			if (m != null)
			{
				Member = _memRepo.GetAllFamyliById((int)m.FamilyId);
			}
		}
	}
}

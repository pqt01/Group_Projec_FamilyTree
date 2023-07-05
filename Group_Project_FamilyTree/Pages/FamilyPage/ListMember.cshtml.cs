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

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
    public class ListMemberModel : PageModel
    {
        private readonly IMemberRepository _memberRepo;

        public ListMemberModel()
        {
			_memberRepo = new MemberRepository();
        }

        public IList<Member> Member { get;set; }

		public void OnGet(int? familyId)
		{
			familyId = 2;
			if (familyId != null)
			{
				Member = _memberRepo.GetAllFamyliById((int)familyId);
			}
			//return RedirectToPage("/AuthencationFale");
		}
	}
}

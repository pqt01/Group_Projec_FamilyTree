using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositorys.Interface;
using Microsoft.AspNetCore.Identity;
using Repositorys;

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
    public class CreateMemberModel : PageModel
    {
        private readonly IMemberRepository _memRepo;
        private readonly UserManager<Account> _userManager;

        public CreateMemberModel(UserManager<Account> userManager)
        {
            _memRepo = new MemberRepository();
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            GetData();
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; }
        [BindProperty]
        public int Relationship { get; set; }
        [BindProperty]
        public int RelationshipMemberId { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                GetData();
                return Page();
            }
			string id = _userManager.GetUserId(User);
			Member m = _memRepo.GetMemberByAccountId(id);
			Member.FamilyId = m.FamilyId;

            if(_memRepo.AddMemberFamilyTree(Member, Relationship, RelationshipMemberId))
				return RedirectToPage("./ListMember");

            GetData();
            ModelState.AddModelError(string.Empty, "Create fail!");
            return Page();
		}
        private void GetData()
        {
            string id = _userManager.GetUserId(User);
            Member m = _memRepo.GetMemberByAccountId(id);
            if (m != null)
            {
                var memberList = _memRepo.GetAllFamyliById((int)m.FamilyId);
                ViewData["RelationshipMemberId"] =
                        new SelectList(memberList, "Id", "FullName");
            }
        }
        private bool IsValid(Member member)
        {
            bool result = true;
            string fullName = member.FullName.Trim();
            string space = " ";
            if (!fullName.Contains(space))
            {
                ModelState.AddModelError("", "Invalid last name or first name");
                result = false;
            }
            string[] arrListStr = fullName.Split(space);
            for (int i = 0; i < arrListStr.Length; i++)
            {
                if (!Char.IsUpper(arrListStr[i][0]))
                {
                    ModelState.AddModelError("", "Each word of the candidate Fullname must");
                    result = false;
                    break;
                }
            }
            if (Member.BirthDate > DateTime.Now)
            {
                ModelState.AddModelError("", "Invalid birthdate");
                result = false;
            }
            return result;
        }
    }
}

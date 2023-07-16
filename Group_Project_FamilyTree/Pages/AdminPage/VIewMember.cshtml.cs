using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Group_Project_FamilyTree.Pages.AdminPage
{
	[Authorize(Roles = "Admin")]
	public class ViewMemberModel : PageModel
    {
        private readonly IMemberRepository _memberRepository;

        public ViewMemberModel(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public IList<Member> Member { get; set; }

        public void OnGetAsync()
        {
            Member = _memberRepository.GetMembers().ToList();
        }
    }
}

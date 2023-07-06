using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Group_Project_FamilyTree.Pages.AdminPage
{
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

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
	public class ViewFamilyTreeModel : PageModel
    {
        private readonly IFamilyRepository _familyRepository;

        public ViewFamilyTreeModel(IFamilyRepository familyRepository)
        {
            _familyRepository = familyRepository;
        }

        public IList<Family> Family { get; set; }

        public void OnGetAsync()
        {
            Family = _familyRepository.GetFamilies().ToList();
        }
    }
}

using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Group_Project_FamilyTree.Pages.AdminPage.ServiceCRUD
{
	[Authorize(Roles = "Admin")]
	public class IndexModel : PageModel
    {
        private readonly IServiceRepository _serviceRepo;

        public IndexModel(IServiceRepository serviceRepository)
        {
            _serviceRepo = serviceRepository;
        }

        public IList<Service> Service { get; set; }

        public void OnGetAsync()
        {
            Service = _serviceRepo.GetAll().ToList();
        }
        public IActionResult OnPostSearch()
        {
            string search = Request.Form["SearchString"];
            if (search != null)
            {
                Service = _serviceRepo.GetListServiceByName(search);
                return Page();
            }
            return Page();
        }
    }
}

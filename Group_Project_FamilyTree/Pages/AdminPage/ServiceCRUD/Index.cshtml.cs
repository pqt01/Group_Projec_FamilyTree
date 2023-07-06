using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Group_Project_FamilyTree.Pages.AdminPage.ServiceCRUD
{
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

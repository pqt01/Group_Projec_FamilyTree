using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System.Data;

namespace Group_Project_FamilyTree.Pages.AdminPage.ServiceCRUD
{
	[Authorize(Roles = "Admin")]
	public class DeleteModel : PageModel
    {
        private readonly IServiceRepository _serviceRepo;

        public DeleteModel(IServiceRepository serviceRepository)
        {
            _serviceRepo = serviceRepository;
        }

        [BindProperty]
        public Service Service { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service = _serviceRepo.GetServiceById(id);

            if (Service == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Service = _serviceRepo.GetServiceById(id);

            if (Service != null)
            {
                _serviceRepo.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}

using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;

namespace Group_Project_FamilyTree.Pages.AdminPage.ServiceCRUD
{
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

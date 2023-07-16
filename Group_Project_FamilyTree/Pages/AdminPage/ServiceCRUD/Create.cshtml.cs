using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System.Data;

namespace Group_Project_FamilyTree.Pages.AdminPage.ServiceCRUD
{
	[Authorize(Roles = "Admin")]
	public class CreateModel : PageModel
    {
        private readonly IServiceRepository _serviceRepo;

        public CreateModel(IServiceRepository serviceRepository)
        {
            _serviceRepo = serviceRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Service Service { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _serviceRepo.Add(Service);

            return RedirectToPage("./Index");
        }
    }
}

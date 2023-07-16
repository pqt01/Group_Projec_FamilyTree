using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System;
using System.Data;

namespace Group_Project_FamilyTree.Pages.AdminPage.ServiceCRUD
{
	[Authorize(Roles = "Admin")]
	public class EditModel : PageModel
    {
        private readonly IServiceRepository _serviceRepo;

        public EditModel(IServiceRepository serviceRepository)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _serviceRepo.Update(Service);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return RedirectToPage("./Index");
        }
    }
}

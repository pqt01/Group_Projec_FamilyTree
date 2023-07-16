using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System;
using System.Data;

namespace Group_Project_FamilyTree.Pages.AdminPage.LocationCRUD
{
	[Authorize(Roles = "Admin")]
	public class EditModel : PageModel
    {
        private readonly ILocationRepository _locationRepo;

        public EditModel(ILocationRepository LocationRepository)
        {
            _locationRepo = LocationRepository;
        }

        [BindProperty]
        public Location Location { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Location = _locationRepo.GetLocationById(id);

            if (Location == null)
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
                _locationRepo.Update(Location);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return RedirectToPage("./Index");
        }
    }
}

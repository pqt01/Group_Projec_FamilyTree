using BusinessObjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System.Data;

namespace Group_Project_FamilyTree.Pages.AdminPage.LocationCRUD
{
	[Authorize(Roles = "Admin")]
	public class DetailsModel : PageModel
    {
        private readonly ILocationRepository _locationRepo;

        public DetailsModel(ILocationRepository LocationRepository)
        {
            _locationRepo = LocationRepository;
        }

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
    }
}

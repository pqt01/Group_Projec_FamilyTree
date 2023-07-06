using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;

namespace Group_Project_FamilyTree.Pages.AdminPage.LocationCRUD
{
    public class DeleteModel : PageModel
    {
        private readonly ILocationRepository _locationRepo;

        public DeleteModel(ILocationRepository LocationRepository)
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

        public IActionResult OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Location = _locationRepo.GetLocationById(id);

            if (Location != null)
            {
                _locationRepo.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}

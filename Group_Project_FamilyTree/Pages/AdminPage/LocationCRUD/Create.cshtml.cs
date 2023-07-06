using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;

namespace Group_Project_FamilyTree.Pages.AdminPage.LocationCRUD
{
    public class CreateModel : PageModel
    {
        private readonly ILocationRepository _locationRepo;

        public CreateModel(ILocationRepository LocationRepository)
        {
            _locationRepo = LocationRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Location Location { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _locationRepo.Add(Location);

            return RedirectToPage("./Index");
        }
    }
}

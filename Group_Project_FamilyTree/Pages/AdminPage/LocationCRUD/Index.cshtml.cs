using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Group_Project_FamilyTree.Pages.AdminPage.LocationCRUD
{
    public class IndexModel : PageModel
    {
        private readonly ILocationRepository _locationRepo;

        public IndexModel(ILocationRepository LocationRepository)
        {
            _locationRepo = LocationRepository;
        }

        public IList<Location> Location { get; set; }

        public void OnGetAsync()
        {
            Location = _locationRepo.GetAll().ToList();
        }

        public IActionResult OnPostSearch()
        {
            string search = Request.Form["SearchString"];
            if (search != null)
            {
                Location = _locationRepo.GetListLocationByName(search);
                return Page();
            }
            return Page();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;

namespace Group_Project_FamilyTree.Pages.EventPage
{
    public class CreateModel : PageModel
    {
        public void OnGet()
        {
        }

        [BindProperty]
        public Event Event { get; set; } = default!;
    }
}

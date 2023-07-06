using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repositorys.Interface;
using Repositorys;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Group_Project_FamilyTree.Pages.EventPage
{
	[Authorize(Roles = "Member")]
	public class DetailsChecOutModel : PageModel
    {
        private readonly BusinessObjects.Models.FUFamilyTreeContext _context;
        private readonly UserManager<Account> _userManager;
        private readonly IMemberRepository _memRepo;

        public DetailsChecOutModel(BusinessObjects.Models.FUFamilyTreeContext context , UserManager<Account> userManager)
        {
            _userManager = userManager;

            _context = context;
            _memRepo = new MemberRepository();

        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            Event = JsonSerializer.Deserialize<Event>(HttpContext.Session.GetString("card"));

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            
            Event = JsonSerializer.Deserialize<Event>(HttpContext.Session.GetString("card"));
            Event.ServicePrice = Event.Service.Price ;
            Event.LocationPrice = Event.Location.Price;
            Event.Service = null;
            Event.Location = null;
            // Lay data DB
            string id = _userManager.GetUserId(User);
            Member m = _memRepo.GetMemberByAccountId(id);
            Event.FamilyId = (int)m.FamilyId; 
            
            _context.Events.Add(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

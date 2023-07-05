using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositorys.Interface;
using Repositorys;

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
    public class DeleteImageModel : PageModel
    {
		private readonly IImageRepository _imgRepo;

		public DeleteImageModel()
        {
			_imgRepo = new ImageRepository();
		}

        [BindProperty]
        public Image Image { get; set; }

		public IActionResult OnGet(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Image = _imgRepo.GetById((int)id);

			if (Image == null)
			{
				return NotFound();
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Image = await _context.Images.FindAsync(id);

            //if (Image != null)
            //{
            //    _context.Images.Remove(Image);
            //    await _context.SaveChangesAsync();
            //}

            return RedirectToPage("./Index");
        }
    }
}

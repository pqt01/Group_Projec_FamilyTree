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
	public class DetailsImageModel : PageModel
	{
		private readonly IImageRepository _imgRepo;

		public DetailsImageModel()
		{
			_imgRepo = new ImageRepository();
		}

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
	}
}

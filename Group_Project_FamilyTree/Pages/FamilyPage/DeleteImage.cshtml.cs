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
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Group_Project_FamilyTree.Helper;

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
	public class DeleteImageModel : PageModel
	{
		private readonly IImageRepository _imgRepo;
		private readonly UploadImage _uploadImage;

		public DeleteImageModel(IWebHostEnvironment environment)
		{
			_imgRepo = new ImageRepository();
			_uploadImage = new UploadImage(environment);
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

		public IActionResult OnPost(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Image = _imgRepo.GetById((int)id);

			if (Image != null)
			{
				_uploadImage.DeleteImageFile(Image.Url);

				_imgRepo.Delete(Image);
			}
			else
			{
				return Page();
			}

			return RedirectToPage("./Album");
		}
	}
}

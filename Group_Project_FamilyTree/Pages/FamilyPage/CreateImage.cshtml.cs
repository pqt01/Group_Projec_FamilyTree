using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Identity;
using Repositorys.Interface;
using Repositorys;

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
	public class CreateImageModel : PageModel
	{
		private readonly IMemberRepository _memRepo;
		private readonly IImageRepository _imgRepo;
		private readonly IWebHostEnvironment _environment;
		private readonly UserManager<Account> _userManager;
		private readonly SignInManager<Account> _signInManager;
		public CreateImageModel(IWebHostEnvironment environment,
			SignInManager<Account> signInManager,
			UserManager<Account> userManager)
		{
			_memRepo = new MemberRepository();
			_imgRepo = new ImageRepository();
			_environment = environment;
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public void OnGet()
		{
		}
		[Required]
		[DataType(DataType.Upload)]
		[CheckFileExtensions(Extensions = "png,jpg,jpeg,gif")]
		[Display(Name = "Image upload")]
		[BindProperty]
		public IFormFile[] FileUploads { get; set; }
		//[BindProperty]
		//      public Image Image { get; set; }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			if (FileUploads != null)
			{
				foreach (var FileUpload in FileUploads)
				{
					string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(FileUpload.FileName);
					while (System.IO.File.Exists(Path.Combine(_environment.WebRootPath, "image", newFileName)))
					{
						newFileName = Guid.NewGuid().ToString() + Path.GetExtension(FileUpload.FileName);
					}
					ModelState.AddModelError(string.Empty, Path.Combine(_environment.WebRootPath, "image", newFileName));

					Image image = new Image();
					string id = _userManager.GetUserId(User);
					Member member = _memRepo.GetMemberByAccountId(id);
					image.FamilyId = (int)member.FamilyId;
					image.Url = newFileName;
					_imgRepo.Add(image);

					var file = Path.Combine(_environment.WebRootPath, "image", newFileName);
					using (var fileStream = new FileStream(file, FileMode.Create))
					{
						await FileUpload.CopyToAsync(fileStream);
					}
				}
			}

			return RedirectToPage("./Album");
		}
	}
}

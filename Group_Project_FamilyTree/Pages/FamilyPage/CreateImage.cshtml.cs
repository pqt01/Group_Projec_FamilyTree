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
using Group_Project_FamilyTree.Helper;

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
	public class CreateImageModel : PageModel
	{
		private readonly IMemberRepository _memRepo;
		private readonly IImageRepository _imgRepo;
		private readonly UserManager<Account> _userManager;
		private readonly UploadImage _uploadImage;
		public CreateImageModel(IWebHostEnvironment environment,
			UserManager<Account> userManager)
		{
			_memRepo = new MemberRepository();
			_imgRepo = new ImageRepository();
			_userManager = userManager;
			_uploadImage = new UploadImage(environment);
		}

		public void OnGet() { }

		[Required]
		[DataType(DataType.Upload)]
		[CheckFileExtensions(Extensions = "png,jpg,jpeg,gif")]
		[Display(Name = "Image upload")]
		[BindProperty]
		public IFormFile[] FileUploads { get; set; }

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
					string fileName = _uploadImage.GetImageFileName(FileUpload);

					Image image = new Image();
					string id = _userManager.GetUserId(User);
					Member member = _memRepo.GetMemberByAccountId(id);
					image.FamilyId = (int)member.FamilyId;
					image.Url = fileName;
					_imgRepo.Add(image);

					await _uploadImage.WriteImageFileAsync(FileUpload, fileName);
				}
			}

			return RedirectToPage("./Album");
		}
	}
}

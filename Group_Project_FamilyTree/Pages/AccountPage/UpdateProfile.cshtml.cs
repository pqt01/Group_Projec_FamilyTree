using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositorys.Interface;
using Repositorys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Group_Project_FamilyTree.Helper;
using Microsoft.AspNetCore.Hosting;

namespace Group_Project_FamilyTree.Pages.AccountPage
{
	public class UpdateProfileModel : PageModel
	{
		private readonly IMemberRepository _memRepo;
		private readonly UploadImage _uploadImage;

		public UpdateProfileModel(IWebHostEnvironment environment)
		{
			_memRepo = new MemberRepository();
			_uploadImage = new UploadImage(environment);
		}

		public IActionResult OnGet(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Member = _memRepo.GetById((int)id);

			if (Member == null)
			{
				return NotFound();
			}
			return Page();
		}
		[BindProperty]
		public Member Member { get; set; }

		[DataType(DataType.Upload)]
		[CheckFileExtensions(Extensions = "png,jpg,jpeg,gif")]
		[Display(Name = "Image upload")]
		[BindProperty]
		public IFormFile FileUpload { get; set; }
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || !IsValid(Member))
			{
				return Page();
			}
			if (FileUpload != null)
			{
				if (Member.LinkAvatar != "urserImage_default.png")
				{
					_uploadImage.DeleteImageFile(Member.LinkAvatar);
				}
				string fileName = _uploadImage.GetImageFileName(FileUpload);
				Member.LinkAvatar= fileName;
				await _uploadImage.WriteImageFileAsync(FileUpload, fileName);
			}
			_memRepo.UpdateAttach(Member);

			return RedirectToPage("./DetailsProfile");
		}
		private bool IsValid(Member member)
		{
			bool result = true;
			string fullName = member.FullName.Trim();
			string space = " ";
			if (!fullName.Contains(space))
			{
				ModelState.AddModelError("", "Invalid last name or first name");
				result = false;
			}
			string[] arrListStr = fullName.Split(space);
			for (int i = 0; i < arrListStr.Length; i++)
			{
				if (!Char.IsUpper(arrListStr[i][0]))
				{
					ModelState.AddModelError("", "Each word of the candidate Fullname must");
					result = false;
					break;
				}
			}
			if (Member.BirthDate > DateTime.Now)
			{
				ModelState.AddModelError("", "Invalid birthdate");
				result = false;
			}
			return result;
		}
	}
}

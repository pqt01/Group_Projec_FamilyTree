using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObjects.Models;
using Repositorys.Interface;
using Microsoft.AspNetCore.Identity;
using Repositorys;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Group_Project_FamilyTree.Helper;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
	[Authorize(Roles = "Member")]
	public class CreateMemberModel : PageModel
    {
        private readonly IMemberRepository _memRepo;
        private readonly UserManager<Account> _userManager;
        private readonly UploadImage _uploadImage;

        public CreateMemberModel(UserManager<Account> userManager, 
            IWebHostEnvironment environment)
        {
            _memRepo = new MemberRepository();
            _userManager = userManager;
            _uploadImage = new UploadImage(environment);
        }

        public IActionResult OnGet()
        {
            GetData();
            return Page();
        }
        [BindProperty]
        public Member Member { get; set; }

        [DataType(DataType.Upload)]
        [CheckFileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Image upload")]
        [BindProperty]
        public IFormFile FileUpload { get; set; }
        [BindProperty]
        public int Relationship { get; set; }
        [BindProperty]
        public int RelationshipMemberId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    GetData();
            //    return Page();
            //}
            if (FileUpload != null)
            {
                string fileName = _uploadImage.GetImageFileName(FileUpload);
                Member.LinkAvatar = fileName;
                await _uploadImage.WriteImageFileAsync(FileUpload, fileName);
            }
            else
            {
                Member.LinkAvatar = "urserImage_default.png";
            }

            string id = _userManager.GetUserId(User);
			Member m = _memRepo.GetMemberByAccountId(id);
			Member.FamilyId = m.FamilyId;

            if(_memRepo.AddMemberFamilyTree(Member, Relationship, RelationshipMemberId))
				return RedirectToPage("./ListMember");

            GetData();
            ModelState.AddModelError(string.Empty, "Create fail!");
            return Page();
		}
        private void GetData()
        {
            string id = _userManager.GetUserId(User);
            Member m = _memRepo.GetMemberByAccountId(id);
            if (m != null)
            {
                var memberList = _memRepo.GetAllFamyliById((int)m.FamilyId);
                ViewData["RelationshipMemberId"] =
                        new SelectList(memberList, "Id", "FullName");
            }
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

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
using Microsoft.AspNetCore.Identity;

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
	public class AlbumModel : PageModel
	{
		private readonly IMemberRepository _memRepo;
		private readonly IImageRepository _imgRepo;
		private readonly UserManager<Account> _userManager;
		private readonly SignInManager<Account> _signInManager;

		public AlbumModel(SignInManager<Account> signInManager,
			UserManager<Account> userManager)
		{
			_memRepo = new MemberRepository();
			_imgRepo = new ImageRepository();
			_userManager = userManager;
			_signInManager = signInManager;
		}

		public IList<Image> Images { get; set; }

		public void OnGet()
		{
			string id = _userManager.GetUserId(User);
			Member member = _memRepo.GetMemberByAccountId(id);
			Images = _imgRepo.GetByFamyliId((int)member.FamilyId);
		}
	}
}

using BusinessObjects.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositorys.Interface;
using Repositorys;
using System.Collections.Generic;
using System.Text.Json;
using DataAccessObjects;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
	[Authorize(Roles = "Member,Admin")]
	public class FamilyTreeModel : PageModel
	{
		private readonly IMemberRepository _memRepo;
		private readonly ICoupleRepository _cbRepo;
		private readonly UserManager<Account> _userManager;
		private readonly CoupleDAO _cpDao = new CoupleDAO();

		public FamilyTreeModel(UserManager<Account> userManager)
		{
			_memRepo = new MemberRepository();
			_cbRepo = new CoupleRepository();
			_userManager = userManager;
		}
		public IList<Member> Members { get; set; }
		[BindProperty]
		public IList<MapChart> ListItems { get; set; }
		public IActionResult OnGet(int? id)
		{
			if (id == null)
			{
				string accountId = _userManager.GetUserId(User);
				Member m = _memRepo.GetMemberByAccountId(accountId);
				if (m != null)
				{
					id = (int)m.FamilyId;
				}
			}
			try
			{
				List<Member> list = _memRepo.GetAllFamyliById((int)id);
				List<MapChart> _listItem = new List<MapChart>();
				foreach (var item in list)
				{
					if (item.CoupleId != null)
					{
						var couple = _cbRepo.GetById((int)item.CoupleId);
						MapChart map = new MapChart();
						map.id = couple.Id.ToString() + "gr";
						if (couple.ParentId != null)
						{
							map.pid = couple.ParentId + "gr";
						}
						_listItem.Add(map);
					}
				}
				_listItem = _listItem.GroupBy(x => x.id).Select(x => x.First()).ToList();
				foreach (var item in list)
				{
					MapChart map = new MapChart();
					map.id = item.Id.ToString();
					map.name = item.FullName;
					map.img = "/image/" + item.LinkAvatar;
					var couple = _cbRepo.GetById((int)item.CoupleId);
					if (_cpDao.IsExistCouple(item))
					{
						map.stpid = couple.Id.ToString() + "gr";
					}
					else
					{
						map.pid = couple.Id.ToString();
					}
					_listItem.Add(map);
				}
				ListItems = _listItem;
			}
			catch (System.Exception)
			{

				return Page();
			}
			return Page();
		}

	}
	public class MapChart
	{
		public string id { get; set; }
		public string pid { get; set; }
		public string stpid { get; set; }

		public string name { get; set; }
		public string img { get; set; }
	}
}

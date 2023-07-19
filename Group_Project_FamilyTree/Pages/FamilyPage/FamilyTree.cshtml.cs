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
using System;

namespace Group_Project_FamilyTree.Pages.FamilyPage
{
    [Authorize(Roles = "Member,Admin")]
    public class FamilyTreeModel : PageModel
    {
        private readonly IMemberRepository _memRepo;
        private readonly IMateRepository _mateRepo;
        private readonly UserManager<Account> _userManager;
        private readonly MateDAO _mateDao = new MateDAO();

        public FamilyTreeModel(UserManager<Account> userManager)
        {
            _memRepo = new MemberRepository();
            _mateRepo = new MateRepository();
            _userManager = userManager;
        }
        public int MemberId { get; set; }
        public IList<Member> Members { get; set; }
        [BindProperty]
        public IList<MapChart> ListItems { get; set; }
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                string accountId = _userManager.GetUserId(User);
                Member m = _memRepo.GetMemberByAccountId(accountId);
                MemberId = m.Id;
                if (m != null)
                {
                    id = (int)m.FamilyId;
                }
            }
            try
            {
                List<Member> list = _memRepo.GetAllFamyliById((int)id);
                List<MapChart> _listItem = new List<MapChart>();
                //List<int> listMate;
                foreach (var item in list)
                {
                    if (item.MateId != null)
                    {
                        Mate mate = _mateDao.GetById((int)item.MateId);
                        MapChart map = new MapChart();
                        map.id = item.MateId.ToString() + "gr";
                        map.pid = mate.ParentId.ToString() + "gr";
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
                    map.birthday = String.Format("{0: dd/MM/yyyy}", item.BirthDate);
                    map.stpid = item.MateId.ToString() + "gr";
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
        public string birthday { get; set; }
        public string name { get; set; }
        public string img { get; set; }
    }
}

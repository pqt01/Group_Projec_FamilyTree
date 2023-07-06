using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
	public class MemberDAO
	{
		private FUFamilyTreeContext _context;
		public MemberDAO()
		{
			_context = new FUFamilyTreeContext();
		}
        public int GetMaxId()
        {
            return _context.Members.Max(m => m.Id);
        }
        public Member GetMemberByAccountId(string id)
		{
			return _context.Members.FirstOrDefault(m => m.AccountId == id);
		}
		public Member GetById(int id)
		{
			return _context.Members.FirstOrDefault(m => m.Id == id);
		}

		//public List<FlowerBouquet> SearchFlowerBouquetByName(string searchString)
		//{
		//	return _context.FlowerBouquets.Where(f => f.FlowerBouquetName.Contains(searchString))
		//		.Include(f => f.Category)
		//		.Include(f => f.Supplier).ToList();
		//}


		public void Add(Member member)
		{
			_context.Add(member);
			_context.SaveChanges();
		}
		public void UpdateAttach(Member member)
		{
			_context.Attach(member).State = EntityState.Modified;
			_context.SaveChanges();
		}
		//public void Delete(int id)
		//{
		//	var flo = GetFloBouById(id);
		//	var od = _context.OrderDetails
		//		.FirstOrDefault(od => od.FlowerBouquetId == id);
		//	if (flo != null && od == null)
		//	{
		//		_context.FlowerBouquets.Remove(flo);
		//		_context.SaveChanges();
		//	}
		//	else if (flo != null)
		//	{
		//		flo.FlowerBouquetStatus = 0;
		//		_context.SaveChanges();
		//	}
		//}
		public List<Member> GetAllByFamyliId(int id)
		{
			return _context.Members.Where(m => m.FamilyId == id).ToList();
		}
	}
}
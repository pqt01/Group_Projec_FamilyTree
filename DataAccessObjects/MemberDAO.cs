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

		public Member GetMemberByAccountId(string id)
		{
			return _context.Members.FirstOrDefault(m => m.AccountId == id);
		}

		//public List<FlowerBouquet> SearchFlowerBouquetByName(string searchString)
		//{
		//	return _context.FlowerBouquets.Where(f => f.FlowerBouquetName.Contains(searchString))
		//		.Include(f => f.Category)
		//		.Include(f => f.Supplier).ToList();
		//}


		//public void Add(FlowerBouquet flowerBouquet)
		//{
		//	flowerBouquet.FlowerBouquetId = GenerateFlowerBouquetId();
		//	flowerBouquet.FlowerBouquetStatus = 1;
		//	_context.Add(flowerBouquet);
		//	_context.SaveChanges();
		//}
		//public void UpdateAttach(FlowerBouquet flowerBouquet)
		//{
		//	if (GetFloBouById(flowerBouquet.FlowerBouquetId) != null)
		//	{
		//		_context.Attach(flowerBouquet).State = EntityState.Modified;
		//		_context.SaveChanges();
		//	}
		//}
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
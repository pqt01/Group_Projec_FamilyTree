using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
	public class FamilyDAO
	{
		private FUFamilyTreeContext _context;
		public FamilyDAO()
		{
			_context = new FUFamilyTreeContext();
		}
		public Family GetByCreatorIdId(int creatorIdId)
		{
			return _context.Families.FirstOrDefault(m => m.CreatorId == creatorIdId);
		}
		public void Add(Family family)
		{
			_context.Add(family);
			_context.SaveChanges();
		}
	}
}

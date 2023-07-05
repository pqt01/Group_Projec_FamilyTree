using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
	public class ImageDAO
	{
		private FUFamilyTreeContext _context;
		public ImageDAO()
		{
			_context = new FUFamilyTreeContext();
		}
		public List<Image> GetByFamyliId(int familyId)
		{
			return _context.Images.Where(i => i.FamilyId == familyId)
				.OrderByDescending(i => i.CreateDate).ToList();
		}
		public Image GetById(int id)
		{
			return _context.Images.FirstOrDefault(i => i.Id == id);
		}

		public void Add(Image image)
		{
			_context.Add(image);
			_context.SaveChanges();
		}
	}
}

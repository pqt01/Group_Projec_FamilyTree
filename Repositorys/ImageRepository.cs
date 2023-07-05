using BusinessObjects.Models;
using DataAccessObjects;
using Repositorys.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys
{
	public class ImageRepository : IImageRepository
	{
		private readonly ImageDAO _context = new ImageDAO();
		public void Add(Image image) => _context.Add(image);
		public List<Image> GetByFamyliId(int familyId) => _context.GetByFamyliId(familyId);
		public Image GetById(int id) => _context.GetById(id);
	}
}

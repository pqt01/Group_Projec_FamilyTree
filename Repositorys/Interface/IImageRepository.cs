using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.Interface
{
	public interface IImageRepository
	{
		public void Add(Image image);
		public List<Image> GetByFamyliId(int familyId);
		public Image GetById(int id);
		public void Delete(Image image);
	}
}

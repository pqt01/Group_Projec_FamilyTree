using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.Interface
{
	public interface IFamilyRepository
	{
		public void Add(Family family);
		public Family GetByCreatorIdId(int creatorIdId);
	}
}

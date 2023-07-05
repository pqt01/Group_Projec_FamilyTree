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
	public class FamilyRepository : IFamilyRepository
	{
		private readonly FamilyDAO _context = new FamilyDAO();

		public Family GetByCreatorIdId(int creatorIdId) => _context.GetByCreatorIdId(creatorIdId);
		public void Add(Family family) => _context.Add(family);
	}
}

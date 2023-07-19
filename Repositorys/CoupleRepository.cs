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
    public class MateRepository : IMateRepository
    {
        private readonly MateDAO _context = new MateDAO();
        public Mate GetById(int id) => _context.GetById(id);
    }
}

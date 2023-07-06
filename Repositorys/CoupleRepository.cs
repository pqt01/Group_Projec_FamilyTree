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
    public class CoupleRepository : ICoupleRepository
    {
        private readonly CoupleDAO _context = new CoupleDAO();
        public Couple GetById(int id) => _context.GetById(id);
    }
}

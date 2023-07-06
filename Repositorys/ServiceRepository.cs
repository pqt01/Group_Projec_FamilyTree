using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.Models;
using DataAccessObjects;
using Repositorys.Interface;

namespace Repositorys
{
    public class ServiceRepositorys : IserviceRepo
    {
        public readonly ServiceDAO serviceDAO = new ServiceDAO();
        public List<Service> GetAll() => serviceDAO.GetAll();
        
    }
}

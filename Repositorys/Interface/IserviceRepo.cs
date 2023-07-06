using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorys.Interface
{
   public interface IserviceRepo
    {
        public List<Service> GetAll() ;
    }
}

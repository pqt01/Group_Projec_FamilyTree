using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositorys.Interface
{
    public interface IServiceRepository
    {
        Service GetServiceById(int id);
        List<Service> GetListServiceByName(string name);
        List<Service> GetAll();
        void Add(Service service);
        void Update(Service service);
        void Delete(int id);
    }
}

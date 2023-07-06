using BusinessObjects.Models;
using DataAccessObjects;
using Repositorys.Interface;
using System.Collections.Generic;

namespace Repositorys
{
    public class ServiceRepository : IServiceRepository
    {
        private ServiceDAO _serviceDAO;

        public ServiceRepository()
        {
            _serviceDAO = new ServiceDAO();
        }

        public Service GetServiceById(int id)
        {
            return _serviceDAO.GetServiceById(id);
        }

        public List<Service> GetListServiceByName(string name)
        {
            return _serviceDAO.GetListServiceByName(name);
        }

        public List<Service> GetAll()
        {
            return _serviceDAO.GetAll();
        }

        public void Add(Service service)
        {
            _serviceDAO.Add(service);
        }

        public void Update(Service service)
        {
            _serviceDAO.Update(service);
        }

        public void Delete(int id)
        {
            _serviceDAO.Delete(id);
        }
    }

}

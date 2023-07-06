using BusinessObjects.Models;
using System.Collections.Generic;

namespace Repositorys.Interface
{
    public interface IEventRepository
    {
        List<Event> GetEvents();
    }
}

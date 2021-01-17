using System.Collections.Generic;
using System.Threading.Tasks;
using Radix.Domain.RadixContext.Entities;

namespace Radix.Domain.RadixContext.Repositories
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        Task<IEnumerable<Event>> GetAllEventsByUser(int id);
    }
}
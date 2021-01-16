using System.Threading.Tasks;
using Radix.Domain.RadixContext.Entities.Authentication;

namespace Radix.Domain.RadixContext.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> Login(string userName, string password);
    }
}
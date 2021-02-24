using Paybaymax.Data;
using System.Threading.Tasks;

namespace Paybaymax.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByCredentials(string email, string password);
    }
}

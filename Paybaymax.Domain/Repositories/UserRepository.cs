using Microsoft.EntityFrameworkCore;
using Paybaymax.Data;
using System.Threading.Tasks;

namespace Paybaymax.Domain.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(PaybaymaxContext context) : base(context) { }

        public async Task<User> GetUserByCredentials(string email, string password)
        {
            return await this.Context.Users
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
    }
}

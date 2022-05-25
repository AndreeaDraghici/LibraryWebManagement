using WebApp.Models;
using WebApp.Data;
using WebApp.Repositories.Interfaces;

namespace WebApp.Repositories
{
    public class UserRepository : RepositoryBase<User>,IUserRepository
    {
        public UserRepository(WebDBContext webDBContext) : base(webDBContext) { }
    }
}

using WebApp.Models;
using WebApp.Repositories.Interfaces;
using WebApp.Data;

namespace WebApp.Repositories
{
    public class AuthorBookRepository : RepositoryBase<AuthorBook>, IAuthorBookRepository
    {
        public AuthorBookRepository(WebDBContext webDBContext) : base(webDBContext)
        {
        }
    }
}

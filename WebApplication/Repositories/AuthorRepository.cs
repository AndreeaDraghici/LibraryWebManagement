using WebApp.Models;
using WebApp.Data;
using WebApp.Repositories.Interfaces;


namespace WebApp.Repositories
{
    public class AuthorRepository : RepositoryBase<Author> ,IAuthorRepository
    {
        public AuthorRepository(WebDBContext webDBContext) : base(webDBContext) { }
    }
}

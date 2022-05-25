using WebApp.Models;
using WebApp.Data;
using WebApp.Repositories.Interfaces;


namespace WebApp.Repositories
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public  BookRepository(WebDBContext webDBContext) : base(webDBContext) { }
    }
}

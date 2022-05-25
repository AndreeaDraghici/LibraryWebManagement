using WebApp.Models;
using WebApp.Data;
using WebApp.Repositories.Interfaces;


namespace WebApp.Repositories
{
    public class LibraryRepository : RepositoryBase<Library>, ILibraryRepository
    {
        public LibraryRepository (WebDBContext webDBContext) : base(webDBContext) { }
    }
}

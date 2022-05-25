using WebApp.Models;
using WebApp.Data;
using WebApp.Repositories.Interfaces;


namespace WebApp.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(WebDBContext webDBContext) : base(webDBContext) { }
    }
}

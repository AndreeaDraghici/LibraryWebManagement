using System.Linq.Expressions;
using WebApp.Models;
using WebApp.Repositories.Interfaces;

namespace WebApp.Services
{
    public class CategoryService : BaseService
    {
        public CategoryService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }
        public List<Category> GetCategories()
        {
            return wrapper.categoryRepository.FindAll().ToList();
        }

        public List<Category> GetCategoriesByCondition(Expression<Func<Category, bool>> expression)
        {
            return wrapper.categoryRepository.FindByCondition(expression).ToList();
        }

        public void AddCategory(Category category)
        {
            wrapper.categoryRepository.Create(category);
        }

        public void UpdateCategory(Category category)
        {
            wrapper.categoryRepository.Update(category);
        }
        public void DeleteCategory(Category category)
        {
            wrapper.categoryRepository.Delete(category);
        }

    }
}

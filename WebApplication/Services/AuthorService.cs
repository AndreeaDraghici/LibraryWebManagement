using System.Linq.Expressions;
using WebApp.Models;
using WebApp.Repositories.Interfaces;

namespace WebApp.Services
{
    public class AuthorService: BaseService
    {
        public AuthorService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }
        public List<Author> GetAuthors()
        {
            return wrapper.authorRepository.FindAll().ToList();
        }
        public List<Author> GetAuthorsByCondition(Expression<Func<Author, bool>> expression)
        {
            return wrapper.authorRepository.FindByCondition(expression).ToList();
        }
         
        public void AddAuthor(Author author)
        {
            wrapper.authorRepository.Create(author);
        }

        public void UpdateAuthor(Author author)
        {
            wrapper.authorRepository.Update(author);
        }

        public void DeleteAuthor(Author author)
        {
            wrapper.authorRepository.Delete(author);
        }

    }
}

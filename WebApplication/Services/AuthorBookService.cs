using System.Linq.Expressions;
using WebApp.Models;
using WebApp.Repositories.Interfaces;

namespace WebApp.Services
{
    public class AuthorBookService : BaseService
    {
        public AuthorBookService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }
        public List<AuthorBook> GetAuthorBooks()
        {
            return wrapper.authorBookRepository.FindAll().ToList();
        }

        public List<AuthorBook> GetAuthorBooksByCondition(Expression<Func<AuthorBook, bool>> expression)
        {
            return wrapper.authorBookRepository.FindByCondition(expression).ToList();
        }

        public void AddAuthorBook(AuthorBook authorBook)
        {
            wrapper.authorBookRepository.Create(authorBook);
        }

        public void UpdateAuthorBook(AuthorBook authorBook)
        {
            wrapper.authorBookRepository.Update(authorBook);
        }

        public void DeleteAuthorBook(AuthorBook authorBook)
        {
            wrapper.authorBookRepository.Delete(authorBook);
        }
    }
}

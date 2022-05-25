using System.Linq.Expressions;
using WebApp.Models;
using WebApp.Repositories.Interfaces;

namespace WebApp.Services
{
    public class BookService:BaseService
    {
        public BookService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }
        public List<Book> GetBooks()
        {
            return wrapper.bookRepository.FindAll().ToList();
        }
        public List<Book> GetBooksByCondition(Expression<Func<Book, bool>> expression)
        {
            return wrapper.bookRepository.FindByCondition(expression).ToList();
        }
        public void AddBook(Book book)
        {
            wrapper.bookRepository.Create(book);
        }

        public void UpdateBook(Book book)
        {
            wrapper.bookRepository.Update(book);
        }
        public void DeleteBook(Book book)
        {
            wrapper.bookRepository.Delete(book);
        }
    }
}

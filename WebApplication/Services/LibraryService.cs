using System.Linq.Expressions;
using WebApp.Models;
using WebApp.Repositories.Interfaces;

namespace WebApp.Services
{
    public class LibraryService : BaseService
    {
        public LibraryService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }

        public List<Library> GetLibraries()
        {
            return wrapper.libraryRepository.FindAll().ToList();
        }

        public List<Library> GetLibrariesByCondition(Expression<Func<Library, bool>> expression)
        {
            return wrapper.libraryRepository.FindByCondition(expression).ToList();
        }

        public void AddLibrary(Library library)
        {
            wrapper.libraryRepository.Create(library);
        }

        public void UpdateLibrary(Library library)
        {
            wrapper.libraryRepository.Update(library);
        }

        public void DeleteLibrary(Library library)
        {
            wrapper.libraryRepository.Delete(library);
        }
    }
}

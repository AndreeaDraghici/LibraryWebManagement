using WebApp.Models;
using WebApp.Repositories.Interfaces;
using WebApp.Data;

namespace WebApp.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private WebDBContext? dBContext;
        private IAuthorRepository? _authorRepository;
        private IAuthorBookRepository? _authorBookRepository;
        private IBookRepository? _bookRepository;
        private ICategoryRepository? _categoryRepository;
        private ILibraryRepository? _libraryRepository;
        private IMessageRepository? _messageRepository;
        private IUserRepository? _userRepository;

        public IAuthorRepository authorRepository
        {
            get
            {
                if (_authorRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _authorRepository = new AuthorRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                return _authorRepository;
            }
        }

        public IAuthorBookRepository authorBookRepository
        {
            get
            {
                if (_authorBookRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _authorBookRepository = new AuthorBookRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.

                }
                return _authorBookRepository;
            }
        }

        public IBookRepository bookRepository
        {
            get 
            {
                if (_bookRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _bookRepository = new BookRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                return _bookRepository;
            }
        }

        public ICategoryRepository categoryRepository
        {
            get 
            {
                if (_categoryRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _categoryRepository = new CategoryRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                return _categoryRepository; 
            }
        }

        public ILibraryRepository libraryRepository 
        { 
            get 
            {
                if (_libraryRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _libraryRepository = new LibraryRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.
                }

                return _libraryRepository; 
            } 
        }

        public IMessageRepository messageRepository
        {
            get 
            { 
                if(_messageRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _messageRepository = new MessageRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                return _messageRepository; 
            }

        }

        public IUserRepository userRepository
        {
            get
            {
                if (_userRepository == null)
                {
#pragma warning disable CS8604 // Possible null reference argument.
                    _userRepository = new UserRepository(dBContext);
#pragma warning restore CS8604 // Possible null reference argument.
                }
                return _userRepository;
            }
        }

        public RepositoryWrapper(WebDBContext webDBContext)
        {
            dBContext= webDBContext;
        }
        public void Save()
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            dBContext.SaveChanges();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}

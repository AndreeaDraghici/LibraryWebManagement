namespace WebApp.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAuthorRepository authorRepository { get; }
        IAuthorBookRepository authorBookRepository { get; }
        IBookRepository bookRepository { get; }

        ICategoryRepository categoryRepository { get; }

        ILibraryRepository libraryRepository { get; }

        IMessageRepository messageRepository{get;}

        IUserRepository userRepository { get; }

        void Save();

    }
}

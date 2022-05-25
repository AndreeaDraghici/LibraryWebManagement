using WebApp.Models;
using WebApp.Data;
using WebApp.Repositories.Interfaces;


namespace WebApp.Repositories
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(WebDBContext webDBContext) : base(webDBContext) { }
    }
}

using System.Linq.Expressions;
using WebApp.Models;
using WebApp.Repositories.Interfaces;

namespace WebApp.Services
{
    public class MessageService : BaseService
    {
        public MessageService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }

        public List<Message> GetMessages()
        {
            return wrapper.messageRepository.FindAll().ToList();
        }

        public List<Message> GetMessagesByCondition(Expression<Func<Message, bool>> expression)
        {
            return wrapper.messageRepository.FindByCondition(expression).ToList();
        }

        public void AddMessage(Message message)
        {
            wrapper.messageRepository.Create(message);
        }
        public void UpdateMessage(Message message)
        {
            wrapper.messageRepository.Update(message);
        }
        public void DeleteMessage(Message message)
        {
            wrapper.messageRepository.Delete(message);
        }

    }
}

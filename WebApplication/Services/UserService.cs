using System.Linq.Expressions;
using WebApp.Models;
using WebApp.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Services
{
    public class UserService : BaseService
    {
        public UserService(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper) { }
        public List<User> GetUsers()
        {
            return wrapper.userRepository.FindAll().ToList();
        }
        public List<User> GetUsersByCondition(Expression<Func<User, bool>> expression)
        {
            return wrapper.userRepository.FindByCondition(expression).ToList();
        }
        public void AddUser(User user)
        {
            wrapper.userRepository.Create(user);
        }
        public void UpdateUser(User user)
        {
            wrapper.userRepository.Update(user);
        }

        public void DeleteUser(User user)
        {
            wrapper.userRepository.Delete(user);
        }
    }
}

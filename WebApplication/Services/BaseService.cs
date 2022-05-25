using WebApp.Repositories.Interfaces;

namespace WebApp.Services
{
    public class BaseService
    {
        protected IRepositoryWrapper wrapper;
        public BaseService(IRepositoryWrapper repositoryWrapper)
        {
            wrapper = repositoryWrapper; 
        }
        public void Save()
        {
            wrapper.Save();
        }
    }
}

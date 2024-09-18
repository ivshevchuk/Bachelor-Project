namespace PIPlatform.UserManager.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork :IDisposable
    {
        public Task SaveAsync();
    }
}

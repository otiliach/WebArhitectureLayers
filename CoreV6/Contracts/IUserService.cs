using Core.Models;

namespace Core.Contracts
{
    public interface IUserService
    {
        List<UserForList> GetAll(int offset,int limit);

        Task<UserForList> GetById(int id);

        Task<UserForList> CreateUser(string userName, string password);

        Task<UserForList> ModifyUser(int userId, string userName);

        Task DeleteUser(int userId);
    }
}

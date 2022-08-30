using Core.Contracts;
using Core.Repositories;
using Core.Models;
using DataAccess.DataBase.Models;
namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRipository;

        public UserService(IRepository<User> userRipository)
        {
            _userRipository = userRipository;
        }

        public async Task<UserForList> CreateUser(string userName )//,string password
        {
            var user = new User() {Name = userName};
            var addedUser = await _userRipository.Add(user);
            return new UserForList(addedUser);
        }

        public async Task DeleteUser(int userId)
        {
            await _userRipository.Delete(userId);
        }

        public List<UserForList> GetAll(int offset, int limit)
        {
            var listOfDalUser = _userRipository.GetAll(offset,limit);
            return listOfDalUser.Select(element => new UserForList(element)).ToList();
           
        }

        public async Task<UserForList?> GetById(int id)
        {
            var user = await _userRipository.FindById(id);
            return user==null ? null : new UserForList(user);
        }

        public async Task<UserForList> ModifyUser(int userId, string userName)
        {
            var user =await _userRipository.FindById(userId);
            if (user == null)
            {
                throw new InvalidOperationException("User was not found");
            }

            user.Name=userName;
            var updateUser=await _userRipository.Update(user);
            return new UserForList(updateUser);
        }
    }
}

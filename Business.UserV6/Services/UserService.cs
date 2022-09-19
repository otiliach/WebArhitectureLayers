using Core.Contracts;
using Core.Repositories;
using Core.Models;
using DataAccess.Database.Models;
using Microsoft.AspNetCore.Identity;

namespace Business.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<ApplicationUser> _userRipository;
        private readonly UserManager<ApplicationUser> _userManager;


        public UserService(IRepository<ApplicationUser> userRipository, UserManager<ApplicationUser> userManager )
        {
            _userRipository = userRipository;
            _userManager = userManager;
        }

        public async Task<UserForList> CreateUser(string userName, string password)//,string password
        {
            var user = new ApplicationUser() {Name = userName};

            var result=await _userManager.CreateAsync(user, password);

            //var addedUser = await _userRipository.Add(user);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException(
                    $"User cannot be created because {result.Errors.First().Description}");
            }

            return new UserForList(user);
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

using DataAccess.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserRepository
    {

        //T Get();
        IEnumerable<ApplicationUser> GetAll(int offset, int limit);
        IEnumerable<ApplicationUser> FindByName(string name);
        Task<ApplicationUser?> FindById(int id);

        Task<ApplicationUser> Add(ApplicationUser item);

        Task<ApplicationUser> Update(ApplicationUser item);

        Task Delete(int id);


    }
}

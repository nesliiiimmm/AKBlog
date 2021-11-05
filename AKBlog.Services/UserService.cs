using AKBlog.Core;
using AKBlog.Core.Model;
using AKBlog.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKBlog.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<User> CreateUser(User newUser)
        {
            await _unitOfWork.Users.AddAsync(newUser);
            await _unitOfWork.CommitAsync();
            return newUser;
        }

        public async Task DeleteUser(User User)
        {
            User.IsActive = false;
            await _unitOfWork.CommitAsync();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _unitOfWork.Users.Where(x => x.IsActive == true);
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.Users.FirstOrDefaultAsync(x => x.ID == id && x.IsActive == true);
        }

        public User LoginUser(User user)
        {
            var res = _unitOfWork.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password && x.IsActive == true);
            if (res != null)
                return res.FirstOrDefault();
            else
                return null;
        }

        public async Task UpdateUser(User User)
        {
            await _unitOfWork.CommitAsync();
        }
    }
}

using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository
    {
        private readonly UserDao _userDao;

        public UserRepository(UserDao userDao)
        {
            _userDao = userDao;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _userDao.GetAllAsync();
        }

        public async Task<User> GetByIdAsync(string userId)
        {
            return await _userDao.GetByIdAsync(userId);
        }

        public async Task AddAsync(User user)
        {
            await _userDao.AddAsync(user);
        }

        public async Task UpdateAsync(User user)
        {
            await _userDao.UpdateAsync(user);
        }

        public async Task DeleteAsync(string userId)
        {
            await _userDao.DeleteAsync(userId);
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _userDao.GetByUsernameAsync(username);
        }
    }
}

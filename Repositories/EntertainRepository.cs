using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EntertainRepository
    {
        private readonly EntertainDAO _entertainDAO;

        public EntertainRepository(EntertainDAO entertainDAO)
        {
            _entertainDAO = entertainDAO;
        }

        public async Task<List<Entertain>> GetAllAsync()
        {
            return await _entertainDAO.GetAllAsync();
        }

        public async Task<Entertain> GetByIdAsync(string id)
        {
            return await _entertainDAO.GetByIdAsync(id);
        }

        public async Task CreateAsync(Entertain entertain)
        {
            await _entertainDAO.CreateAsync(entertain);
        }

        public async Task UpdateAsync(Entertain entertain)
        {
            await _entertainDAO.UpdateAsync(entertain);
        }

        public async Task DeleteAsync(string id)
        {
            await _entertainDAO.DeleteAsync(id);
        }
    }
}

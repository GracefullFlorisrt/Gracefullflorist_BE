using BusinessObj.Models;
using DataAccessObj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObj.DAO
{
    public class EntertainDAO
    {
        private readonly GRACEFULLFLORISTContext _context;

        public EntertainDAO(GRACEFULLFLORISTContext context)
        {
            _context = context;
        }

        public async Task<List<Entertain>> GetAllAsync()
        {
            return await _context.Entertains.ToListAsync();
        }

        public async Task<Entertain> GetByIdAsync(string id)
        {
            return await _context.Entertains.FindAsync(id);
        }

        public async Task CreateAsync(Entertain entertain)
        {
            await _context.Entertains.AddAsync(entertain);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Entertain entertain)
        {
            _context.Entertains.Update(entertain);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var entertain = await GetByIdAsync(id);
            if (entertain != null)
            {
                _context.Entertains.Remove(entertain);
                await _context.SaveChangesAsync();
            }
        }
    }

}

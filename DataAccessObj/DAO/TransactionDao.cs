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
    public class TransactionDao
    {
        private readonly GRACEFULLFLORISTContext _context;

        public TransactionDao(GRACEFULLFLORISTContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _context.Transactions
                .Include(t => t.Order) 
                .ToListAsync();
        }

        public async Task<Transaction> GetByIdAsync(string transactionId)
        {
            return await _context.Transactions
                .Include(t => t.Order)
                .FirstOrDefaultAsync(t => t.TransactionId == transactionId);
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string transactionId)
        {
            var transaction = await GetByIdAsync(transactionId);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            }
        }
    }
}

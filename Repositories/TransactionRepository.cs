using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    

    public class TransactionRepository
    {
        private readonly TransactionDao _transactionDao;

        public TransactionRepository(TransactionDao transactionDao)
        {
            _transactionDao = transactionDao;
        }

        public async Task<List<Transaction>> GetAllAsync()
        {
            return await _transactionDao.GetAllAsync();
        }

        public async Task<Transaction> GetByIdAsync(string transactionId)
        {
            return await _transactionDao.GetByIdAsync(transactionId);
        }

        public async Task AddAsync(Transaction transaction)
        {
            await _transactionDao.AddAsync(transaction);
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            await _transactionDao.UpdateAsync(transaction);
        }

        public async Task DeleteAsync(string transactionId)
        {
            await _transactionDao.DeleteAsync(transactionId);
        }
    }
}

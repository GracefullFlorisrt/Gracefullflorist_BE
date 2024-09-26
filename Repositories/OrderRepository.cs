using BusinessObj.Models;
using DataAccessObj.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepository
    {
        private readonly OrderDAO _orderDAO;

        public OrderRepository(OrderDAO orderDAO)
        {
            _orderDAO = orderDAO;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderDAO.GetAllAsync();
        }

        public async Task<Order> GetByIdAsync(string id)
        {
            return await _orderDAO.GetByIdAsync(id);
        }

        public async Task CreateAsync(Order order)
        {
            await _orderDAO.CreateAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            await _orderDAO.UpdateAsync(order);
        }

        public async Task DeleteAsync(string id)
        {
            await _orderDAO.DeleteAsync(id);
        }
    }
}

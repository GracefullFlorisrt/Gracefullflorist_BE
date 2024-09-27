using BusinessObj.Models;
using Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly OrderRepository _repo;

        public OrderService(OrderRepository repo)
        {
            _repo = repo;
        }

        public async Task<string> AddOrder(Order order)
        {
            return await _repo.CreateAsync(order);
        }

        public async Task<string> DeleteOrder(string id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<List<Order>> GetAllOrder()
        {
            try
            {
                return await _repo.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while fetching all attributes: {ex.Message}", ex);
            }
        }

        public async Task<Order> GetOrderByID(string id)
        {
            return await _repo.GetByIdAsync(id);
        }

        public async Task<string> UpdateOrder(Order order)
        {
            return await _repo.UpdateAsync(order);
        }
    }
}

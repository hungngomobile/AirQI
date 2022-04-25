using AuthenticationService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationService.Data
{
    public class SqlRepository : IEFRepository
    {
        private readonly ApplicationContext _context;
        public SqlRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByUserAsync<T>(string username, string password) where T : BaseEntity
        {
            return await _context.Set<T>().SingleOrDefaultAsync(e => e.Username == username && e.Password == password);
        }
    }
}
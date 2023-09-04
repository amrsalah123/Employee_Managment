using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using infrastructure;
using Microsoft.EntityFrameworkCore;
namespace BusinessLogic
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository() { }
        private readonly AppDbContext appDbContext;
        public EmployeeRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public async Task<IEnumerable<employee>> Get_All() => await appDbContext.employees.ToListAsync();
        public  IEnumerable<employee> SearchByName(string name) => appDbContext.employees.Where(model => model.name.ToLower().Contains(name.ToLower()));

        public async Task<employee> get(int id) => await appDbContext.employees.FindAsync(id);

        public async Task<int> Create(employee emp)
        {
            await appDbContext.employees.AddAsync(emp);
            return await appDbContext.SaveChangesAsync();
        }
        public async Task<int> Update(employee emp)
        {
            appDbContext.employees.Update(emp);
            return await appDbContext.SaveChangesAsync();
        }
        public async Task<int> Delete(employee emp)
        {
            appDbContext.employees.Remove(emp);
            return await appDbContext.SaveChangesAsync();

        }
       
    }
}

using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IEmployeeRepository
    {
        Task<int> Create(employee emp);
        public IEnumerable<employee> SearchByName(string name);
        Task<int> Delete(employee emp);
        Task<employee> get(int id);
        Task<IEnumerable<employee>> Get_All();
        Task<int> Update(employee emp);
    }
}
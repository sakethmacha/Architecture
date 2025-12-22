using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities;

namespace WebApp.Domain.Interfaces.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        void Update(Employee employee);
        Employee GetByEmail(string email);
    }
}

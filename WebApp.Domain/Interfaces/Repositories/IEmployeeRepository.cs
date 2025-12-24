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
        User GetById(int id);
        void Update(User employee);
        User GetByEmail(string email);
    }
}

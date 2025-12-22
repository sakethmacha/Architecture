using WebApp.Domain.Interfaces.Repositories;
using WebApp.Infrastructure.Persistance;
using WebApp.Domain.Entities;
namespace WebApp.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext DbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public Employee GetById(int id)
        {
            var employee = DbContext.Employees
                .SingleOrDefault(e => e.Id == id);

            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            return employee;
        }
        public Employee GetByEmail(string email)
        {
            var employee = DbContext.Employees
                .SingleOrDefault(e => e.Email == email);

            if (employee == null)
                throw new InvalidOperationException("Employee not found");

            return employee;
        }
        public void Update(Employee employee)
        {
            DbContext.Employees.Update(employee);
            DbContext.SaveChanges();
        }
    }

}

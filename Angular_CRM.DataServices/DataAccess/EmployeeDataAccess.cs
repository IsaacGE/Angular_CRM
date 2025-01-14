using Angular_CRM.DataServices.DataAccess.Interfaces;
using Angular_CRM.DataServices.DBContext;
using Angular_CRM.DataServices.Entities;
using Microsoft.EntityFrameworkCore;


namespace Angular_CRM.DataServices.DataAccess
{
    internal class EmployeeDataAccess : IEmployeeDataAccess
    {
        private readonly AppDbContext _ctx = new();

        public async Task<IEnumerable<Employee>> GetAll(int top = 100)
        {
            try
            {
                return await _ctx.Employees.Take(top).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}

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


        public async Task<(int, Employee)> Create(Employee data)
        {
            try
            {
                if (data == null || data.Id > 0) return await Update(data);

                var result = await _ctx.Employees.AddAsync(data);

                await _ctx.SaveChangesAsync();

                return (data.Id, data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
            

        public async Task<(int, Employee)> Update(Employee? data)
        {
            try
            {
                if (data == null || data.Id == 0) throw new NullReferenceException("Thre is no data to update for employee");

                var result = _ctx.Employees.Update(data);

                await _ctx.SaveChangesAsync();

                return (data.Id, data);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}

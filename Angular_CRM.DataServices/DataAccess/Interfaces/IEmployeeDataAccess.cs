using Angular_CRM.DataServices.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angular_CRM.DataServices.DataAccess.Interfaces
{
    public interface IEmployeeDataAccess
    {
        Task<IEnumerable<Employee>> GetAll(int top);
    }
}

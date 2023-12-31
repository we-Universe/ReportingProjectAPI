using Microsoft.EntityFrameworkCore;
using ReportingProject.Data.Contextes;
using ReportingProject.Data.Entities;

namespace ReportingProject.Repositories.MerchantRepository
{
	public class MerchantRepository : IMerchantRepository
    {
        private readonly ReportingDBContext _reportingDBContext;


        public MerchantRepository(ReportingDBContext reportingDBContext)
        {
            _reportingDBContext = reportingDBContext;
        }

        public async Task<int?> GetMerchantIdByEmployeeNameAsync(string employeeName)
        {
            Employee employee = await _reportingDBContext.Employees
                .Include(e => e.Merchants)
                .FirstOrDefaultAsync(e => e.Name.ToLower() == employeeName.ToLower());

            if (employee != null)
            {
                    return employee.ID;
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

            return null;
        }
    }
}
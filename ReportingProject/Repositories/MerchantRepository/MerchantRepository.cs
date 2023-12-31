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
            Console.WriteLine($"Searching for employee: {employeeName}");

            Employee employee = await _reportingDBContext.Employees
                .Include(e => e.Merchants)
                .FirstOrDefaultAsync(e => e.Name.ToLower() == employeeName.ToLower());

            if (employee != null)
            {
                Console.WriteLine($"Employee found: {employee.Name}");

                if (employee.Merchants != null && employee.Merchants.Any())
                {
                    Console.WriteLine($"Merchant found for employee: {employee.Merchants.First().EmloyeeId}");
                    return employee.Merchants.First().EmloyeeId;
                }
                else
                {
                    Console.WriteLine("No merchants associated with the employee.");
                }
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }

            return null;
        }
    }
}
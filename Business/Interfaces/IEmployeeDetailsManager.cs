using business.Views;
using Infrastructure.Entities;

namespace Business.Interfaces
{
    public interface IEmployeeDetailsManager
    {
        Task<List<EmployeeDetailsView>> GetAllEmployeesDetails();
        Task<EmployeeDetailsView> GetEmployeeDetailsById(int employeeId);
        Task<EmployeeDetailsView> AddEmployeeDetails(EmployeeDetailsModel model);
        Task<EmployeeDetailsView> UpdateEmployeeDetails(int Id, EmployeeDetailsModel model);
        Task<bool> DeleteEmployeeDetails(int id);
        //Task<List<EmployeeDetailsView>> GetEmployeesByDepartmentId(int id);
    }
}

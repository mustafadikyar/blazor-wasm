using PieShop.HRM.Models.Domain;

namespace PieShop.HRM.Interfaces;

public interface IEmployeeService
{
    Task<IEnumerable<Employee>> GetAllEmployees(bool refreshRequired = false);
    Task<Employee> GetEmployeeById(int employeeId);
    Task<Employee> AddEmployee(Employee employee);
    Task UpdateEmployee(Employee employee);
    Task DeleteEmployee(int employeeId);
}

using PieShop.HRM.Models.Domain;

namespace PieShop.HRM.Services.Interfaces;

public interface IEmployeeService
{
    IEnumerable<Employee> GetAllEmployees();
    Employee GetEmployeeById(int employeeId);
    Employee AddEmployee(Employee employee);
    Employee UpdateEmployee(Employee employee);
    void DeleteEmployee(int employeeId);
    //IEnumerable<EmployeeListModel> GetLongEmployeeList();
    //IEnumerable<EmployeeListModel> GetTakeLongEmployeeList(int request, int count);
}

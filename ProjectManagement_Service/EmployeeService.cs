using Microsoft.EntityFrameworkCore;
using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_Repository;
using ProjectManagement_Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepo employeeRepo = null;

        public EmployeeService()
        {
            employeeRepo = new EmployeeRepo();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return employeeRepo.GetEmployees();
        }

        public Employee GetEmployee(int id) => employeeRepo.GetEmployee(id);

        public IEnumerable<string> GetEmployeeVisa()
        {
            return employeeRepo.GetEmployeeVisa();
        }

        public void AddNew(Employee employee) => employeeRepo.AddNew(employee);
        public void Update(int id, Employee employee) => employeeRepo.Update(id, employee);
        public void Delete(int id) => employeeRepo.Delete(id);
        public IEnumerable<object> GetEmployeeName() => employeeRepo.GetEmployeeName();
        public IEnumerable<Employee> GetSearchEmployees(string visa, string firstName, string lastName) => employeeRepo.GetSearchEmployees(visa, firstName, lastName);
    }
}

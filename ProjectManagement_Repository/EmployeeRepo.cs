using Microsoft.EntityFrameworkCore;
using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_DAO;
using ProjectManagement_Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly EmployeeDAO employeeDAO = null;

        public EmployeeRepo()
        {
            employeeDAO = new EmployeeDAO();
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return employeeDAO.GetEmployees();
        }

        public Employee GetEmployee(int id) => employeeDAO.GetEmployee(id);

        public IEnumerable<string> GetEmployeeVisa()
        {
            return employeeDAO.GetEmployeeVisa();
        }

        public void AddNew(Employee employee) => employeeDAO.AddNew(employee);
        public void Update(int id, Employee employee) => employeeDAO.Update(id, employee);
        public void Delete(int id) => employeeDAO.Delete(id);
        public IEnumerable<object> GetEmployeeName() => employeeDAO.GetEmployeeName();
        public IEnumerable<Employee> GetSearchEmployees(string visa, string firstName, string lastName) => employeeDAO.GetSearchEmployees(visa, firstName, lastName);
    }
}

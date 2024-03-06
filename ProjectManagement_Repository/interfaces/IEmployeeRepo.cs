using Microsoft.EntityFrameworkCore;
using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_Repository.interfaces
{
    public interface IEmployeeRepo
    {
        public IEnumerable<Employee> GetEmployees();
        public Employee GetEmployee(int id);
        public IEnumerable<string> GetEmployeeVisa();
        public void AddNew(Employee employee);
        public void Update(int id, Employee employee);
        public void Delete(int id);
        public IEnumerable<object> GetEmployeeName();
        public IEnumerable<Employee> GetSearchEmployees(string visa, string firstName, string lastName);
    }
}

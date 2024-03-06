using Microsoft.EntityFrameworkCore;
using ProjectManagement_BusinessObjects.Database;
using ProjectManagement_BusinessObjects.Entities;
using ProjectManagement_BusinessObjects.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement_DAO
{
    public class EmployeeDAO
    {
        private readonly ProjectManagementContext _context = null;
        private static EmployeeDAO _instance = null;

        public static EmployeeDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new EmployeeDAO();
                }

                return _instance;
            }
        }

        public EmployeeDAO()
        {
            _context = new ProjectManagementContext();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public Employee GetEmployee(int id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);

            if (employee == null)
            {
                throw new Exception($"The employee with ID {id} does not exists");
            }
            return employee;
        }

        public IEnumerable<string> GetEmployeeVisa()
        {
            /*return _context.Employees.Select(e => new
            {
                Label = e.Visa + " - " + e.FirstName + " " + e.LastName,
                Value = e.Id,
            }).ToList();*/

            return _context.Employees.Select(e => e.Visa).ToList();
        }

        public IEnumerable<object> GetEmployeeName()
        {
            return _context.Employees.Select(e => new
            {
                Label = e.Visa + " - " + e.FirstName + " " + e.LastName,
                Value = e.Id,
            }).ToList();
        }

        public void AddNew(Employee employee)
        {
            Employee em = new()
            {
                Visa = employee.Visa,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Birthday = employee.Birthday,
            };    

            _context.Employees.Add(em);
            _context.SaveChanges();
        }
        public void Update(int id, Employee employee)
        {
            Employee em = _context.Employees.FirstOrDefault(x => x.Id == id);

            em.Visa = employee.Visa;
            em.FirstName = employee.FirstName;
            em.LastName = employee.LastName;
            em.Birthday = employee.Birthday;

            _context.Employees.Update(em);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entity = ex.Entries.Single();
                var databaseValues = entity.GetDatabaseValues();

                entity.OriginalValues.SetValues(databaseValues);
                throw new Exception("The record you attempt to update was modified by another user after you got the orginal values");
            }

        }
        public void Delete(int id)
        {
            var em = _context.Employees.Include(e => e.Group).FirstOrDefault(x => x.Id == id);

            if (em == null)
                throw new Exception($"The Employee witd ID {id} does not exist.");

            var group = _context.Groups.FirstOrDefault(x => x.GroupLeaderId == em.Id);

            if (group != null)
                _context.Groups.Remove(group);
            
            _context.Employees.Remove(em);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("Don't know how to handle concurrency conflicts");
            }
        }

        public IEnumerable<Employee> GetSearchEmployees(string visa, string firstName, string lastName)
        {
            var list = _context.Employees.AsEnumerable();
            if (visa != "")
                list = _context.Employees.Where(p => p.Visa.Contains(visa));
            else if (firstName != "")
            {
                list = _context.Employees.Where(p => p.FirstName.Contains(firstName));
            }
            else if (lastName != "")
            {
                list = _context.Employees.Where(p => p.LastName.Contains(lastName));
            }

            return list.ToList();
        }
    }
}

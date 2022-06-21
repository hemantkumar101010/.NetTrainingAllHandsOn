using EntityFrameworkData.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkData
{
    public class CRUDManager
    {
        private DemoDbContext demoDbContext;
        public CRUDManager()
        {
            demoDbContext = new DemoDbContext();
        }

        #region EMPLOYEE-CRUD
        public Employee GetEmplpoyeeById(int employeeId)
        {
            // Tracking not required
            var employee = demoDbContext.Employees.Where(x => x.ID == employeeId)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            if (employee == null)
            {
                throw new Exception($"Employee with ID:{employeeId} Not Found");
            }

            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            var employee = demoDbContext.Employees.ToList();
            return employee;
        }

        public void Insert(Employee employee)
        {
            demoDbContext.Employees.Add(employee);
            demoDbContext.SaveChanges();
        }

        public void Update(int employeeId, Employee modifiedEmployee)
        {
            var employee = demoDbContext.Employees.Where(x => x.ID == employeeId).FirstOrDefault();
            if (employee == null)
            {
                throw new Exception($"Employee with ID:{employeeId} Not Found");
            }

            employee.Name = modifiedEmployee.Name;
            employee.Address = modifiedEmployee.Address;

            // Entity state : Modified
            demoDbContext.Employees.Update(employee);

            // This issues insert statement
            demoDbContext.SaveChanges();
        }

        public void Delete(int employeeId)
        {
            var employee = demoDbContext.Employees.Where(x => x.ID == employeeId).FirstOrDefault();
            if (employee == null)
            {
                throw new Exception($"Employee with ID:{employeeId} Not Found");
            }

            // Entity state : Deleted
            demoDbContext.Employees.Remove(employee);

            // This issues insert statement
            demoDbContext.SaveChanges();
        }
        #endregion


        #region Employee-Education-CRUD

        //overload
        public void Insert(EmployeeEducation employeeEducation)
        {
            demoDbContext.EmployeeEducations.Add(employeeEducation);
            demoDbContext.SaveChanges();
        }

        public EmployeeEducation GetEmployeeEducationById(int employeeEducationId)
        {
    
            var employeeEducation = demoDbContext.EmployeeEducations.Where(x => x.ID == employeeEducationId)
                            .AsNoTracking()
                            .FirstOrDefaultAsync().Result;

            if (employeeEducation == null)
            {
                throw new Exception($"EmployeeEducations with ID:{employeeEducationId} Not Found");
            }

            return employeeEducation;
        }

        public List<EmployeeEducation> GetAllEmployeeEducation()
        {
            var employeeEducation = demoDbContext.EmployeeEducations.ToList();
            return employeeEducation;
        }

        public void Update(int employeeEducationId, EmployeeEducation modifiedEmployeeEducation)
        {
            var employeeEducation = demoDbContext.EmployeeEducations.Where(x => x.ID == employeeEducationId).FirstOrDefault();
            if (employeeEducation == null)
            {
                throw new Exception($"EmployeeEducation with ID:{employeeEducationId} Not Found");
            }

            employeeEducation.CourseName = modifiedEmployeeEducation.CourseName;
            employeeEducation.UniversityName = modifiedEmployeeEducation.UniversityName;

            employeeEducation.PassingYear = modifiedEmployeeEducation.PassingYear;
            employeeEducation.MarksPercentage = modifiedEmployeeEducation.MarksPercentage;

            // Entity state : Modified
            demoDbContext.EmployeeEducations.Update(employeeEducation);

            // This issues insert statement
            demoDbContext.SaveChanges();
        }

        public void DeleteEdu(int employeeEducationId)
        {
            var employeeEducation = demoDbContext.EmployeeEducations.Where(x => x.ID == employeeEducationId).FirstOrDefault();
            if (employeeEducation == null)
            {
                throw new Exception($"EmployeeEducation with ID:{employeeEducationId} Not Found");
            }

            // Entity state : Deleted
            demoDbContext.EmployeeEducations.Remove(employeeEducation);

            // This issues insert statement
            demoDbContext.SaveChanges();
        }
        #endregion

    }
}

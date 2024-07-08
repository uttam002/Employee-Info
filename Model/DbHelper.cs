using Employee_Info.Data;
using Employee_Info.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Employee_Info.Model
{
    public class DbHelper
    {
        private readonly AppDbContext _context;

        public DbHelper(AppDbContext context)
        {
            _context = context;
        }

        // GET all employees
        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public List<Projects> GetProjects()
        {
            return _context.Projects.ToList();
        }


        // GET employee by Id
        public Employee GetEmployeeById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        // POST (Create) or PUT (Update) project
        public void SaveProject(Projects project)
        {
            var dbProject = _context.Projects.FirstOrDefault(p => p.P_Id == project.P_Id);

            if (dbProject == null)
            {
                // POST (Create new project)
                dbProject = new Projects
                {
                    ProjectName = project.ProjectName,
                    ProjectDescription = project.ProjectDescription,
                    Status = project.Status,
                    empId = project.empId 
                };
                _context.Projects.Add(dbProject);
            }
            else
            {
                // PUT (Update existing project)
                dbProject.ProjectName = project.ProjectName;
                dbProject.ProjectDescription = project.ProjectDescription;
                dbProject.Status = project.Status;
                dbProject.empId = project.empId;  // Assuming empId is correctly mapped in Project entity
            }

            _context.SaveChanges();
        }

        // DELETE project by Id
        public void DeleteProject(int P_Id)
        {
            var project = _context.Projects.FirstOrDefault(p => p.P_Id == P_Id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }
    }
}

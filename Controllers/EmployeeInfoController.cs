using Employee_Info.Data;
using Employee_Info.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee_Info.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeInfoController : ControllerBase
    {
        private readonly DbHelper _db;

        public EmployeeInfoController(AppDbContext context)
        {
           _db = new DbHelper(context);
        }

        // GET: api/EmployeeInfo/GetEmployees
        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _db.GetEmployees();
                if (employees == null || employees.Count == 0)
                {
                    return NotFound(ResponseHandler.GetApiResponse(ResponseType.NotFound, "No employees found."));
                }
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, employees));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
        [HttpGet("GetProjects")]
        public IActionResult GetProjects()
        {
            try
            {
                var Projects = _db.GetProjects();
                if (Projects == null || Projects.Count == 0)
                {
                    return NotFound(ResponseHandler.GetApiResponse(ResponseType.NotFound, "No employees found."));
                }
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, Projects));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // GET: api/EmployeeInfo/GetEmployeeById/{id}
        [HttpGet("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var employee = _db.GetEmployeeById(id);
                if (employee == null)
                {
                    return NotFound(ResponseHandler.GetApiResponse(ResponseType.NotFound, $"Employee with ID {id} not found."));
                }
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, employee));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // POST: api/EmployeeInfo/SaveProject
        [HttpPost("SaveProject")]
        public IActionResult SaveProject([FromBody] Projects project)
        {
            try
            {
                _db.SaveProject(project);
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, "Project saved successfully."));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // PUT: api/EmployeeInfo/UpdateProject
        [HttpPut("UpdateProject")]
        public IActionResult UpdateProject([FromBody] Projects project)
        {
            try
            {
                _db.SaveProject(project);
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, "Project updated successfully."));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE: api/EmployeeInfo/DeleteProject/{id}
        [HttpDelete("DeleteProject/{id}")]
        public IActionResult DeleteProject(int id)
        {
            try
            {
                _db.DeleteProject(id);
                return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, $"Project with ID {id} deleted successfully."));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}

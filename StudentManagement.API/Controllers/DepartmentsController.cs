using Common.Helper.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StudentManagement.Abstraction.Command;
using StudentManagement.Abstraction.Models;
using StudentManagement.Abstraction.Service;
using StudentManagement.API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace StudentManagement.API.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly LoggingContext loggingContext;
        private readonly ILogger<DepartmentsController> _logger;
        private readonly IStudentManagementApplication _application;
        private readonly IStudentManagementQueryHandler _queryHandler;

        public DepartmentsController(ILogger<DepartmentsController> logger, IStudentManagementApplication application, IStudentManagementQueryHandler queryHandler)
        {
            _application = application;
            _queryHandler = queryHandler;
            _logger = logger;
            loggingContext = new LoggingContext("localhost", " StudentManagement API (Command)", "DepartmentsController", "", 200);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Department), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddBranch([FromBody] Department department)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            var data = JsonConvert.SerializeObject(department);
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} \n Data :{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, data);

            var command = new AddDepartment
            {
                CommandData = department

            };
            var commandResult = await _application.AddDepartment(command);
            return Ok(commandResult);
        }


        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateDepartment([FromBody] Department department)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            var data = JsonConvert.SerializeObject(department);
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} \n Data :{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, data);



            var command = new UpdateDepartment
            {
                CommandData = department,

            };
            var commandResult = await _application.UpdateDepartment(command);
            return Ok(commandResult);
        }

        [HttpDelete("{departmentId}")]
        public async Task<IActionResult> DeleteBranch(Guid departmentId)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4}  Id:{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, departmentId);

            var deleteEntity = new EntityId { Id = departmentId };
            var command = new DeleteDepartment
            {
                CommandData = deleteEntity,

            };
            var commandResult = await _application.RemoveDepartment(command);
            if (commandResult.Accepted)
            {
                return Ok(commandResult);
            }
            return BadRequest(commandResult.Messages);
        }

        [HttpGet]
        [Route("{branchId}")]
        public async Task<ActionResult<IEnumerable<Department>>> GetBranch(Guid departmentId)
        {

            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} Id: {5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, departmentId);




            var department = await _queryHandler.GetDepartment(departmentId);
            return Ok(department);
        }

        [HttpGet]
        public async Task<ActionResult<Department>> GetDepartment()
        {

            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} ", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode);
            var searchParameters = new List<SearchParameter>();

            var departments = await _queryHandler.GetAlldepartments();
            return Ok(departments);
        }
        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<Department>> GetDepartmentsFilters( string departmentName)
        {

            loggingContext.ActionName = "GetSales";
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} Id: {5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, departmentName);
            var searchParameters = new List<SearchParameter> { };

            if (!string.IsNullOrEmpty(departmentName))
            {

                searchParameters.Add(new SearchParameter { Name = "Name", Value = departmentName });
            }
            var departments = await _queryHandler.GetStudents(searchParameters);
            return Ok(departments);
        }
    }
}


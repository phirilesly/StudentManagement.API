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
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly LoggingContext loggingContext;
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentManagementApplication _application;
        private readonly IStudentManagementQueryHandler _queryHandler;

        public StudentsController(ILogger<StudentsController> logger, IStudentManagementApplication application, IStudentManagementQueryHandler queryHandler)
        {
            _application = application;
            _queryHandler = queryHandler;
            _logger = logger;
            loggingContext = new LoggingContext("localhost", " StudentManagement API (Command)", "StudentsController", "", 200);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Student), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            var data = JsonConvert.SerializeObject(student);
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} \n Data :{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, data);

            var command = new AddStudent
            {
                CommandData = student

            };
            var commandResult = await _application.AddStudent(command);
            return Ok(commandResult);
        }


        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            var data = JsonConvert.SerializeObject(student);
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} \n Data :{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, data);



            var command = new UpdateStudent
            {
                CommandData = student,

            };
            var commandResult = await _application.UpdateStudent(command);
            return Ok(commandResult);
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(Guid studentId)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4}  Id:{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, studentId);

            var deleteEntity = new EntityId { Id = studentId };
            var command = new DeleteStudent
            {
                CommandData = deleteEntity,

            };
            var commandResult = await _application.RemoveStudent(command);
            if (commandResult.Accepted)
            {
                return Ok(commandResult);
            }
            return BadRequest(commandResult.Messages);
        }

        [HttpGet]
        [Route("{studentId}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent(Guid studentId)
        {

            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} Id: {5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, studentId);




            var student = await _queryHandler.GetStudent(studentId);
            return Ok(student);
        }

        [HttpGet]
        public async Task<ActionResult<Student>> GetProgrames()
        {

            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} ", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode);
            var searchParameters = new List<SearchParameter>();

            var students = await _queryHandler.GetAllStudents();
            return Ok(students);
        }

        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<Student>> GetStudentsFilter(Guid? departmentId,Guid? programId, Guid? studentId, string studentRegNumber,string studentName)
        {

            loggingContext.ActionName = "GetSales";
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} Id: {5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, programId);
            var searchParameters = new List<SearchParameter> { };

            if (departmentId.HasValue && departmentId.Value != Guid.Empty)
            {
                searchParameters.Add(new SearchParameter { Name = "DEPARTMENTID", Value = departmentId.Value.ToString() });
            }
            if (programId.HasValue && programId.Value != Guid.Empty)
            {
                searchParameters.Add(new SearchParameter { Name = "PROGRAMID", Value = programId.Value.ToString() });
            }
            if (studentId.HasValue && studentId.Value != Guid.Empty)
            {
                searchParameters.Add(new SearchParameter { Name = "STUDENTID", Value = studentId.Value.ToString() });
            }
            if (!string.IsNullOrEmpty(studentRegNumber))
            {
               
                searchParameters.Add(new SearchParameter { Name = "STUDENTREG", Value = studentRegNumber });
            }
            if (!string.IsNullOrEmpty(studentName))
            {

                searchParameters.Add(new SearchParameter { Name = "NAME", Value = studentName });
            }
            var sales = await _queryHandler.GetStudents(searchParameters);
            return Ok(sales);
        }
    }
}


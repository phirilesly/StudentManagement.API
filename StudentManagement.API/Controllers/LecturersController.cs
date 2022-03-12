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
    [Route("api/lecturers")]
    [ApiController]
    public class LecturersController : ControllerBase
    {
        private readonly LoggingContext loggingContext;
        private readonly ILogger<LecturersController> _logger;
        private readonly IStudentManagementApplication _application;
        private readonly IStudentManagementQueryHandler _queryHandler;

        public LecturersController(ILogger<LecturersController> logger, IStudentManagementApplication application, IStudentManagementQueryHandler queryHandler)
        {
            _application = application;
            _queryHandler = queryHandler;
            _logger = logger;
            loggingContext = new LoggingContext("localhost", " StudentManagement API (Command)", "LecturersController", "", 200);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Lecturer), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddBranch([FromBody] Lecturer lecturer)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            var data = JsonConvert.SerializeObject(lecturer);
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} \n Data :{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, data);

            var command = new AddLecturer
            {
                CommandData = lecturer

            };
            var commandResult = await _application.AddLecturer(command);
            return Ok(commandResult);
        }


        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateBranch([FromBody] Lecturer lecturer)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            var data = JsonConvert.SerializeObject(lecturer);
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} \n Data :{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, data);



            var command = new UpdateLecturer
            {
                CommandData = lecturer,

            };
            var commandResult = await _application.UpdateLecturer(command);
            return Ok(commandResult);
        }

        [HttpDelete("{lecturerId}")]
        public async Task<IActionResult> DeleteBranch(Guid lecturerId)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4}  Id:{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, lecturerId);

            var deleteEntity = new EntityId { Id = lecturerId };
            var command = new DeleteLecturer
            {
                CommandData = deleteEntity,

            };
            var commandResult = await _application.DeleteLecturer(command);
            if (commandResult.Accepted)
            {
                return Ok(commandResult);
            }
            return BadRequest(commandResult.Messages);
        }

        [HttpGet]
        [Route("{branchId}")]
        public async Task<ActionResult<IEnumerable<Lecturer>>> GetBranch(Guid lecturerId)
        {

            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} Id: {5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, lecturerId);




            var lecturer = await _queryHandler.GetLecturer(lecturerId);
            return Ok(lecturer);
        }

        [HttpGet]
        public async Task<ActionResult<Lecturer>> GetBranches()
        {

            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} ", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode);
            var searchParameters = new List<SearchParameter>();

            var lecturers = await _queryHandler.GetAllLecturers();
            return Ok(lecturers);
        }

        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<Student>> GetLecturersFilters(Guid? departmentId, Guid? courseId,string lecturerName)
        {

            loggingContext.ActionName = "GetSales";
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} Id: {5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, courseId);
            var searchParameters = new List<SearchParameter> { };

            if (departmentId.HasValue && departmentId.Value != Guid.Empty)
            {
                searchParameters.Add(new SearchParameter { Name = "DEPARTMENTID", Value = departmentId.Value.ToString() });
            }
            if (courseId.HasValue && courseId.Value != Guid.Empty)
            {
                searchParameters.Add(new SearchParameter { Name = "COURSEID", Value = courseId.Value.ToString() });
            }
            if (!string.IsNullOrEmpty(lecturerName))
            {
                searchParameters.Add(new SearchParameter { Name = "Name", Value = lecturerName });
            }
            var lecturers = await _queryHandler.GetStudents(searchParameters);
            return Ok(lecturers);
        }
    }
}


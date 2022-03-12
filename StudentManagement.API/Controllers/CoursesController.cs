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
    [Route("api/courses")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly LoggingContext loggingContext;
        private readonly ILogger<CoursesController> _logger;
        private readonly IStudentManagementApplication _application;
        private readonly IStudentManagementQueryHandler _queryHandler;

        public CoursesController(ILogger<CoursesController> logger, IStudentManagementApplication application, IStudentManagementQueryHandler queryHandler)
        {
            _application = application;
            _queryHandler = queryHandler;
            _logger = logger;
            loggingContext = new LoggingContext("localhost", " StudentManagementManagement API (Command)", "CoursesController", "", 200);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Course), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddBranch([FromBody] Course course)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            var data = JsonConvert.SerializeObject(course);
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} \n Data :{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, data);

            var command = new AddCourse
            {
                CommandData = course

            };
            var commandResult = await _application.Addcourse(command);
            return Ok(commandResult);
        }


        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateBranch([FromBody] Course course)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            var data = JsonConvert.SerializeObject(course);
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} \n Data :{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, data);



            var command = new UpdateCourse
            {
                CommandData = course,

            };
            var commandResult = await _application.UpdateCourse(command);
            return Ok(commandResult);
        }

        [HttpDelete("{courseId}")]
        public async Task<IActionResult> DeleteBranch(Guid courseId)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4}  Id:{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, courseId);

            var deleteEntity = new EntityId { Id = courseId };
            var command = new DeleteCourse
            {
                CommandData = deleteEntity,

            };
            var commandResult = await _application.RemoveCourse(command);
            if (commandResult.Accepted)
            {
                return Ok(commandResult);
            }
            return BadRequest(commandResult.Messages);
        }

        [HttpGet]
        [Route("{courseId}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetBranch(Guid courseId)
        {

            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} Id: {5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, courseId);




            var course = await _queryHandler.GetCourse(courseId);
            return Ok(course);
        }

        [HttpGet]
        public async Task<ActionResult<Course>> GetCourses()
        {

            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} ", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode);
            var searchParameters = new List<SearchParameter>();

            var courses = await _queryHandler.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<Student>> GetCourseFilter(Guid? departmentId, Guid? programId, Guid? lecturerId, string courseName,string level)
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
            if (lecturerId.HasValue && lecturerId.Value != Guid.Empty)
            {
                searchParameters.Add(new SearchParameter { Name = "LECTURERID", Value = lecturerId.Value.ToString() });
            }
            if (!string.IsNullOrEmpty(courseName))
            {

                searchParameters.Add(new SearchParameter { Name = "NAME", Value = courseName });
            }
            if (!string.IsNullOrEmpty(level))
            {

                searchParameters.Add(new SearchParameter { Name = "LEVEL", Value = level });
            }
            var courses = await _queryHandler.GetCourses(searchParameters);
            return Ok(courses);
        }
    }
}


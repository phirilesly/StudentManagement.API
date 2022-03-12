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
    [Route("api/programs")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly LoggingContext loggingContext;
        private readonly ILogger<ProgramController> _logger;
        private readonly IStudentManagementApplication _application;
        private readonly IStudentManagementQueryHandler _queryHandler;

        public ProgramController(ILogger<ProgramController> logger, IStudentManagementApplication application, IStudentManagementQueryHandler queryHandler)
        {
            _application = application;
            _queryHandler = queryHandler;
            _logger = logger;
            loggingContext = new LoggingContext("localhost", " StudentManagement API (Command)", "ProgramController", "", 200);
        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DegreeProgram), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> AddProgram([FromBody] DegreeProgram program)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            var data = JsonConvert.SerializeObject(program);
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} \n Data :{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, data);

            var command = new AddDegreeProgram
            {
                CommandData = program

            };
            var commandResult = await _application.AddDegreeProgram(command);
            return Ok(commandResult);
        }


        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CommandResult), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateProgram([FromBody] DegreeProgram program)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            var data = JsonConvert.SerializeObject(program);
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} \n Data :{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, data);



            var command = new UpdateDegreeProgram
            {
                CommandData = program,

            };
            var commandResult = await _application.UpdateDegreeProgram(command);
            return Ok(commandResult);
        }

        [HttpDelete("{programId}")]
        public async Task<IActionResult> DeleteProgram(Guid programId)
        {
            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4}  Id:{5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, programId);

            var deleteEntity = new EntityId { Id = programId };
            var command = new DeleteDegreeProgram
            {
                CommandData = deleteEntity,

            };
            var commandResult = await _application.DeleteDegreeProgram(command);
            if (commandResult.Accepted)
            {
                return Ok(commandResult);
            }
            return BadRequest(commandResult.Messages);
        }

        [HttpGet]
        [Route("{programId}")]
        public async Task<ActionResult<IEnumerable<DegreeProgram>>> GetProgram(Guid programId)
        {

            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} Id: {5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, programId);




            var program = await _queryHandler.GetDegreeProgram(programId);
            return Ok(program);
        }

        [HttpGet]
        public async Task<ActionResult<DegreeProgram>> GetPrograms()
        {

            loggingContext.ActionName = MethodBase.GetCurrentMethod().Name;
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} ", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode);
            var searchParameters = new List<SearchParameter>();

            var programes = await _queryHandler.GetAllDegreePrograms();
            return Ok(programes);
        }


        [HttpGet]
        [Route("filter")]
        public async Task<ActionResult<Student>> GetProgramFilter(Guid? departmentId, string level,string programName)
        {

            loggingContext.ActionName = "GetSales";
            _logger.LogInformation("Server Name: {0} Api Name : {1} Contoller Name : {2}, Action Name :{3} Status Code :{4} Id: {5}", loggingContext.ServerName, loggingContext.APIName, loggingContext.ControllerName, loggingContext.ActionName, loggingContext.StatusCode, departmentId);
            var searchParameters = new List<SearchParameter> { };

            if (departmentId.HasValue && departmentId.Value != Guid.Empty)
            {
                searchParameters.Add(new SearchParameter { Name = "DEPARTMENTID", Value = departmentId.Value.ToString() });
            }
            if (!string.IsNullOrEmpty(level))
            {

                searchParameters.Add(new SearchParameter { Name = "LEVEL", Value = level });
            }
            if (!string.IsNullOrEmpty(programName))
            {

                searchParameters.Add(new SearchParameter { Name = "NAME", Value = programName });
            }
            var programs = await _queryHandler.GetDegreePrograms(searchParameters);
            return Ok(programs);
        }
    }
}


using Microsoft.AspNetCore.Mvc;
using Operation_Platform.Interfaces;
using Operation_Platform.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Operation_Platform.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationController : ControllerBase
    {
        private readonly IOperationService _operationService;
        public OperationController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpPost("AddOperation")]
        public async Task<ActionResult<string>> AddOperation(Operation operation)
        {
            try
            {
                return Ok(await _operationService.AddOperation(operation));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetLastThree/{selectedOperator}")]
        public async Task<ActionResult<List<Operation>>> GetLastThreeOperations(string selectedOperator)
        {
            try
            {
                return Ok(await _operationService.GetLastThreeOperations(selectedOperator));
            }
            catch(Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetThisMonthCount/{selectedOperator}")]
        public async Task<ActionResult<int>> GetCountOfSameTypeOperationsFromStartOfMonth(string selectedOperator)
        {
            try
            {
                return Ok(await _operationService.GetCountOfSameTypeOperationsFromStartOfMonth(selectedOperator));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpGet("GetAggregate/{selectedOperator}")]
        public async Task<ActionResult<Aggregate>> GetAggregateDataForSameTypeOperation(string selectedOperator)
        {
            try
            {
                return Ok(await _operationService.GetAggregateDataForSameTypeOperation(selectedOperator));
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}

using Operation_Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Operation_Platform.Interfaces
{
    public interface IOperationService
    {
        public Task<string> AddOperation(Operation operation);

        public Task<List<Operation>> GetLastThreeOperations(string currentOperator);

        public Task<int> GetCountOfSameTypeOperationsFromStartOfMonth(string currentOperator);

        public Task<Aggregate> GetAggregateDataForSameTypeOperation(string currentOperator);
    }
}

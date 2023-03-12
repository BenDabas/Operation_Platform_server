using Operation_Platform.Data;
using Operation_Platform.Interfaces;
using Operation_Platform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Operation_Platform.Services
{
    public class OperationService : IOperationService
    {
        private readonly DataContext _context;

        public OperationService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddOperation(Operation operation)
        {
            try
            {
                switch (operation.Operator)
                {
                    case "Plus":
                        {
                            var firstOperation = double.Parse(operation.FirstField);
                            var secondOperation = double.Parse(operation.SecondField);
                            var result = (firstOperation + secondOperation).ToString();
                            operation.Result = result;
                            await SaveOperationInDB(operation);
                            return result;
                        }

                    case "-":
                        {
                            var firstOperation = double.Parse(operation.FirstField);
                            var secondOperation = double.Parse(operation.SecondField);
                            var result = (firstOperation - secondOperation).ToString();
                            operation.Result = result;
                            await SaveOperationInDB(operation);
                            return result;
                        }
                    case "*":
                        {
                            var firstOperation = double.Parse(operation.FirstField);
                            var secondOperation = double.Parse(operation.SecondField);
                            var result = (firstOperation * secondOperation).ToString();
                            operation.Result = result;
                            await SaveOperationInDB(operation);
                            return result;
                        }
                    case "Divide":
                        {
                            var firstOperation = double.Parse(operation.FirstField);
                            var secondOperation = double.Parse(operation.SecondField);
                            var result = (firstOperation / secondOperation).ToString();
                            operation.Result = result;
                            await SaveOperationInDB(operation);
                            return result;
                        }
                    case "Concatenation":
                        {
                            var result = operation.FirstField + operation.SecondField;
                            operation.Result = result;
                            await SaveOperationInDB(operation);
                            return result;
                        }
                    default:
                        throw new ArgumentException($"Invalid operator: {operation.Operator}");


                }
            }
            catch (FormatException exception)
            {
                throw new ArgumentException($"Invalid input format: {exception.Message}");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<Aggregate> GetAggregateDataForSameTypeOperation(string currentOperator)
        {
            try
            {
                var operations = await _context.Operations.Where(op => op.Operator == currentOperator).ToListAsync();
                var max = operations.Max(op => double.Parse(op.Result));
                var min = operations.Min(op => double.Parse(op.Result));
                var avg = operations.Average(op => double.Parse(op.Result));

                return new Aggregate { Max = max, Min = min, Average = avg };
            }
            catch (Exception exception)
            {
                throw new Exception($"Error getting aggregate data: {exception.Message}");
            }
        }

        public async Task<int> GetCountOfSameTypeOperationsFromStartOfMonth(string currentOperator)
        {
            try
            {
                DateTime startOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                var count = await _context.Operations.Where(op => op.Operator == currentOperator && op.DateTime >= startOfMonth).CountAsync();
                return count;
            }
            catch (Exception exception)
            {
                throw new Exception($"Error getting count of same type operations from start of month: {exception.Message}");
            }
        }

        public async Task<List<Operation>> GetLastThreeOperations(string currentOperator)
        {
            try
            {
                var lastThreeOperation = await _context.Operations.Where(op => op.Operator == currentOperator).OrderByDescending(op => op.DateTime).Take(3).ToListAsync();
                return lastThreeOperation;
            }
            catch (Exception exception)
            {
                throw new Exception($"Error getting last three operations: {exception.Message}");
            }
        }


        private async Task SaveOperationInDB(Operation operation)
        {
            var op = new Operation { FirstField = operation.FirstField, SecondField = operation.SecondField, Operator = operation.Operator, DateTime = DateTime.Now, Result = operation.Result };

            _context.Operations.Add(op);

            await _context.SaveChangesAsync();
        }
    }
}

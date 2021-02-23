using OracleEFCore5.Domain.Entities;
using System.Collections.Generic;

namespace OracleEFCore5.Application.Interfaces
{
    public interface IMockService
    {
        List<Position> GetPositions(int rowCount);
        List<Employee> GetEmployees(int rowCount);
        List<Position> SeedPositions(int rowCount);
    }
}
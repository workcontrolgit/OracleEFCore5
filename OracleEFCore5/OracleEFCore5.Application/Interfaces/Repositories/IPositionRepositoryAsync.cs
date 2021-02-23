using OracleEFCore5.Application.Features.Positions.Queries.GetPositions;
using OracleEFCore5.Application.Parameters;
using OracleEFCore5.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Interfaces.Repositories
{
    public interface IPositionRepositoryAsync : IGenericRepositoryAsync<Position>
    {
        Task<bool> IsUniquePositionNumberAsync(string positionNumber);

        Task<bool> SeedDataAsync(int rowCount);

        Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedPositionReponseAsync(GetPositionsQuery requestParameters);
    }
}

using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.Positions.Commands.CreatePosition
{
    public partial class InsertMockPositionCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedPositionCommandHandler : IRequestHandler<InsertMockPositionCommand, Response<int>>
    {
        private readonly IPositionRepositoryAsync _positionRepository;
        public SeedPositionCommandHandler(IPositionRepositoryAsync positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<Response<int>> Handle(InsertMockPositionCommand request, CancellationToken cancellationToken)
        {
            await _positionRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}

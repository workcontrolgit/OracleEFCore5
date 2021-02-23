using AutoMapper;
using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using OracleEFCore5.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.Positions.Commands.CreatePosition
{
    public partial class CreatePositionCommand : IRequest<Response<Guid>>
    {
        public string PositionTitle { get; set; }
        public string PositionNumber { get; set; }
        public string PositionDescription { get; set; }
        public decimal PositionSalary { get; set; }
    }
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, Response<Guid>>
    {
        private readonly IPositionRepositoryAsync _positionRepository;
        private readonly IMapper _mapper;
        public CreatePositionCommandHandler(IPositionRepositoryAsync positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = _mapper.Map<Position>(request);
            await _positionRepository.AddAsync(position);
            return new Response<Guid>(position.Id);
        }
    }
}

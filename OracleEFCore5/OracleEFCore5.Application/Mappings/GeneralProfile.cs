using AutoMapper;
using OracleEFCore5.Application.Features.Employees.Queries.GetEmployees;
using OracleEFCore5.Application.Features.Positions.Commands.CreatePosition;
using OracleEFCore5.Application.Features.Positions.Queries.GetPositions;
using OracleEFCore5.Domain.Entities;

namespace OracleEFCore5.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Position, GetPositionsViewModel>().ReverseMap();
            CreateMap<Employee, GetEmployeesViewModel>().ReverseMap();
            CreateMap<CreatePositionCommand, Position>();
        }
    }

}

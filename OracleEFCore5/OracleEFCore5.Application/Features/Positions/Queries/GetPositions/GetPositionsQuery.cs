﻿using AutoMapper;
using MediatR;
using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Parameters;
using OracleEFCore5.Application.Wrappers;
using OracleEFCore5.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.Positions.Queries.GetPositions
{
    public class GetPositionsQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
    {
        public string PositionNumber { get; set; }
        public string PositionTitle { get; set; }
    }

    public class GetAllPositionsQueryHandler : IRequestHandler<GetPositionsQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly IPositionRepositoryAsync _positionRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;

        public GetAllPositionsQueryHandler(IPositionRepositoryAsync positionRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetPositionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = request;
            var pagination = request;
            //filtered fields security
            if (!string.IsNullOrEmpty(validFilter.Fields))
            {
                //limit to fields in view model
                validFilter.Fields = _modelHelper.ValidateModelFields<GetPositionsViewModel>(validFilter.Fields);
            }
            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<GetPositionsViewModel>();
            }
            // query based on filter
            var entityPositions = await _positionRepository.GetPagedPositionReponseAsync(validFilter);
            var data = entityPositions.data;
            RecordsCount recordCount = entityPositions.recordsCount;
            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(data, validFilter.PageNumber, validFilter.PageSize, recordCount);
        }
    }
}

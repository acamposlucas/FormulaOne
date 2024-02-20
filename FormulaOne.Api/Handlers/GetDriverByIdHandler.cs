using AutoMapper;
using FormulaOne.Api.Queries;
using FormulaOne.DataService.Dtos.Responses;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class GetDriverByIdHandler : IRequestHandler<GetDriverByIdQuery, GetDriverResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetDriverByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetDriverResponse> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
    {
        // null is returned if not found.
        var driver = await _unitOfWork.Drivers.GetById(request.DriverId);
        
        return _mapper.Map<GetDriverResponse>(driver);
    }
}

using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Dtos.Responses;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class CreateDriverHandler : IRequestHandler<CreateDriverInfoRequest, GetDriverResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetDriverResponse> Handle(CreateDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Driver>(request.DriverRequest);

        await _unitOfWork.Drivers.Add(result);
        await _unitOfWork.CompleteAsync();

        return _mapper.Map<GetDriverResponse>(result);
    }
}

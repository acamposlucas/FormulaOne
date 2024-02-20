using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Dtos.Responses;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class UpdateDriverHandler : IRequestHandler<UpdateDriverInfoRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var result = _mapper.Map<Driver>(request.DriverRequest);

        await _unitOfWork.Drivers.Update(result);

        return await _unitOfWork.CompleteAsync();
    }
}

using AutoMapper;
using FormulaOne.Api.Commands;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using MediatR;

namespace FormulaOne.Api.Handlers;

public class DeleteDriverHandler : IRequestHandler<DeleteDriverInfoRequest, bool>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DeleteDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<bool> Handle(DeleteDriverInfoRequest request, CancellationToken cancellationToken)
    {
        var driver = await _unitOfWork.Drivers.GetById(request.DriverId);

        if (driver is null)
        {
            return false;
        }

        await _unitOfWork.Drivers.Delete(request.DriverId);
        return await _unitOfWork.CompleteAsync();
    }
}

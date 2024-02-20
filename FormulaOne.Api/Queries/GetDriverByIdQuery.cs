using FormulaOne.DataService.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries;

public class GetDriverByIdQuery : IRequest<GetDriverResponse>
{
    public Guid DriverId { get; }

    public GetDriverByIdQuery(Guid driverId)
    {
        DriverId = driverId;
    }
}

using FormulaOne.DataService.Dtos.Requests;
using FormulaOne.DataService.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Commands;

public class UpdateDriverInfoRequest : IRequest<bool>
{
    public UpdateDriverRequest DriverRequest { get; }

    public UpdateDriverInfoRequest(UpdateDriverRequest driverRequest)
    {
        DriverRequest = driverRequest;
    }
}

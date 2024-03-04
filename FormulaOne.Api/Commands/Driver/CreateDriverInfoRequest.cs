using FormulaOne.DataService.Dtos.Requests;
using FormulaOne.DataService.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Commands;

public class CreateDriverInfoRequest : IRequest<GetDriverResponse>
{
    public CreateDriverRequest DriverRequest { get; }

    public CreateDriverInfoRequest(CreateDriverRequest driver)
    {
        DriverRequest = driver;
    }
}

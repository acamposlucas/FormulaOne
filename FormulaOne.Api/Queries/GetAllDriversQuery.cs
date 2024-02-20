using FormulaOne.DataService.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries;

public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
{

}

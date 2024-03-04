using FormulaOne.DataService.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries;

public sealed record GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
{

}

﻿using FormulaOne.DataService;
using MediatR;

namespace FormulaOne.Api.Queries;

public sealed record GetCircuitByIdQuery : IRequest<GetCircuitResponse>
{
    public Guid CircuitId { get; }

    public GetCircuitByIdQuery(Guid id)
    {
        CircuitId = id;
    }
}

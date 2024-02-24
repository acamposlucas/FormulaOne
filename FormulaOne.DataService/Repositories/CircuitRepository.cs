using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.DataService.Repositories;
using FormulaOne.Entities;
using FormulaOne.Entities.DbSet;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService;

public class CircuitRepository : GenericRepository<Circuit>, ICircuitRepository
{
    public CircuitRepository(AppDbContext context, ILogger logger) : base(logger, context)
    {
    }
}

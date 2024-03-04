using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.DataService.Repositories;
using FormulaOne.Entities;
using FormulaOne.Entities.DbSet;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace FormulaOne.DataService;

public class CircuitRepository : GenericRepository<Circuit>, ICircuitRepository
{
    public CircuitRepository(AppDbContext context, ILogger logger) : base(logger, context)
    {
    }

    public override async Task<bool> Update(Circuit circuit)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == circuit.Id);

            if (result is null)
            {
                return false;
            }

            result.UpdatedAt = DateTime.UtcNow;
            result.Location = circuit.Location;
            result.Status = circuit.Status;
            result.Country = circuit.Country;
            result.Name = circuit.Name;
            result.IsActive = circuit.IsActive;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, message: $"{typeof(CircuitRepository)} Update function error.");
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

            if (result is null)
            {
                return false;
            }

            result.Status = 0;
            result.UpdatedAt = DateTime.UtcNow;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, message: $"{typeof(CircuitRepository)} Delete function error.");
            throw;
        }
    }
}

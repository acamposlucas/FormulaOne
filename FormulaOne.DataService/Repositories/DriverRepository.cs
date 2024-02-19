using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class DriverRepository : GenericRepository<Driver>, IDriverRepository
{
    public DriverRepository(AppDbContext context, ILogger logger) : base(logger, context)
    {
    }

    public override async Task<IEnumerable<Driver>> GetAll()
    {
        try
        {
            return await _dbSet.Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.CreatedAt)
                .ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, message: $"{typeof(DriverRepository)} GetAll function error.");
            throw;
        }
    }

    public override async Task<bool> Delete(Guid id)
    {
        try
        {
            // Get entity
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
            _logger.LogError(e, message: $"{typeof(DriverRepository)} Delete function error.");
            throw;
        }
    }

    public override async Task<bool> Update(Driver driver)
    {
        try
        {
            // Get entity
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == driver.Id);

            if (result is null)
            {
                return false;
            }

            result.UpdatedAt = DateTime.UtcNow;
            result.DriverNumber = driver.DriverNumber;
            result.FirstName = driver.FirstName;
            result.LastName = driver.LastName;
            result.DateOfBirth = driver.DateOfBirth;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, message: $"{typeof(DriverRepository)} Update function error.");
            throw;
        }
    }
}

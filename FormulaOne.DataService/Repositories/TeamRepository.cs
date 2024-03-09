using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class TeamRepository : GenericRepository<Team>, ITeamRepository
{
    public TeamRepository(AppDbContext context, ILogger logger) : base(logger, context)
    {
    }

    public override async Task<IEnumerable<Team>> GetAll()
    {
        try
        {
            return await _dbSet
                .Where(x => x.Status == 1)
                .AsNoTracking()
                .AsSplitQuery()
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, message: $"{typeof(TeamRepository)} GetAll function error.");
            throw;
        }
    }
}

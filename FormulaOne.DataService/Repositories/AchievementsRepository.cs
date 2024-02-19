using FormulaOne.DataService.Data;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FormulaOne.DataService.Repositories;

public class AchievementsRepository : GenericRepository<Achievement>, IAchievementsRepository
{
    public AchievementsRepository(AppDbContext context, ILogger logger) : base(logger, context)
    {
    }

    public async Task<Achievement?> GetDriverAchievementAsync(Guid driverId)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.DriverId == driverId);
        }
        catch (Exception e)
        {
            _logger.LogError(e, message: $"{typeof(AchievementsRepository)} GetAchievementAchievementAsync function error.");
            throw;
        }
    }

    public override async Task<IEnumerable<Achievement>> GetAll()
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
            _logger.LogError(e, message: $"{typeof(AchievementsRepository)} GetAll function error.");
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
            _logger.LogError(e, message: $"{typeof(AchievementsRepository)} Delete function error.");
            throw;
        }
    }

    public override async Task<bool> Update(Achievement achievement)
    {
        try
        {
            // Get entity
            var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == achievement.Id);

            if (result is null)
            {
                return false;
            }

            result.UpdatedAt = DateTime.UtcNow;
            result.FastestLap = achievement.FastestLap;
            result.PolePosition = achievement.PolePosition;
            result.RaceWins = achievement.RaceWins;
            result.WorldChampionship = achievement.WorldChampionship;

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, message: $"{typeof(AchievementsRepository)} Update function error.");
            throw;
        }
    }
}

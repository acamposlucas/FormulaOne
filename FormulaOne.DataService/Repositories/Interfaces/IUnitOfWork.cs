﻿namespace FormulaOne.DataService.Repositories.Interfaces;

public interface IUnitOfWork
{
    IDriverRepository Drivers { get; }
    IAchievementsRepository Achievements { get; }
    ICircuitRepository Circuits { get; }
    ITeamRepository Teams { get; }

    Task<bool> CompleteAsync();
}

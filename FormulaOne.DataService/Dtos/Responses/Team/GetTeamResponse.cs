namespace FormulaOne.DataService.Dtos.Responses;

public class GetTeamResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string FullTeamName { get; set; } = string.Empty;
    public string Base { get; set; } = string.Empty;
    public string TeamChief { get; set; } = string.Empty;
    public string[] TechnicalChief { get; set; }
    public string Chassis { get; set; } = string.Empty;
    public string PowerUnit { get; set; } = string.Empty;
    public string FirstTeamEntry { get; set; } = string.Empty;
    public int WorldChampionships { get; set; }
    public int HighestRaceFinished { get; set; }
    public int TimesHighestRaceFinished { get; set; }
    public int PolePositions { get; set; }
    public int FastestLaps { get; set; }

    public GetTeamResponse()
    {
        TechnicalChief = [];
    }
}

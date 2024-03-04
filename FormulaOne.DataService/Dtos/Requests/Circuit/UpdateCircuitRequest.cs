﻿namespace FormulaOne.DataService;

public class UpdateCircuitRequest
{
    public Guid CircuitId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}

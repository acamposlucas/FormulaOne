namespace FormulaOne.Entities.DbSet;

public class Circuit : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public Circuit()
    {

    }
}

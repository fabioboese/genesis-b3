namespace B3.Cdb.Domain.Model;

public class Operation
{
    public string AssetName { get; set; } = "GenericCDB";
    public decimal Principal { get; set; }
    public int Months { get; set; }
}
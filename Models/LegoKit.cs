namespace legomylego.Models
{
  public class DTOLegoKit
  {
    public int Id { get; set; }
    public int LegoId { get; set; }
    public int KitId { get; set; }
  }
  public class LegoKitHelper : DTOLegoKit
  {
    public int X { get; set; }
    public int Y { get; set; }
  }
}
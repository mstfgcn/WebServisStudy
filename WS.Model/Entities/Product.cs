using Infrastructure.Model;

namespace WS.Model.Entities
{
  public class Product:IEntity
  {
    public int ProductId { get; set; }
    public string? ProductName { get; set; }
    public decimal? UnitPrice { get; set; }
    public short? UnitsInStock { get; set; }
    public int? CategoryId { get; set; }

     // NAVIGATION PROPERTY
    public Category? Category { get; set; }

  }
  
}

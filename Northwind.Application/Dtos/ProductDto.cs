namespace Northwind.Application.Dtos
{
	public class ProductDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string QuantityPerUnit { get; set; }
		public decimal UnitPrice { get; set; }
		public int UnitsInStock { get; set; }
		public int UnitsOnOrder { get; set; }
		public int ReorderLevel { get; set; }
		public bool Discontinued { get; set; }
		public DateTime AddedOn { get; set; }
	}
}

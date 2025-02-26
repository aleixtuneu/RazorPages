using System.ComponentModel.DataAnnotations;

namespace RazorPage.Model
{
	public class Product
	{
		[Required(ErrorMessage = "Aquest camp és obligatori")]
		[Range(1,99999999, ErrorMessage = "L'Id ha de tenir fins a 8 xifres i no pot ser 0")]
		public int Id { get; set; }
		[Required(ErrorMessage = "Aquest camp és obligatori")]
		public string? Name { get; set; }
		[Required(ErrorMessage = "Aquest camp és obligatori")]
		public int Amount { get; set; }
		[Required(ErrorMessage = "Aquest camp és obligatori")]
		public decimal Price { get; set; }
	}
}

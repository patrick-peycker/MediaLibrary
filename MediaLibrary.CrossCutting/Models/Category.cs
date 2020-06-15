using System.ComponentModel.DataAnnotations;

namespace MediaLibrary.CrossCutting.Models
{
	public class Category
	{
		[Key]
		[Required]
		public int Id { get; set; }

		[Required]
		[MaxLength(20)]
		public string Name { get; set; }
	}
}
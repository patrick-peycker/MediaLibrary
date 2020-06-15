using MediaLibrary.CrossCutting.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MediaLibrary.CrossCutting.Models
{
	public class Media
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		public string Name { get; set; }

		[Required]
		[DataType(DataType.Html)]
		public string Url { get; set; }

		[Required]
		[MaxLength(255)]
		public string Placement { get; set; }

		[Required]
		[EnumDataType(typeof(TypeObject))]
		public TypeObject Type { get; set; }

		[Required]
		public bool Done { get; set; }

		[Required]
		public int CategoryId { get; set; }
		
		[Required]
		[MaxLength(20)]
		public string CategoryName { get; set; }
	}
}
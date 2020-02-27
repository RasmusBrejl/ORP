using ORP.Models.Enums;

namespace ORP.Models
{
	public class ParcelCategory
	{
		public int ParcelCategoryId { get; set; }
		public ParcelType ParcelType { get; set; }
		public float PriceModifier { get; set; }
	}
}
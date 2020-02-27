using System.Collections.Generic;

namespace ORP.Models
{
	public class Parcel
	{
		public int ParcelId { get; set; }
		public float Weight { get; set; }
		public float Width { get; set; }
		public float Height { get; set; }
		public float Depth { get; set; }
		public List<ParcelCategory> ParcelCategories { get; set; }
	}
}
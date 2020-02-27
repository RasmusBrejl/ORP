using Newtonsoft.Json;

namespace ORP.Models
{
	public class RequestRouteObject
	{
		[JsonProperty("city_from")]
		public string CityFrom { get; set; }
		[JsonProperty("city_to")]
		public string CityTo { get; set; }
		[JsonProperty("weight")]
		public float Weight { get; set; }
		[JsonProperty("width")]
		public float Width { get; set; }
		[JsonProperty("height")]
		public float Height { get; set; }
		[JsonProperty("length")]
		public float Length { get; set; }
		[JsonProperty("cold")]
		public bool Cold { get; set; }
		[JsonProperty("fragile")]
		public bool Fragile { get; set; }
		[JsonProperty("animals")]
		public bool Animals { get; set; }
		[JsonProperty("weapons")]
		public bool Weapons { get; set; }
		[JsonProperty("recommended_delivery")]
		public bool RecordedDelivery { get; set; }
	}
}
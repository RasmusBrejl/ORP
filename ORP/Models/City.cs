using System.Collections.Generic;

namespace ORP.Models
{
	public class City
	{
		public int CityId { get; set; }
		public string Name { get; set; }
		public int NumberOfHits { get; set; }
		public List<Connection> Connections { get; set; }
	}
}
namespace ORP.Models
{
	public class GraphNode
	{
		public readonly City City;
		public ConnectionData ConnectionData { get; set; }
		public GraphNode CameFrom { get; set; }

		public GraphNode(City city, GraphNode cameFrom)
		{
			CameFrom = cameFrom;
			City = city;
			ConnectionData = new ConnectionData()
			{
				Duration = float.MaxValue,
				Price = float.MaxValue
			};
		}
	}
}
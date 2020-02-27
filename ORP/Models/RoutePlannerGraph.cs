using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using ORP.Business.Extensions;
using ORP.Business.Services;
using ORP.Models.Enums;

namespace ORP.Models
{
	public class RoutePlannerGraph
	{
		private readonly City _cityFrom;
		private readonly City _cityTo;
		private readonly RouteService _routeService;
		private readonly Parcel _parcel;

		private List<GraphNode> _visitedNodes = new List<GraphNode>();
		private List<GraphNode> _openNodes = new List<GraphNode>();

		public RoutePlannerGraph(City cityFrom, City cityTo, RouteService routeService, Parcel parcel)
		{
			_cityFrom = cityFrom;
			_cityTo = cityTo;
			_routeService = routeService;
			_parcel = parcel;
			var startNode = new GraphNode(cityFrom, null);
			startNode.ConnectionData = new ConnectionData();
			_openNodes.Add(startNode);
		}

		public List<Order> ComputeRoutes()
		{
			// TODO: Add functionality and return fastest + cheapest route
			var orders = new List<Order>();
			var fastestRoute = ComputeFastestRoute();
			var cheapestRoute = ComputeCheapestRoute();
			orders.Add(fastestRoute);

			if (fastestRoute != cheapestRoute)
				orders.Add(cheapestRoute);

			return orders;
		}

		private void EvaluateNode(GraphNode node)
		{
			if (_visitedNodes.Contains(node))
				return;

			if (_openNodes.Select(n => n.City).Contains(node.City))
			{
				if (node.ConnectionData.Price <)
			}
		}

		private Order ComputeFastestRoute()
		{
			while (_openNodes.Count > 0)
			{
				var currentNode = _openNodes.First(); // DUMMY
				var connections = _routeService.GetConnectionsForCity(currentNode.City);

				foreach (var connection in connections)
				{
					var otherCity = connection.CityOne == currentNode.City ? connection.CityTwo : connection.CityOne;
					if (!otherCity.Valid)
						continue;

					ConnectionData connectionData;
					switch (connection.ConnectionType)
					{
						case ConnectionType.Boat:
							connectionData = _routeService.GetConnectionDataBoat(_parcel);
							break;
						case ConnectionType.Car:
							connectionData = _routeService.GetConnectionDataCar(_parcel);
							break;
						default:
							connectionData = _routeService.GetConnectionData(_parcel, out string message);
							break;
					}

					var nextNodeCost = currentNode.ConnectionData.Add(connectionData);
					var node = _openNodes.FirstOrDefault(n => n.City.Equals(otherCity));
					if (node == null)
					{
						_openNodes.Add(new GraphNode(otherCity, currentNode));
					}

				}
			}


			return new Order();
		}

		private Order ComputeCheapestRoute()
		{
			return new Order();
		}
	}
}
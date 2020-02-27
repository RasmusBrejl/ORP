using System.Collections.Generic;
using System.Linq;
using ORP.Models;
using ORP.Models.Context;

namespace ORP.Business.Repositories
{
	public class ConnectionRepository
	{
		public Connection GetConnection(City cityFrom, City cityTo)
		{
            using (var context = new OrpContext())
            {
                return context.Connections.FirstOrDefault(x => x.CityOne == cityFrom && x.CityTwo == cityTo);
            }
		}

		public List<Connection> GetConnections(City city)
		{
			using (var context = new OrpContext())
			{
				return context.Connections.Where(c => c.CityOne == city || c.CityTwo == city).ToList();
			}
		}
	}
}
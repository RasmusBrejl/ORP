using System.Linq;
using ORP.Model;
using ORP.Models;

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
	}
}
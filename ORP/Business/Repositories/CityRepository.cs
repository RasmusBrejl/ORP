using System.Linq;
using ORP.Model;
using ORP.Models;

namespace ORP.Business.Repositories
{
	public class CityRepository
	{
		public City GetCity(string cityName)
		{
            using (var context = new OrpContext())
            {
                return context.Cities.FirstOrDefault(x => x.Name == cityName);
            }
		}
	}
}
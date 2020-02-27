using ORP.Models;

namespace ORP.Business.Extensions
{
	public static class ConnectionDataExtensions
	{
		public static ConnectionData Add(this ConnectionData original, ConnectionData other)
		{
			return new ConnectionData()
			{
				Duration = original.Duration + other.Duration,
				Price = original.Price + other.Price,
				Date = original.Date
			};
		}
	}
}
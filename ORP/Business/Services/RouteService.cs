using ORP.Business.Extensions;
using ORP.Business.Repositories;
using ORP.Models;
using ORP.Models.Enums;

namespace ORP.Business.Services
{
	public class RouteService
	{
		private readonly ConnectionRepository _connectionRepository;
		private readonly CityRepository _cityRepository;

		public RouteService(ConnectionRepository connectionRepository, CityRepository cityRepository)
		{
			_connectionRepository = connectionRepository;
			_cityRepository = cityRepository;
		}

		public Connection GetConnection(string cityFromName, string cityToName)
		{
			var cityFrom = _cityRepository.GetCity(cityFromName);
			var cityTo = _cityRepository.GetCity(cityToName);

			return _connectionRepository.GetConnection(cityFrom, cityTo);
		}

		public ConnectionData GetConnectionData(Parcel parcel, out string errorMessage)
		{
			var parcelSizeType = parcel.GetSizeType();

			if (parcelSizeType == ParcelSizeType.Invalid)
			{
				errorMessage = "Package dimensions not supported";
				return null;
			}

			var parcelWeightType = parcel.GetWeightType();

			if (parcelWeightType == ParcelWeightType.Invalid)
			{
				errorMessage = "Package weight not supported";
				return null;
			}

			float price;

			if (parcelSizeType == ParcelSizeType.Small)
			{
				if (parcelWeightType == ParcelWeightType.Light)
					price = Settings.PriceSmallLight;
				else if (parcelWeightType == ParcelWeightType.Medium)
					price = Settings.PriceSmallMedium;
				else
					price = Settings.PriceSmallHeavy;
			}
			else if (parcelSizeType == ParcelSizeType.Medium)
			{
				if (parcelWeightType == ParcelWeightType.Light)
					price = Settings.PriceMediumLight;
				else if (parcelWeightType == ParcelWeightType.Medium)
					price = Settings.PriceMediumMedium;
				else
					price = Settings.PriceMediumHeavy;
			}
			else
			{
				if (parcelWeightType == ParcelWeightType.Light)
					price = Settings.PriceLargeLight;
				else if (parcelWeightType == ParcelWeightType.Medium)
					price = Settings.PriceLargeMedium;
				else
					price = Settings.PriceLargeHeavy;
			}

			errorMessage = "";
			return new ConnectionData()
			{
				Duration = Settings.FlightDuration,
				Price = price
			};
		}
	}
}
using System.Linq;
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
			if (parcel.ParcelCategories != null)
			{
				var parcelTypes = parcel.ParcelCategories.Select(c => c.ParcelType).ToList();
				if (parcelTypes.Contains(ParcelType.LiveAnimals) ||
				                            parcelTypes.Contains(ParcelType.Recommended))
				{
					errorMessage = Settings.PackageInvalidTypeMessage;
					return null;
				}
			}


			var parcelSizeType = parcel.GetSizeType();

			if (parcelSizeType == ParcelSizeType.Invalid)
			{
				errorMessage = Settings.PackageInvalidSizeMessage;
				return null;
			}

			var parcelWeightType = parcel.GetWeightType();

			if (parcelWeightType == ParcelWeightType.Invalid)
			{
				errorMessage = Settings.PackageInvalidWeightMessage;
				return null;
			}

			float basePrice;

			if (parcelSizeType == ParcelSizeType.Small)
			{
				if (parcelWeightType == ParcelWeightType.Light)
					basePrice = Settings.PriceSmallLight;
				else if (parcelWeightType == ParcelWeightType.Medium)
					basePrice = Settings.PriceSmallMedium;
				else
					basePrice = Settings.PriceSmallHeavy;
			}
			else if (parcelSizeType == ParcelSizeType.Medium)
			{
				if (parcelWeightType == ParcelWeightType.Light)
					basePrice = Settings.PriceMediumLight;
				else if (parcelWeightType == ParcelWeightType.Medium)
					basePrice = Settings.PriceMediumMedium;
				else
					basePrice = Settings.PriceMediumHeavy;
			}
			else
			{
				if (parcelWeightType == ParcelWeightType.Light)
					basePrice = Settings.PriceLargeLight;
				else if (parcelWeightType == ParcelWeightType.Medium)
					basePrice = Settings.PriceLargeMedium;
				else
					basePrice = Settings.PriceLargeHeavy;
			}

			var totalPrice = basePrice;
			if (parcel.ParcelCategories != null)
			{
				foreach (var parcelCategory in parcel.ParcelCategories)
				{
					totalPrice += basePrice * parcelCategory.PriceModifier;
				}
			}
			
			errorMessage = string.Empty;
			return new ConnectionData()
			{
				Duration = Settings.FlightDuration,
				Price = totalPrice
			};
		}
	}
}
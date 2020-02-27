using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORP.Business;
using ORP.Business.Repositories;
using ORP.Business.Services;
using ORP.Models;
using ORP.Models.Enums;

namespace ORP.Tests.Business.Services
{
	[TestClass]
	public class RouteServiceTest
	{
		[TestMethod]
		public void GetConnectionData_GivenParcelOfInvalidType_ReturnsNull()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var parcel = new Parcel()
			{
				ParcelCategories = new List<ParcelCategory>()
				{
					new ParcelCategory()
					{
						ParcelType = ParcelType.LiveAnimals
					}
				}
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.IsNull(result);
			Assert.AreEqual(Settings.PackageInvalidTypeMessage, errorMessage);
		}

		[TestMethod]
		public void GetConnectionData_GivenSmallLightParcel_ReturnsPriceSmallLight()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.SmallWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.LightWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceSmallLight, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenSmallMediumParcel_ReturnsPriceSmallMedium()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.SmallWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.MediumWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceSmallMedium, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenSmallHeavyParcel_ReturnsPriceSmallHeavy()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.SmallWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.HeavyWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceSmallHeavy, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenMediumLightParcel_ReturnsPriceMediumLight()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.MediumWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.LightWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceMediumLight, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenMediumMediumParcel_ReturnsPriceMediumMedium()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.MediumWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.MediumWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceMediumMedium, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenMediumHeavyParcel_ReturnsPriceMediumHeavy()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.MediumWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.HeavyWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceMediumHeavy, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenLargeLightParcel_ReturnsPriceLargeLight()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.LargeWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.LightWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceLargeLight, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenLargeMediumParcel_ReturnsPriceLargeMedium()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.LargeWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.MediumWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceLargeMedium, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_GivenLargeHeavyParcel_ReturnsPriceLargeHeavy()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var width = Settings.LargeWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.HeavyWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);

			// Assert
			Assert.AreEqual(Settings.PriceLargeHeavy, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}

		[TestMethod]
		public void GetConnectionData_ParcelWithCategoryModifier_ReturnsModifiedPrice()
		{
			// Arrange
			var routeService = new RouteService(new ConnectionRepository(), new CityRepository());
			var parcelCategory = new ParcelCategory()
			{
				ParcelType = ParcelType.Weapons,
				PriceModifier = 1
			};

			var width = Settings.SmallWidth;
			var height = Settings.SmallHeight;
			var length = Settings.SmallLength;
			var weight = Settings.LightWeight;
			var parcel = new Parcel()
			{
				Width = width,
				Height = height,
				Length = length,
				Weight = weight,
				ParcelCategories = new List<ParcelCategory>()
				{
					parcelCategory
				}
			};

			// Act
			var result = routeService.GetConnectionData(parcel, out string errorMessage);
			var totalModifier = 2;

			// Assert
			Assert.AreEqual(Settings.PriceSmallLight * totalModifier, result.Price);
			Assert.IsTrue(string.IsNullOrWhiteSpace(errorMessage));
		}
	}
}

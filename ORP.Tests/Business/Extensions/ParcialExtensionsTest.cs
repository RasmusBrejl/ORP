using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ORP.Business.Extensions;
using ORP.Models;
using ORP.Models.Enums;

namespace ORP.Tests.Business.Extensions
{
	[TestClass]
	public class ParcialExtensionsTest
	{
		[TestMethod]
		public void GetWeightType_GivenTooHeavyPackage_ReturnsInvalidParcelType()
		{
			// Arrange
			var parcel = new Parcel()
			{
				Weight = 25f
			};

			// Act
			var actual = parcel.GetWeightType();

			// Assert
			Assert.AreEqual(ParcelWeightType.Invalid, actual);
		}
	}
}

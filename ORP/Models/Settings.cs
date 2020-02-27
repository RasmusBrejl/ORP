using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORP.Models
{
    public static class Settings
    {
        public static int[] MaxSizeSmall = { 25, 25, 25 };

        public static int[] MaxSizeMedium = { 40, 40, 40 };

        public static int[] MaxSizeLarge = { 200, 200, 200 };

        public static int[] MaxWeight = { 1, 5, 20 };

        public static float PriceSmallLight = 40.0f;

        public static float PriceSmallMedium = 60.0f;

        public static float PriceSmallHeavy = 80.0f;

        public static float PriceMediumLight = 48.0f;

        public static float PriceMediumMedium = 68.0f;

        public static float PriceMediumHeavy = 88.0f;

        public static float PriceLargeLight = 80.0f;

        public static float PriceLargeMedium = 100.0f;

        public static float PriceLargeHeavy = 120.0f;
    }
}
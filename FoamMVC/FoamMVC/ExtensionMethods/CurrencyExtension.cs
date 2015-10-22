using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace FoamMVC.ExtensionMethods
{
    public static class CurrencyExtension
    {
        public static string AsCurrency(this double value)
        {
            return value.AsCurrency(CultureInfo.CurrentCulture);
        }

        public static string AsCurrency(this double value, CultureInfo culture)
        {
            double result = value/100;
            return result.ToString("C", culture);
        }

        public static double CurrencyAsDouble(this string value)
        {
            return Convert.ToDouble(value.Replace("$", String.Empty))*100;
        }
    }
}
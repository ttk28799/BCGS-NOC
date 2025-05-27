using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Globalization;

namespace GiaoBanTrucNOC.SaveLoad
{
    public class GiaTriConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.Equals(text, "Unplugged", StringComparison.OrdinalIgnoreCase))
            {
                // Return a special value or handle as needed
                return double.NaN; // or any sentinel value
            }

            if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }

            return double.NaN; // or handle invalid values as needed
        }
    }
}
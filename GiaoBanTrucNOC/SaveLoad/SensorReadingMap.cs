using CsvHelper.Configuration;

namespace GiaoBanTrucNOC.SaveLoad
{
    public class SensorReadingMap : ClassMap<SensorReading>
    {
        public SensorReadingMap()
        {
            Map(m => m.Loai).Name("Loai (Sensor)");
            Map(m => m.TenThietBi).Name("Ten Thiet bi (Sensor)");
            Map(m => m.GiaTri).Name("Last Known Value").TypeConverter<GiaTriConverter>();
        }
    }
}
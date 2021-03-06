using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DriverDatabase
{
	public class Driver
	{
		public String Name { get; set; }
		public String FavColor { get; set; }
		public List<Car> Cars;

		public static bool Compare(Driver driver1, Driver driver2)
        {
			if (driver1.Name == driver2.Name && driver1.FavColor == driver2.FavColor)
				return true;
			return false;
        }

		public Driver() {
			Cars = new List<Car>();
		}

		public override String ToString()
		{
			return Name;
		}
	}

	public class Car
    {
		public String Name { get; set; }
		public String Brand { get; set; }
		[XmlIgnore]
		public List<Driver> Drivers = new List<Driver>();

		public static bool Compare(Car car1, Car car2)
        {
			if (car1.Name == car2.Name && car1.Brand == car2.Brand)
				return true;
			return false;
        }

		public string DriversString
        {
			get
            {
				string result = "";
				foreach (Driver driver in Drivers)
				{
					result += driver.Name + ", ";
				}

				return result.Substring(0, result.Length - 2);
			}
        }

        public override string ToString()
        {
			return Name + " (" + Brand + ")" + " driven by " + DriversString;
        }
    }
}

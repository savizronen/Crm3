using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Crm3
{
    public class CarsDB
    {
        private Dictionary<string, Car> cars = new Dictionary<string, Car>();

        public void AddCar(string key, Car car)
        {
            cars.Add(key, car);
        }

        public void RemoveCar(string key)
        {
            cars.Remove(key);
        }

        public Car GetCar(string key)
        {
            if (cars.TryGetValue(key, out Car car))
            {
                return car;
            }
            else
            {
                return null;
            }
        }

        public void UpdateCar(string key, Car car)
        {
            cars[key] = car;
        }
    }

}
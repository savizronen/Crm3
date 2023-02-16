using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm3
{
    public class Car
    {
        public string OwnerId { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int YearOfManufacture { get; set; }
        public string LicensePlate { get; set; }
        public string OwnerFirstName { get; set; }
        public string OwnerLastName { get; set; }
        public Car(string manufacturer, string model, int yearOfManufacture, string licensePlate, string ownerFirstName, string ownerLastName, string ownerId)
        {
            Manufacturer = manufacturer;
            Model = model;
            YearOfManufacture = yearOfManufacture;
            LicensePlate = licensePlate;
            OwnerFirstName = ownerFirstName;
            OwnerLastName = ownerLastName;
            OwnerId = ownerId;
        }

        public override string ToString()
        {
            return $"Manufacturer: {Manufacturer}, Model: {Model}, Year of Manufacture: {YearOfManufacture}, License Plate: {LicensePlate}, Owner's Name: {OwnerFirstName} {OwnerLastName},Owner's Id {OwnerId}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Test
    {
        // TODO: delete this class before submission
        public static void Main()
        {
            string i_ModelName = "Mazda";
            string i_LicenseNumber = "123456";

            Wheel MazdaWheel = new Wheel("Michlen", 12);
            Wheel[] i_Wheel = new Wheel[4] { MazdaWheel, MazdaWheel, MazdaWheel, MazdaWheel };
            eFuelType i_FuelType = eFuelType.Octan95;
            float i_MaxFuelAmount = 120.0f;
            
            FuelBasedVehicle Vehicle = 
                new FuelBasedVehicle(i_ModelName, i_LicenseNumber, i_Wheel, i_FuelType, i_MaxFuelAmount);
            Car Mazda = new Car(Vehicle, eCarColor.Black, eNumberOfDoors.Four);

            Mazda.CurrentBatteryTime = 100;
            Mazda.FuelGas(15, eFuelType.Octan95);
        }
    }
}

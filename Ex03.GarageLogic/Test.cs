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
            FuelBasedVehicle vehicle = 
                new FuelBasedVehicle(i_ModelName, i_LicenseNumber, i_Wheel, i_FuelType, i_MaxFuelAmount);
            Car Mazda = new Car(vehicle, eCarColor.Black, eNumberOfDoors.Four);



            string i_ModelName1 = "Mazda";
            string i_LicenseNumber1 = "1234567";
            Wheel MazdaWheel1 = new Wheel("Michlen", 12);
            Wheel[] i_Wheel1 = new Wheel[4] { MazdaWheel1, MazdaWheel1, MazdaWheel1, MazdaWheel1 };
            eFuelType i_FuelType1 = eFuelType.Octan95;
            float i_MaxFuelAmount1 = 120.0f;
            FuelBasedVehicle Vehicle1 =
                new FuelBasedVehicle(i_ModelName1, i_LicenseNumber1, i_Wheel1, i_FuelType1, i_MaxFuelAmount1);
            Car Mazda1 = new Car(Vehicle1, eCarColor.Red, eNumberOfDoors.Four);


            Garage g= new Garage();

            g.AddNewVehicle(Mazda, "Yarden", "05400000");
            g.AddNewVehicle(Mazda1, "Galil", "05400002");

            g.GetAllVehicleLicensePlatesByFilter();
        }
    }
}

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
            //string i_ModelName = "Mazda";
            //string i_LicenseNumber = "123456";
            //Wheel MazdaWheel = new Wheel("Michlen", 12);
            //Wheel[] i_Wheel = new Wheel[4] { MazdaWheel, MazdaWheel, MazdaWheel, MazdaWheel };
            //eFuelType i_FuelType = eFuelType.Octan95;
            //float i_MaxFuelAmount = 120.0f;
            //FuelBasedVehicle vehicle =
            //    new FuelBasedVehicle(i_ModelName, i_LicenseNumber, i_Wheel, i_FuelType, i_MaxFuelAmount);
            //Car Mazda = new Car(vehicle, eCarColor.Black, eNumberOfDoors.Four);

            //string i_ModelName1 = "Mazda";
            //string i_LicenseNumber1 = "1234567";
            //Wheel MazdaWheel1 = new Wheel("Michlen", 12);
            //Wheel[] i_Wheel1 = new Wheel[4] { MazdaWheel1, MazdaWheel1, MazdaWheel1, MazdaWheel1 };
            //eFuelType i_FuelType1 = eFuelType.Octan95;
            //float i_MaxFuelAmount1 = 120.0f;
            //FuelBasedVehicle Vehicle1 =
            //    new FuelBasedVehicle(i_ModelName1, i_LicenseNumber1, i_Wheel1, i_FuelType1, i_MaxFuelAmount1);
            //Car Mazda1 = new Car(Vehicle1, eCarColor.Red, eNumberOfDoors.Four);
            //g.AddNewVehicle(Mazda, "Yarden", "05400000");
            //g.AddNewVehicle(Mazda1, "Galil", "05400002");

            //g.GetAllVehicleLicensePlatesByFilter();


            Wheel[] wheels1 = GarageMain.CreateWheels("manufacturer", 33, 2);
            FuelBasedVehicle fuel1 = GarageMain.CreateFuelBasedVehicle("model", "License", wheels1, eFuelType.Octan95, 8);
            Motorcycle motor_fuel1 = GarageMain.CreateMotorcycle(fuel1, eLicenseType.A, 1000);

            Wheel[] wheels2 = GarageMain.CreateWheels("manufacturer", 33, 2);
            ElectricVehicle electric2 = GarageMain.CreateElectricVehicle("Model_name", "LicenseNum", wheels2, 1.4f);
            Motorcycle motor_electric2 = GarageMain.CreateMotorcycle(electric2, eLicenseType.A1, 10000);

            Wheel[] wheels3 = GarageMain.CreateWheels("manufacturer", 31, 4);
            FuelBasedVehicle fuel3 = GarageMain.CreateFuelBasedVehicle("model", "License", wheels3, eFuelType.Octan96, 55);
            Car car_fuel3 = GarageMain.CreateCar(fuel3, eCarColor.Black, eNumberOfDoors.Four);

            Wheel[] wheels4 = GarageMain.CreateWheels("manufacturer", 31, 4);
            ElectricVehicle electric4 = GarageMain.CreateElectricVehicle("Model_name", "LicenseNum", wheels4, 1.8f);
            Car car_electric4 = GarageMain.CreateCar(electric4, eCarColor.Black, eNumberOfDoors.Four);

            Wheel[] wheels5 = GarageMain.CreateWheels("manufacturer", 26, 12);
            FuelBasedVehicle fuel5 = GarageMain.CreateFuelBasedVehicle("model", "License", wheels5, eFuelType.Soler, 110);
            Truck truck_fuel5 = GarageMain.CreateTruck(fuel5, true, 40);

            Console.WriteLine("Good Creation. press ENTER to exit :)");
            Garage g = new Garage();



            Console.ReadLine();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using Ex03.GarageLogic.Enums;
using GarageMain = Ex03.GarageLogic;

namespace Ex03.ConsoleUI.Windows
{
    internal class InsertWindow
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private string m_ModelName;
        private string m_LicenseNumber;
        private string m_WheelManufacturer;
        private float m_WheelMaxAirPressure;
        private eVehicleType m_VehicleType;
        private eElectricVehicleOptions m_ElectricVehicleOptions;
        private eFuelBasedOptions m_FuelBasedVehicleOptions;
        private eCarColor m_CarColor;
        private eNumberOfDoors m_CarNumberOfDoors;
        private eLicenseType m_MotorCycleLicenseType;
        private eFuelType m_FuelType;
        private bool m_IsContainsDangerousMaterials;
        private int m_MotorcycleEngineVolume;
        private int m_TruckCargoVolume;
        private float m_MaxBatteryAmount;
        private Vehicle m_Vehicle;
        private Wheel[] m_Wheels;
        private float m_MaxFuelAmount;
        private bool m_IsInputValid = false;

        internal void MainWindow()
        {
            // Get Owner name
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getOwnerName();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get Oner phone number
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getOwnerPhoneNumber();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }
            // Get Model Name
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                getModelName();
            }

            // Get license number
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getLicenseNumber();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // get Wheel Manufacturer
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                m_IsInputValid = false;
                getWheelManufacturer();
            }

            // Get max Air pressure
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getWheelMaxAirPressure();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get vehicle type
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getVheicleType();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Split to each  vehcile type
            switch (m_VehicleType)
            {
                case eVehicleType.Electric:
                    insertElectricWindow();
                    break;
                case eVehicleType.FuelBased:
                    insertFuelBasedWindow();
                    break;
                default:
                    break;
            }
        }

        private void getOwnerPhoneNumber()
        {
            Console.Write("Please insert owner phone number (and then press enter): ");
            m_OwnerPhoneNumber = Console.ReadLine();
            foreach(char digit in m_OwnerPhoneNumber)
            {
                if (!char.IsDigit(digit))
                {
                    throw new FormatException($"'{m_OwnerPhoneNumber}' is not a valid input");
                }
            }
            m_IsInputValid = true;
        }

        private void getOwnerName()
        {
            Console.Write("Please insert owner name (and then press enter): ");
            m_OwnerName = Console.ReadLine();
            foreach(char letter in m_OwnerName)
            {
                if (!char.IsLetter(letter))
                {
                    throw new FormatException($"'{m_OwnerName}' is not a valid input!");
                }
            }
            m_IsInputValid = true;
        }

        private void insertFuelBasedWindow()
        {
            // Get Fuel Based Vehicle Fuel Type
            Console.Clear();
            Console.WriteLine("You chose to insert a new fuel based Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getFuelBasedVehicleClass();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            Console.Clear();
            Console.WriteLine("You chose to insert a new fuel based Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getFuelType();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get max fuel amount
            Console.Clear();
            Console.WriteLine("You chose to insert a new fuel based Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getFuelMaxAmount();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }
            
            switch (m_FuelBasedVehicleOptions)
            {
                case eFuelBasedOptions.Car:
                    insertCarWindow();
                    break;
                case eFuelBasedOptions.Motorcycle:
                    insertMotorcycleWindow();
                    break;
                case eFuelBasedOptions.Truck:
                    insertTruckWindow();
                    break;
                default:
                    break;
            }
        }

        private void getFuelMaxAmount()
        {
            Console.Write("Please insert the maximum fuel amount (and then press enter): ");
            string maxFuelAmount = Console.ReadLine();

            try
            {
                m_MaxFuelAmount = float.Parse(maxFuelAmount);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{m_MaxFuelAmount}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getFuelType()
        {
            StringBuilder fuelType = new StringBuilder();
            fuelType.AppendLine("Please choose the fuel type:");
            fuelType.AppendLine("Press 1 for Soler");
            fuelType.AppendLine("Press 2 for Octan95");
            fuelType.AppendLine("Press 3 for Octan96");
            fuelType.AppendLine("Press 4 for Octan98");
            fuelType.AppendLine("(and then press enter)");
            Console.WriteLine($"{fuelType}: ");
            string fuelTypeStr = Console.ReadLine();

            try
            {
                m_FuelType = (eFuelType)Enum.Parse(typeof(eFuelType), fuelTypeStr);
                if (!Enum.IsDefined(typeof(eFuelType), m_FuelType))
                {
                    throw new FormatException($"'{fuelTypeStr}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{fuelTypeStr}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void insertElectricWindow()
        {
            // Get Electric Based Vehicle Class
            Console.Clear();
            Console.WriteLine("You chose to insert a new electric based Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getElectricBasedVehicleClass();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getMaxBatteryAmount();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            switch (m_ElectricVehicleOptions)
            {
                case eElectricVehicleOptions.Car:
                    insertCarWindow();
                    break;
                case eElectricVehicleOptions.Motorcycle:
                    insertMotorcycleWindow();
                    break;
                default:
                    break;
            }
        }

        private void getMaxBatteryAmount()
        {
            Console.Write("Please insert Max battery time (and then press enter): ");
            string maxBatteryAmount = Console.ReadLine();

            try
            {
                m_MaxBatteryAmount = float.Parse(maxBatteryAmount);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{maxBatteryAmount}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void insertTruckWindow()
        {
            // Get truck Contain Dangerous Materials status
            Console.Clear();
            Console.WriteLine("You chose to insert a new Truck.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getTruckContainDangerousMaterialsStatus();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get motorcycle cargoVolume volume
            Console.Clear();
            Console.WriteLine("You chose to insert a new Truck.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getTruckCargoVolume();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            createNewTruck();
        }

        private void createNewTruck()
        {
            Wheel truckWheel = new Wheel(m_WheelManufacturer, m_WheelMaxAirPressure);

            m_Wheels = new Wheel[12];
            for (int i = 0; i < 12; i++)
            {
                m_Wheels[i] = truckWheel;
            }

            FuelBasedVehicle fuelBasedVehicle = new FuelBasedVehicle(m_ModelName, m_LicenseNumber, m_Wheels, m_FuelType, m_MaxFuelAmount);
            Truck newTruck = new Truck(fuelBasedVehicle, m_IsContainsDangerousMaterials, m_TruckCargoVolume);
            Garage.AddNewVehicle(newTruck, m_OwnerName, m_OwnerPhoneNumber);
        }

        private void insertMotorcycleWindow()
        {
            // Get motorcycle license type
            Console.Clear();
            Console.WriteLine("You chose to insert a new Motorcycle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getMotorcycleLicenseType();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get motorcycle engine volume
            Console.Clear();
            Console.WriteLine("You chose to insert a new Motorcycle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getMotorCycleEngineVolume();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            createNewMotorcycle();
        }

        private void createNewMotorcycle()
        {
            Wheel motorcycleWheel = new Wheel(m_WheelManufacturer, m_WheelMaxAirPressure);

            m_Wheels = new Wheel[2];
            for (int i = 0; i < 2; i++)
            {
                m_Wheels[i] = motorcycleWheel;
            }

            if (m_VehicleType == eVehicleType.FuelBased)
            {
                FuelBasedVehicle fuelBasedVehicle =
                    new FuelBasedVehicle(m_ModelName, m_LicenseNumber, m_Wheels, m_FuelType, m_MaxFuelAmount);
                Motorcycle newMotorcycle = new Motorcycle(fuelBasedVehicle, m_MotorCycleLicenseType, m_MotorcycleEngineVolume);
                Garage.AddNewVehicle(newMotorcycle, m_OwnerName, m_OwnerPhoneNumber);
            }

            if (m_VehicleType == eVehicleType.Electric)
            {
                ElectricVehicle electricVehicle =
                    new ElectricVehicle(m_ModelName, m_LicenseNumber, m_Wheels, m_MaxBatteryAmount);
                Motorcycle newMotorcycle = new Motorcycle(electricVehicle, m_MotorCycleLicenseType, m_MotorcycleEngineVolume);
                Garage.AddNewVehicle(newMotorcycle, m_OwnerName, m_OwnerPhoneNumber);
            }
        }

        private void insertCarWindow()
        {
            // Get car color
            Console.Clear();
            Console.WriteLine("You chose to insert a Car.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getCarColor();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get car number od doors
            Console.Clear();
            Console.WriteLine("You chose to insert a new Car.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getCarNumberOfDoors();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            createNewCar();
        }

        private void createNewCar()
        {
            Wheel carWheel = new Wheel(m_WheelManufacturer, m_WheelMaxAirPressure);

            m_Wheels = new Wheel[4];
            for (int i = 0; i < 4; i++)
            {
                m_Wheels[i] = carWheel;
            }

            if (m_VehicleType == eVehicleType.FuelBased)
            {
                FuelBasedVehicle fuelBasedVehicle =
                    new FuelBasedVehicle(m_ModelName, m_LicenseNumber, m_Wheels, m_FuelType, m_MaxFuelAmount);
                Car newCar = new Car(fuelBasedVehicle, m_CarColor, m_CarNumberOfDoors);
                Garage.AddNewVehicle(newCar, m_OwnerName, m_OwnerPhoneNumber);
            }

            if (m_VehicleType == eVehicleType.Electric)
            {
                ElectricVehicle electricVehicle =
                    new ElectricVehicle(m_ModelName, m_LicenseNumber, m_Wheels, m_MaxBatteryAmount);
                Car newCar = new Car(electricVehicle, m_CarColor, m_CarNumberOfDoors);
                Garage.AddNewVehicle(newCar, m_OwnerName, m_OwnerPhoneNumber);
            }
        }

        private void getTruckCargoVolume()
        {
            Console.Write("Please insert truck cargo volume (and then press enter): ");
            string truckCargoVolume = Console.ReadLine();

            try
            {
                m_TruckCargoVolume = int.Parse(truckCargoVolume);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{truckCargoVolume}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getTruckContainDangerousMaterialsStatus()
        {
            Console.Write("Please insert if truck contains dangerous materials <True, False>(and then press enter): ");
            string isContainsDangerousMaterials = Console.ReadLine();

            try
            {
                m_IsContainsDangerousMaterials = bool.Parse(isContainsDangerousMaterials);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{isContainsDangerousMaterials}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getMotorCycleEngineVolume()
        {
            Console.Write("Please insert Motorcycle engine volume (and then press enter): ");
            string motorcycleEngineVolume = Console.ReadLine();

            try
            {
                m_MotorcycleEngineVolume = int.Parse(motorcycleEngineVolume);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{motorcycleEngineVolume}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getMotorcycleLicenseType()
        {
            StringBuilder licenseType = new StringBuilder();
            licenseType.AppendLine("Please choose the Motorcycle license type");
            licenseType.AppendLine("Press 1 for A");
            licenseType.AppendLine("Press 2 for A1");
            licenseType.AppendLine("Press 3 for A2");
            licenseType.AppendLine("Press 4 for B");
            licenseType.AppendLine("(and then press enter)");
            Console.WriteLine($"{licenseType}: ");
            string motorCycleLicenseType = Console.ReadLine();

            try
            {
                m_MotorCycleLicenseType = (eLicenseType) Enum.Parse(typeof(eLicenseType), motorCycleLicenseType);
                if (!Enum.IsDefined(typeof(eLicenseType), m_MotorCycleLicenseType))
                {
                    throw new FormatException($"'{motorCycleLicenseType}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{motorCycleLicenseType}' is not a valid input!");
            }

            m_IsInputValid = true;
        }
        
        private void getCarNumberOfDoors()
        {
            Console.Write("Please insert the number of Car doors <2-5> (and then press enter): ");
            string carNumberOfDoors = Console.ReadLine();

            try
            {
                m_CarNumberOfDoors = (eNumberOfDoors) Enum.Parse(typeof(eNumberOfDoors), carNumberOfDoors);
                if (!Enum.IsDefined(typeof(eNumberOfDoors), m_CarNumberOfDoors))
                {
                    throw new FormatException($"'{carNumberOfDoors}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{carNumberOfDoors}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getCarColor()
        {
            StringBuilder carColorNumber = new StringBuilder();
            carColorNumber.AppendLine("Please choose the Car color");
            carColorNumber.AppendLine("Press 1 for Red");
            carColorNumber.AppendLine("Press 2 for Blue");
            carColorNumber.AppendLine("Press 3 for Black");
            carColorNumber.AppendLine("Press 4 for Gray");
            carColorNumber.AppendLine("(and then press enter)");
            Console.WriteLine($"{carColorNumber}: ");
            string carColor = Console.ReadLine();

            try
            {
                m_CarColor = (eCarColor) Enum.Parse(typeof(eCarColor), carColor);
                if (!Enum.IsDefined(typeof(eCarColor), m_CarColor))
                {
                    throw new FormatException($"'{carColor}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{carColor}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getFuelBasedVehicleClass()
        {
            Console.Write("Please insert 1 for Car OR 2 for Truck OR 3 for a Motorcycle");
            string vheicleClass = Console.ReadLine();

            try
            {
                m_FuelBasedVehicleOptions = (eFuelBasedOptions) Enum.Parse(typeof(eFuelBasedOptions), vheicleClass);
                if (!Enum.IsDefined(typeof(eFuelBasedOptions), m_FuelBasedVehicleOptions))
                {
                    throw new FormatException($"'{vheicleClass}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{vheicleClass}' is not a valid input!");
            }

            m_IsInputValid = true;
        }
        
        private void getElectricBasedVehicleClass()
        {
            Console.Write("Please insert 1 for Car OR 2 for Motorcycle: ");
            string vheicleClass = Console.ReadLine();

            try
            {
                m_ElectricVehicleOptions = (eElectricVehicleOptions) Enum.Parse(typeof(eElectricVehicleOptions), vheicleClass);
                if (!Enum.IsDefined(typeof(eElectricVehicleOptions), m_ElectricVehicleOptions))
                {
                    throw new FormatException($"'{vheicleClass}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{vheicleClass}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getVheicleType()
        {
            Console.Write("Please insert 1 for electric vehicle OR 2 for fuel based vehicle: ");
            string vheicleType = Console.ReadLine();

            try
            {
                m_VehicleType = (eVehicleType) Enum.Parse(typeof(eVehicleType), vheicleType);
                if (!Enum.IsDefined(typeof(eVehicleType), m_VehicleType))
                {
                    throw new FormatException($"'{vheicleType}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{vheicleType}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getWheelMaxAirPressure()
        {
            Console.Write("Please insert vehicle wheel manufacturer max air pressure (and then press enter): ");
            string wheelMaxAirPressure = Console.ReadLine();

            try
            {
                m_WheelMaxAirPressure = float.Parse(wheelMaxAirPressure);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{wheelMaxAirPressure}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getWheelManufacturer()
        {
            Console.Write("Please insert vehicle wheel manufacturer (and then press enter): ");
            m_WheelManufacturer = Console.ReadLine();
            m_IsInputValid = true;
        }

        private void getLicenseNumber()
        {
            Console.Write("Please insert vehicle license number (and then press enter): ");
            m_LicenseNumber = Console.ReadLine();
            try
            {
                GarageConsoleUi.CheckIfLicensePlateIsValid(m_LicenseNumber);
                m_IsInputValid = true;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }

        private void getModelName()
        {
            Console.Write("Please insert vehicle model name (and then press enter): ");
            m_ModelName = Console.ReadLine();
            m_IsInputValid = true;
        }
    }
}
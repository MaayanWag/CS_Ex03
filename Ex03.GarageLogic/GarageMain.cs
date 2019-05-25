using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageMain
    {
        #region Properties
        private static Garage m_Garage;
        private const int k_ElectricCarValidNumberOfWheels = 4;
        private const float k_ElectricCarValidMaxAirPressure = 31.0f;
        private const float k_ElectricCarValidMaxBatteryTime = 1.8f;
        private const int k_FuelBasedCarValidNumberOfWheels = 4;
        private const float k_FuelBasedCarValidMaxAirPressure = 31.0f;
        private const eFuelType k_FuelBasedCarValidFuelType = eFuelType.Octan96;
        private const float k_FuelBasedCarValidMaxFuelAmount = 55.0f;
        private const float k_ElectricMotorcycleValidMaxAirPressure = 33.0f;
        private const int k_ElectricMotorcycleValidNumberOfWheels = 2;
        private const float k_ElectricMotorcycleValidMaxBatteryTime = 1.4f;
        private const int k_FuelBasedMotorcycleValidNumberOfWheels = 2;
        private const float k_FuelBasedMotorcycleValidMaxAirPressure = 33.0f;
        private const eFuelType k_FuelBasedMotorcycleValidFuelType = eFuelType.Octan95;
        private const float k_FuelBasedMotorcycleValidMaxFuelAmount = 8.0f;
        private const int k_FuelBasedTruckValidNumberOfWheels = 12;
        private const float k_FuelBasedTruckValidMaxAirPressure = 26.0f;
        private const eFuelType k_FuelBasedTruckValidFuelType = eFuelType.Soler;
        private const float k_FuelBasedTruckValidMaxFuelAmount = 110.0f;

        #endregion

        #region Run

        public static void RunGarageSystem()
        {
            m_Garage = new Garage();
        }

        #endregion

        #region Create veheicle

        public static FuelBasedVehicle CreateFuelBasedVehicle(string i_ModelName, string i_LicenseNumber, Wheel[] i_Wheels,
            eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            FuelBasedVehicle fuelVehicle = new FuelBasedVehicle(i_ModelName, i_LicenseNumber, i_Wheels, i_FuelType, i_MaxFuelAmount);

            return fuelVehicle;
        }

        public static ElectricVehicle CreateElectricVehicle(string i_ModelName, string i_LicenseNumber, Wheel[] i_Wheels,
            float i_MaxBatteryTimeAmount)
        {
            ElectricVehicle electricVehicle = new ElectricVehicle(i_ModelName, i_LicenseNumber, i_Wheels, i_MaxBatteryTimeAmount);

            return electricVehicle;
        }

        public static Car CreateCar(Vehicle i_VehicleType, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
        {
            Car newCar = null;
            ElectricVehicle electricVehicle = i_VehicleType as ElectricVehicle;
            FuelBasedVehicle fuelBasedVehicle = i_VehicleType as FuelBasedVehicle;

            if (electricVehicle != null)
            {
                electricCarParamsAreValid(electricVehicle.Wheels, electricVehicle.MaxBatteryTime);
            }
            else if (fuelBasedVehicle != null)
            {
                fuelBasedCarParamsAreValid(fuelBasedVehicle.Wheels, fuelBasedVehicle.FuelType, fuelBasedVehicle.MaxFuelAmount);
            }
            else
            {
                throw new ArgumentException("Not a valid Vehicle! Should be fuel based or electric based only.");
            }

            newCar = new Car(i_VehicleType, i_CarColor, i_NumberOfDoors);

            return newCar;
        }

        public static Motorcycle CreateMotorcycle(Vehicle i_VehicleType, eLicenseType i_LicenseType, int i_EngineVolume)
        {
            Motorcycle newMotorcycle = null;
            ElectricVehicle electricVehicle = i_VehicleType as ElectricVehicle;
            FuelBasedVehicle fuelBasedVehicle = i_VehicleType as FuelBasedVehicle;

            if (electricVehicle != null)
            {
                electricMotorcycleParamsAreValid(electricVehicle.Wheels, electricVehicle.MaxBatteryTime);
            }
            else if (fuelBasedVehicle != null)
            {
                fuelBasedMotorcycleParamsAreValid(fuelBasedVehicle.Wheels, fuelBasedVehicle.FuelType, fuelBasedVehicle.MaxFuelAmount);
            }
            else
            {
                // TODO: change Exception
                throw new Exception("Not a valid Vehicle!");
            }

            newMotorcycle = new Motorcycle(i_VehicleType, i_LicenseType, i_EngineVolume);

            return newMotorcycle;
        }

        public static Truck CreateTruck(FuelBasedVehicle i_FuelBasedTruck, bool i_ContainDangerousMaterials, float i_CargoVolume)
        {
            Truck newTruck = null;
            fuelBasedTruckParamsAreValid(i_FuelBasedTruck.Wheels, i_FuelBasedTruck.FuelType, i_FuelBasedTruck.MaxFuelAmount);

            newTruck = new Truck(i_FuelBasedTruck, i_ContainDangerousMaterials, i_CargoVolume);

            return newTruck;
        }

        #endregion

        #region Create Wheels

        public static Wheel[] CreateWheels(string i_ManufacturerName, float i_MaxAirPressure, int i_NumberOfWheels)
        {
            Wheel[] newWheels = new Wheel[i_NumberOfWheels];

            for (int i = 0; i < newWheels.Length; i++)
            {
                newWheels[i] = new Wheel(i_ManufacturerName, i_MaxAirPressure);
            }

            return newWheels;
        }

        #endregion

        #region validations

        private static void electricCarParamsAreValid(Wheel[] i_Wheels, float i_MaxBatteryTime)
        {
            foreach (Wheel wheel in i_Wheels)
            {
                if (wheel.MaxAirPressure != k_ElectricCarValidMaxAirPressure)
                {
                    throw new ArgumentException($"Invalid air pressure: {wheel.MaxAirPressure}. The garage supports only {k_ElectricCarValidMaxAirPressure} air pressure.");
                }
            }

            if (i_Wheels.Length != k_ElectricCarValidNumberOfWheels)
            {
                throw new ArgumentException($"Invalid wheels amount: {i_Wheels.Length}. The garage supports only {k_ElectricCarValidNumberOfWheels} wheel amount.");
            }

            if (i_MaxBatteryTime != k_ElectricCarValidMaxBatteryTime)
            {
                throw new ArgumentException($"Invalid Max battery life: {i_MaxBatteryTime}. The garage supports only {k_ElectricCarValidMaxBatteryTime} battery life.");
            }
        }

        private static void fuelBasedCarParamsAreValid(Wheel[] i_Wheels, eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            bool carParamsValid = true;

            foreach (Wheel wheel in i_Wheels)
            {
                carParamsValid &= wheel.MaxAirPressure == k_FuelBasedCarValidMaxAirPressure;
            }

            carParamsValid &= i_Wheels.Length == k_FuelBasedCarValidNumberOfWheels;
            carParamsValid &= i_MaxFuelAmount == k_FuelBasedCarValidMaxFuelAmount;
            carParamsValid &= i_FuelType == k_FuelBasedCarValidFuelType;

            if (!carParamsValid)
            {
                //TODO: Create Exception
                throw new Exception();
            }
        }

        private static void electricMotorcycleParamsAreValid(Wheel[] i_Wheels, float i_MaxBatteryTime)
        {
            bool motorcycleParamsValid = true;

            foreach (Wheel wheel in i_Wheels)
            {
                motorcycleParamsValid &= wheel.MaxAirPressure == k_ElectricMotorcycleValidMaxAirPressure;
            }

            motorcycleParamsValid &= i_Wheels.Length == k_ElectricMotorcycleValidNumberOfWheels;
            motorcycleParamsValid &= i_MaxBatteryTime == k_ElectricMotorcycleValidMaxBatteryTime;
            if (!motorcycleParamsValid)
            {
                //TODO: Create Exception
                throw new Exception();
            }
        }

        private static void fuelBasedMotorcycleParamsAreValid(Wheel[] i_Wheels, eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            bool motorcycleParamsValid = true;

            foreach (Wheel wheel in i_Wheels)
            {
                motorcycleParamsValid &= wheel.MaxAirPressure == k_FuelBasedMotorcycleValidMaxAirPressure;
            }

            motorcycleParamsValid &= i_Wheels.Length == k_FuelBasedMotorcycleValidNumberOfWheels;
            motorcycleParamsValid &= i_MaxFuelAmount == k_FuelBasedMotorcycleValidMaxFuelAmount;
            motorcycleParamsValid &= i_FuelType == k_FuelBasedMotorcycleValidFuelType;

            if (!motorcycleParamsValid)
            {
                //TODO: Create Exception
                throw new Exception();
            }
        }

        private static void fuelBasedTruckParamsAreValid(Wheel[] i_Wheels, eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            bool truckParamsValid = true;

            foreach (Wheel wheel in i_Wheels)
            {
                truckParamsValid &= wheel.MaxAirPressure == k_FuelBasedTruckValidMaxAirPressure;
            }

            truckParamsValid &= i_Wheels.Length == k_FuelBasedTruckValidNumberOfWheels;
            truckParamsValid &= i_MaxFuelAmount == k_FuelBasedTruckValidMaxFuelAmount;
            truckParamsValid &= i_FuelType == k_FuelBasedTruckValidFuelType;

            if (!truckParamsValid)
            {
                //TODO: Create Exception
                throw new Exception();
            }
        }

        #endregion

    }
}

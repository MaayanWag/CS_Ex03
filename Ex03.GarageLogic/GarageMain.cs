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

        public static FuelBasedEnergy CreateFuelBasedEnergy(eFuelType i_FuelType, float i_MaxFuelAmount, float i_CurrentFuelAmount)
        {
            if (i_MaxFuelAmount < i_CurrentFuelAmount)
            {
                throw new ValueOutOfRangeException(i_CurrentFuelAmount, i_MaxFuelAmount, 0.0f);
            }

            FuelBasedEnergy fuelEnergy = new FuelBasedEnergy(i_FuelType, i_MaxFuelAmount, i_CurrentFuelAmount);

            return fuelEnergy;
        }

        public static ElectricEnergy CreateElectricEnergy(float i_MaxBatteryTimeAmount, float i_CurrentBatteryTimeAmount)
        {
            if (i_MaxBatteryTimeAmount < i_CurrentBatteryTimeAmount)
            {
                throw new ValueOutOfRangeException(i_CurrentBatteryTimeAmount, i_MaxBatteryTimeAmount, 0.0f);
            }

            ElectricEnergy electricEnergy = new ElectricEnergy(i_MaxBatteryTimeAmount, i_CurrentBatteryTimeAmount);

            return electricEnergy;
        }

        public static Car CreateCar(Energy i_Energy, Wheel[] i_Wheels, string i_LicenseNumber, string i_ModelName, 
            eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
        {
            Car newCar = null;
            ElectricEnergy electricEnergy = i_Energy as ElectricEnergy;
            FuelBasedEnergy fuelBasedEnergy = i_Energy as FuelBasedEnergy;
            eVehicleType vehicleType = eVehicleType.Electric;
            
            if (electricEnergy != null)
            {
                isElectricCarParamsAreValid(i_Wheels, electricEnergy.MaxBatteryTime);
            }
            else if (fuelBasedEnergy != null)
            {
                isFuelBasedCarParamsAreValid(i_Wheels, fuelBasedEnergy.FuelType, fuelBasedEnergy.MaxFuelAmount);
                vehicleType = eVehicleType.FuelBased;
            }
            else
            {
                throw new ArgumentException("Not a valid Vehicle! Should be fuel based or electric based only.");
            }

            newCar = new Car(i_Energy, i_Wheels, i_CarColor, i_NumberOfDoors, i_ModelName, i_LicenseNumber, vehicleType);

            return newCar;
        }

        public static Motorcycle CreateMotorcycle(Energy i_Energy, Wheel[] i_Wheels, string i_LicenseNumber, string i_ModelName,
            eLicenseType i_LicenseType, int i_EngineVolume)
        {
            Motorcycle newMotorcycle = null;
            ElectricEnergy electricEnergy = i_Energy as ElectricEnergy;
            FuelBasedEnergy fuelBasedEnergy = i_Energy as FuelBasedEnergy;
            eVehicleType vehicleType = eVehicleType.Electric;

            if (electricEnergy != null)
            {
                isElectricMotorcycleParamsAreValid(i_Wheels, electricEnergy.MaxBatteryTime);
            }
            else if (fuelBasedEnergy != null)
            {
                isFuelBasedMotorcycleParamsAreValid(i_Wheels, fuelBasedEnergy.FuelType, fuelBasedEnergy.MaxFuelAmount);
                vehicleType = eVehicleType.FuelBased;
            }
            else
            {
                throw new ArgumentException("Not a valid Energy!");
            }

            newMotorcycle = new Motorcycle(i_Energy, i_Wheels, i_LicenseNumber, i_LicenseType, i_EngineVolume, i_ModelName, vehicleType);

            return newMotorcycle;
        }

        public static Truck CreateTruck(FuelBasedEnergy i_FuelBasedTruck, Wheel[] i_Wheels, string i_LicenseNumber, string i_ModelName,
            bool i_ContainDangerousMaterials, float i_CargoVolume)
        {
            Truck newTruck = null;

            isFuelBasedTruckParamsAreValid(i_Wheels, i_FuelBasedTruck.FuelType, i_FuelBasedTruck.MaxFuelAmount);
            newTruck = new Truck(i_FuelBasedTruck, i_Wheels, i_ContainDangerousMaterials, i_CargoVolume, i_ModelName, i_LicenseNumber);

            return newTruck;
        }

        #endregion

        #region Create Wheels

        public static Wheel[] CreateWheels(string i_ManufacturerName, float i_MaxAirPressure, float i_CurrentAirPressure, int i_NumberOfWheels)
        {
            Wheel[] newWheels = new Wheel[i_NumberOfWheels];

            for (int i = 0; i < newWheels.Length; i++)
            {
                newWheels[i] = new Wheel(i_ManufacturerName, i_MaxAirPressure, i_CurrentAirPressure);
            }

            return newWheels;
        }

        #endregion

        #region validations

        private static void isElectricCarParamsAreValid(Wheel[] i_Wheels, float i_MaxBatteryTime)
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

        private static void isFuelBasedCarParamsAreValid(Wheel[] i_Wheels, eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            foreach (Wheel wheel in i_Wheels)
            {
                if (wheel.MaxAirPressure != k_FuelBasedCarValidMaxAirPressure)
                {
                    throw new ArgumentException($"Invalid air pressure: {wheel.MaxAirPressure}. The garage supports only {k_ElectricCarValidMaxAirPressure} air pressure.");
                }
            }

            if (i_Wheels.Length != k_FuelBasedCarValidNumberOfWheels)
            {
                throw new ArgumentException($"Invalid wheels amount: {i_Wheels.Length}. The garage supports only {k_ElectricCarValidNumberOfWheels} wheel amount.");
            }

            if (i_MaxFuelAmount != k_FuelBasedCarValidMaxFuelAmount)
            {
                throw new ArgumentException($"Invalid Max fuel amount: {i_MaxFuelAmount}. The garage supports only {k_FuelBasedCarValidMaxFuelAmount} fuel amount.");
            }

            if (i_FuelType != k_FuelBasedCarValidFuelType)
            {
                throw new ArgumentException($"Invalid fuel type: {i_FuelType}. The garage supports only {k_FuelBasedCarValidFuelType} fuel type..");
            }
        }

        private static void isElectricMotorcycleParamsAreValid(Wheel[] i_Wheels, float i_MaxBatteryTime)
        {
            bool motorcycleParamsValid = true;

            foreach (Wheel wheel in i_Wheels)
            {
                motorcycleParamsValid &= wheel.MaxAirPressure == k_ElectricMotorcycleValidMaxAirPressure;
            }
            
            if (i_Wheels.Length != k_ElectricMotorcycleValidNumberOfWheels)
            {
                throw new ArgumentException($"Invalid wheels amount: {i_Wheels.Length}. The garage supports only {k_ElectricMotorcycleValidNumberOfWheels} wheel amount.");
            }

            if (i_MaxBatteryTime != k_ElectricMotorcycleValidMaxBatteryTime)
            {
                throw new ArgumentException($"Invalid Max battery life: {i_MaxBatteryTime}. The garage supports only {k_ElectricMotorcycleValidMaxBatteryTime} battery life.");
            }
        }

        private static void isFuelBasedMotorcycleParamsAreValid(Wheel[] i_Wheels, eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            foreach (Wheel wheel in i_Wheels)
            {
                if (wheel.MaxAirPressure != k_FuelBasedMotorcycleValidMaxAirPressure)
                {
                    throw new ArgumentException($"Invalid air pressure: {wheel.MaxAirPressure}. The garage supports only {k_ElectricCarValidMaxAirPressure} air pressure.");
                }
            }
            
            if (i_Wheels.Length != k_FuelBasedMotorcycleValidNumberOfWheels)
            {
                throw new ArgumentException($"Invalid wheels amount: {i_Wheels.Length}. The garage supports only {k_FuelBasedMotorcycleValidNumberOfWheels} wheel amount.");
            }

            if (i_MaxFuelAmount != k_FuelBasedMotorcycleValidMaxFuelAmount)
            {
                throw new ArgumentException($"Invalid Max fuel amount: {i_MaxFuelAmount}. The garage supports only {k_FuelBasedMotorcycleValidMaxFuelAmount} fuel amount.");
            }

            if (i_FuelType != k_FuelBasedMotorcycleValidFuelType)
            {
                throw new ArgumentException($"Invalid fuel type: {i_FuelType}. The garage supports only {k_FuelBasedMotorcycleValidFuelType} fuel type..");
            }
        }

        private static void isFuelBasedTruckParamsAreValid(Wheel[] i_Wheels, eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            foreach (Wheel wheel in i_Wheels)
            {
                if (wheel.MaxAirPressure != k_FuelBasedTruckValidMaxAirPressure)
                {
                    throw new ArgumentException($"Invalid air pressure: {wheel.MaxAirPressure}. The garage supports only {k_FuelBasedTruckValidMaxAirPressure} air pressure.");
                }
            }

            if (i_Wheels.Length != k_FuelBasedTruckValidNumberOfWheels)
            {
                throw new ArgumentException($"Invalid wheels amount: {i_Wheels.Length}. The garage supports only {k_FuelBasedTruckValidNumberOfWheels} wheel amount.");
            }

            if (i_MaxFuelAmount != k_FuelBasedTruckValidMaxFuelAmount)
            {
                throw new ArgumentException($"Invalid Max fuel amount: {i_MaxFuelAmount}. The garage supports only {k_FuelBasedTruckValidMaxFuelAmount} fuel amount.");
            }

            if (i_FuelType != k_FuelBasedTruckValidFuelType)
            {
                throw new ArgumentException($"Invalid fuel type: {i_FuelType}. The garage supports only {k_FuelBasedTruckValidFuelType} fuel type..");
            }
        }

        #endregion
    }
}

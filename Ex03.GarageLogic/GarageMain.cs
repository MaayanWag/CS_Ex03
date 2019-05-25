using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageMain
    {
        private static Garage m_Garage;
        private const int k_ElectricCarValidNumberOfWheels = 4;
        private const float k_ElectricCarValidMaxAirPressure = 31;
        private const int k_FuelBasedCarValidNumberOfWheels = 4;
        private const float k_FuelBasedCarValidMaxAirPressure = 31;
        private const eFuelType k_FuelBasedCarValidFuelType = eFuelType.Octan96;
        private const float k_FuelBasedCarValidMaxFuelAmount = 55;

        //Type[] m_ValidTypes = new Type[5] {typeof(Car), } 

        public static void RunGarageSystem()
        {
            m_Garage = new Garage();
        }

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
                electricCarParamsAreValid(electricVehicle.Wheels, electricVehicle.MaxBatteryTIme);
                newCar = new Car(electricVehicle, i_CarColor, i_NumberOfDoors);
            }
            else if (fuelBasedVehicle != null)
            {
                fuelBasedCarParamsAreValid(fuelBasedVehicle.Wheels, fuelBasedVehicle.FuelType, fuelBasedVehicle.MaxFuelAmount);
                newCar = new Car(fuelBasedVehicle, i_CarColor, i_NumberOfDoors);
            }
            else
            {
                // TODO: change Exception
                throw new Exception("Not a valid Vehicle!");
            }

            return newCar;
        }

        public static Motorcycle CreateMotorcycle()
        {
            throw new NotImplementedException();
        }

        public static Truck CreateTruck()
        {
            throw new NotImplementedException();
        }

        #region validations

        private static void electricCarParamsAreValid(Wheel[] i_Wheels, float i_MaxBatteryLife)
        {
            bool carParamsValid = true;

            foreach (Wheel wheel in i_Wheels)
            {
                carParamsValid &= wheel.MaxAirPressure != k_ElectricCarValidMaxAirPressure;
            }

            carParamsValid &= i_Wheels.Length != k_ElectricCarValidNumberOfWheels;
            if (!carParamsValid)
            {
                //TODO: Create Exception
                throw new Exception();
            }
        }

        private static void fuelBasedCarParamsAreValid(Wheel[] i_Wheels, eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            bool carParamsValid = true;

            foreach (Wheel wheel in i_Wheels)
            {
                carParamsValid &= wheel.MaxAirPressure != k_FuelBasedCarValidMaxAirPressure;
            }

            carParamsValid &= i_Wheels.Length != k_FuelBasedCarValidNumberOfWheels;
            carParamsValid &= i_MaxFuelAmount != k_FuelBasedCarValidMaxFuelAmount;

            if (!carParamsValid)
            {
                //TODO: Create Exception
                throw new Exception();
            }
        }

        #endregion

    }
}

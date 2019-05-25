using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{ 
    public class GarageMain
    {
        private static Garage m_Garage;
        //Type[] m_ValidTypes = new Type[5] {typeof(Car), } 

        public static void RunGarageSystem()
        {
            m_Garage = new Garage();
         }

        public static FuelBasedVehicle CreateFuelBasedVehicle(string i_ModelName, string i_LicenseNumber, Wheel[] i_Wheels,
            eFuelType i_FuelType, float i_MaxFuelAmount)
        {
            FuelBasedVehicle vehicle = new FuelBasedVehicle (i_ModelName, i_LicenseNumber, i_Wheels, i_FuelType, i_MaxFuelAmount)

            
        }

        public static ElectricVehicle CreateElectricVehicle()
        {
            throw new NotImplementedException();
        }

        public static Car CreateCar(Vehicle i_VehicleType, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors)
        {
            Car newCar = null;
            ElectricVehicle electricVehicle = i_VehicleType as ElectricVehicle;
            FuelBasedVehicle fuelBasedVehicle = i_VehicleType as FuelBasedVehicle;
            
            if(electricVehicle != null)
            {
                newCar = new Car(electricVehicle, i_CarColor, i_NumberOfDoors);
            }
            else if(fuelBasedVehicle != null)
            {
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<Vehicle, List<VehicleAndOwnerDetails>> m_GarageVehicles;
        
        public void AddNewVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            //TODO: Create VehicleAndOwnerDetails
            throw new NotImplementedException();
        }

        public void ShowAllVehicleLicensePlates()
        {
            throw new NotImplementedException();
        }

        public void ShowAllVehicleLicensePlates(params eVehicleState[] i_VehicleStatesTofilter)
        {
            // consider PARAMS
            throw new NotImplementedException();
        }

        public void InflateTiresToMaximum(string i_VehicleLicensePlate)
        {
            throw new NotImplementedException();
        }

        public void RefuleVehicle(string i_VehicleLicensePlate, eFuelType i_FuelType, float i_AmountToFuel)
        {
            throw new NotImplementedException();
        }

        public void ChargeVehicle(string i_VehicleLicensePlate, float i_AmountToCharge)
        {
            throw new NotImplementedException();
        }

        public void DisplayVehicleUInformation(string i_VehicleLicensePlate)
        {
            throw new NotImplementedException();
        }
    }
}

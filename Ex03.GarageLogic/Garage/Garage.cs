using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        #region Properties

        private Dictionary<string, VehicleAndOwnerDetails> m_GarageVehicles = 
            new Dictionary<string, VehicleAndOwnerDetails>();

        #endregion

        #region Add new Vehicle Functionality

        public void AddNewVehicle(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            // TODO: appropriate msg? (pdf)
            chackIfVehicleIsValid(i_Vehicle);
            if (!isVehicleInsideTheGarage(i_Vehicle))
            {
                VehicleAndOwnerDetails newVehicleAndOwnerDetailsByLicensePlate = 
                    new VehicleAndOwnerDetails(i_Vehicle, i_OwnerName, i_OwnerPhoneNumber);
                m_GarageVehicles.Add(i_Vehicle.LicenceNumber, newVehicleAndOwnerDetailsByLicensePlate);
            }
            else
            {
                updateVehicleAndOwnerDetails(i_Vehicle, i_OwnerName, i_OwnerPhoneNumber);
            }
        }

        private void chackIfVehicleIsValid(Vehicle i_Vehicle)
        {
            throw new NotImplementedException();
        }

        private void updateVehicleAndOwnerDetails(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            VehicleAndOwnerDetails vehicleAndOwnerDetailsByLicensePlateToUpdate = m_GarageVehicles[i_Vehicle.LicenceNumber];
            vehicleAndOwnerDetailsByLicensePlateToUpdate.OwnerVehicleState = eVehicleState.InRepair;
            vehicleAndOwnerDetailsByLicensePlateToUpdate.OwnerName = i_OwnerName;
            vehicleAndOwnerDetailsByLicensePlateToUpdate.OwnerPhoneNumber = i_OwnerPhoneNumber;
        }
        
        #endregion

        #region get license plates functonality

        public List<string> GetAllVehicleLicensePlatesByFilter(params eVehicleState[] i_VehicleStatesToFilter)
        {
            List<string> filteredLicensePlates = new List<string>();
            List<VehicleAndOwnerDetails> vehicleAndOwnerDetails = getVehicleAndOwnerDetails();
            
            filterVehiclesLicensePlates(vehicleAndOwnerDetails, i_VehicleStatesToFilter, filteredLicensePlates);
            
            return filteredLicensePlates;
        }

        private void filterVehiclesLicensePlates(List<VehicleAndOwnerDetails> i_VehicleAndOwnerDetails, 
            eVehicleState[] i_VehicleStatesToFilter, List<string> i_FilteredLicensePlates)
        {
            foreach (VehicleAndOwnerDetails vehicleAndOwnerDetails in i_VehicleAndOwnerDetails)
            {
                eVehicleState vehicleState = vehicleAndOwnerDetails.OwnerVehicleState;

                if (Array.IndexOf(i_VehicleStatesToFilter, vehicleState) > -1)
                {
                    i_FilteredLicensePlates.Add(vehicleAndOwnerDetails.Vehicle.LicenceNumber);
                }
            }
        }
        
        #endregion

        #region change vehicle state functonality

        public void ChangeVehicleState(string i_VehicleLicensePlate, eVehicleState i_NewState)
        {
            getVehicleDetailesByLicensePlate(i_VehicleLicensePlate).OwnerVehicleState = i_NewState;
        }

        #endregion

        #region inflate tier functionality

        public void InflateTiresToMaximum(string i_VehicleLicensePlate)
        {
            Vehicle vehicleToInflateTo = getVehicleDetailesByLicensePlate(i_VehicleLicensePlate).Vehicle;
            Wheel[] vehicleWheels = vehicleToInflateTo.Wheels;

            foreach (Wheel vehicleWheel in vehicleWheels)
            {
                flateWheelToMaximum(vehicleWheel);
            }
        }

        private void flateWheelToMaximum(Wheel vehicleWheel)
        {
            float currentWheelFlateState = vehicleWheel.CurrentAirPressure;
            float amountOfAirToInflate = vehicleWheel.MaxAirPressure - currentWheelFlateState;

            vehicleWheel.InflateAction(amountOfAirToInflate);
        }

        #endregion

        #region Refuel Functionality

        public void RefuelFuelBasedVehicle(string i_VehicleLicensePlate, eFuelType i_FuelType, float i_AmountToFuel)
        {
            Vehicle vehicle = getVehicleByLicensePlate(i_VehicleLicensePlate);
            FuelBasedVehicle vehicleToFuel = vehicle as FuelBasedVehicle;

            if (vehicleToFuel == null)
            {
                // TODO: throw the right Exception
                throw new Exception("Only Fuel Based Vehicles are accepted");
            }

            vehicleToFuel.FuelGas(i_AmountToFuel, i_FuelType);
        }

        #endregion

        #region ChargeVehicle functionality

        public void ChargeVehicle(string i_VehicleLicensePlate, float i_AmountToCharge)
        {
            Vehicle vehicle = getVehicleByLicensePlate(i_VehicleLicensePlate);
            ElectricVehicle vehicleToFuel = vehicle as ElectricVehicle;

            if (vehicleToFuel == null)
            {
                // TODO: throw the right Exception
                throw new Exception("Only Electric Based Vehicles are accepted");
            }

            vehicleToFuel.ChargeBattery(i_AmountToCharge);
        }

        #endregion

        #region Vehcile information functionality

        public void DisplayVehicleUInformation(string i_VehicleLicensePlate)
        {
            throw new NotImplementedException();
        }
        
        #endregion

        #region General Helper Methods
        
        private VehicleAndOwnerDetails getVehicleDetailesByLicensePlate(string i_LicensePlateNumber)
        {
            VehicleAndOwnerDetails vehicleAndOwnerDetailsByLicensePlate = null;

            try
            {
                vehicleAndOwnerDetailsByLicensePlate = m_GarageVehicles[i_LicensePlateNumber];
            }
            catch(KeyNotFoundException)
            {
                // TODO: throw the currect Exception
                throw new Exception("Not such vehicle in the garage!");
            }

            return vehicleAndOwnerDetailsByLicensePlate;
        }

        private List<VehicleAndOwnerDetails> getVehicleAndOwnerDetails()
        {
            List<VehicleAndOwnerDetails> vehicleAndOwnerDetails = new List<VehicleAndOwnerDetails>();
            List<Vehicle> garageVehicles = getGarageVehiclesAsList();

            foreach (Vehicle vehicleKey in garageVehicles)
            {
                vehicleAndOwnerDetails.Add(m_GarageVehicles[vehicleKey.LicenceNumber]);
            }

            return vehicleAndOwnerDetails;
        }

        private Vehicle getVehicleByLicensePlate(string i_LicensePlateNumber)
        {
            return getVehicleDetailesByLicensePlate(i_LicensePlateNumber).Vehicle;
        }

        private List<Vehicle> getGarageVehiclesAsList()
        {
            List<Vehicle> garageVehicles = new List<Vehicle>();
            List<string> garageLicensePlates = new List<string>(m_GarageVehicles.Keys);

            foreach (string licensePlate in garageLicensePlates)
            {
                garageVehicles.Add(getVehicleDetailesByLicensePlate(licensePlate).Vehicle);
            }

            return garageVehicles;
        }

        private bool isVehicleInsideTheGarage(Vehicle i_Vehicle)
        {
            return m_GarageVehicles.ContainsKey(i_Vehicle.LicenceNumber);
        }


        #endregion
    }
}

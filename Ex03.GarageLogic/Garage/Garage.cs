using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        #region Properties

        private static Dictionary<string, VehicleAndOwnerDetails> m_GarageVehicles = 
            new Dictionary<string, VehicleAndOwnerDetails>();

        #endregion

        #region Add new Vehicle Functionality #1

        public static void AddNewVehicle(Vehicle i_vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            string errorMessage = "";
            if (isVehicleInTheGarage(i_vehicle))
            {
                errorMessage = $"{Environment.NewLine}This vehicle exist in the garage. Changing the vehicle state to 'InRepair'.";
                updateVehicleAndOwnerDetails(i_vehicle, i_OwnerName, i_OwnerPhoneNumber, eVehicleState.InRepair);
                throw new ArgumentException(errorMessage);
            }
            else
            {
                VehicleAndOwnerDetails newVehicleAndOwnerDetailsByLicensePlate =
                   new VehicleAndOwnerDetails(i_vehicle, i_OwnerName, i_OwnerPhoneNumber);
                m_GarageVehicles.Add(i_vehicle.LicenceNumber, newVehicleAndOwnerDetailsByLicensePlate);
            }
        }
        
        private static void updateVehicleAndOwnerDetails(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber, eVehicleState i_VehicleState)
        {
            VehicleAndOwnerDetails vehicleAndOwnerDetailsByLicensePlateToUpdate = m_GarageVehicles[i_Vehicle.LicenceNumber];

            vehicleAndOwnerDetailsByLicensePlateToUpdate.OwnerVehicleState = i_VehicleState;
            vehicleAndOwnerDetailsByLicensePlateToUpdate.OwnerName = i_OwnerName;
            vehicleAndOwnerDetailsByLicensePlateToUpdate.OwnerPhoneNumber = i_OwnerPhoneNumber;
        }

        #endregion

        #region get license plates functonality #2

        public static List<string> GetAllVehicleLicensePlatesByFilter(params eVehicleState[] i_VehicleStatesToFilter)
        {
            List<string> filteredLicensePlates = new List<string>();
            List<VehicleAndOwnerDetails> vehicleAndOwnerDetails = getVehicleAndOwnerDetails();
            
            filterVehiclesLicensePlates(vehicleAndOwnerDetails, i_VehicleStatesToFilter, filteredLicensePlates);
            
            return filteredLicensePlates;
        }

        private static void filterVehiclesLicensePlates(List<VehicleAndOwnerDetails> i_VehicleAndOwnerDetails, 
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

        #region change vehicle state functonality #3

        public static void ChangeVehicleState(string i_VehicleLicensePlate, eVehicleState i_NewState)
        {
            getVehicleDetailesByLicensePlate(i_VehicleLicensePlate).OwnerVehicleState = i_NewState;
        }

        #endregion

        #region inflate tier functionality #4

        public static void InflateTiresToMaximum(string i_VehicleLicensePlate)
        {
            Vehicle vehicleToInflateTo = getVehicleDetailesByLicensePlate(i_VehicleLicensePlate).Vehicle;
            Wheel[] vehicleWheels = vehicleToInflateTo.Wheels;

            foreach (Wheel vehicleWheel in vehicleWheels)
            {
                vehicleWheel.InflateAction();
            }
        }

        #endregion

        #region Refuel Functionality #5

        public static void RefuelFuelBasedVehicle(string i_VehicleLicensePlate, eFuelType i_FuelType, float i_AmountToFuel)
        {
            Vehicle vehicle = getVehicleByLicensePlate(i_VehicleLicensePlate);
            FuelBasedEnergy EnergyToFuel = vehicle.Energy as FuelBasedEnergy;

            if (EnergyToFuel == null)
            {
                throw new ArgumentException("Only Fuel Based Vehicles are accepted.");
            }

            EnergyToFuel.FuelGas(i_AmountToFuel, i_FuelType);
        }

        #endregion

        #region ChargeVehicle functionality #6

        public static void ChargeVehicle(string i_VehicleLicensePlate, float i_AmountToCharge)
        {
            Vehicle vehicle = getVehicleByLicensePlate(i_VehicleLicensePlate);

            ElectricEnergy EnergyToCharge = vehicle.Energy as ElectricEnergy;

            if (EnergyToCharge == null)
            {
                throw new ArgumentException("Only Electric Based Vehicles are accepted.");
            }

            EnergyToCharge.ChargeBattery(i_AmountToCharge);
        }

        #endregion

        #region Vehcile information functionality #7

        public static string DisplayVehicleInformation(string i_VehicleLicensePlate)
        {
            Vehicle vehicle = getVehicleByLicensePlate(i_VehicleLicensePlate);
            VehicleAndOwnerDetails vehicleAndOwnerDetails = getVehicleDetailesByLicensePlate(i_VehicleLicensePlate);
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.Append("Vehicle Information:");
            vehicleInfo.AppendLine();
            vehicleInfo.Append("State - ");
            vehicleInfo.Append(vehicleAndOwnerDetails.OwnerVehicleState);
            vehicleInfo.AppendLine();
            vehicleInfo.Append("Owner Details - name: ");
            vehicleInfo.Append(vehicleAndOwnerDetails.OwnerName);
            vehicleInfo.Append(", Phone number: ");
            vehicleInfo.Append(vehicleAndOwnerDetails.OwnerPhoneNumber);
            vehicleInfo.AppendLine();
            vehicleInfo.Append(vehicle.ToString());
                

            return vehicleInfo.ToString();
        }
        
        #endregion

        #region General Helper Methods
        
        private static VehicleAndOwnerDetails getVehicleDetailesByLicensePlate(string i_LicensePlateNumber)
        {
            VehicleAndOwnerDetails vehicleAndOwnerDetailsByLicensePlate = null;

            try
            {
                vehicleAndOwnerDetailsByLicensePlate = m_GarageVehicles[i_LicensePlateNumber];
            }
            catch(KeyNotFoundException)
            {
                // TODO: throw the currect Exception
                throw new ArgumentException($"The vehicle with license number '{i_LicensePlateNumber}' is not in the garage!");
            }

            return vehicleAndOwnerDetailsByLicensePlate;
        }

        private static List<VehicleAndOwnerDetails> getVehicleAndOwnerDetails()
        {
            List<VehicleAndOwnerDetails> vehicleAndOwnerDetails = new List<VehicleAndOwnerDetails>();
            List<Vehicle> garageVehicles = getGarageVehiclesAsList();

            foreach (Vehicle vehicleKey in garageVehicles)
            {
                vehicleAndOwnerDetails.Add(m_GarageVehicles[vehicleKey.LicenceNumber]);
            }

            return vehicleAndOwnerDetails;
        }

        private static Vehicle getVehicleByLicensePlate(string i_LicensePlateNumber)
        {
            return getVehicleDetailesByLicensePlate(i_LicensePlateNumber).Vehicle;
        }

        private static List<Vehicle> getGarageVehiclesAsList()
        {
            List<Vehicle> garageVehicles = new List<Vehicle>();
            List<string> garageLicensePlates = new List<string>(m_GarageVehicles.Keys);

            foreach (string licensePlate in garageLicensePlates)
            {
                garageVehicles.Add(getVehicleDetailesByLicensePlate(licensePlate).Vehicle);
            }

            return garageVehicles;
        }

        private static bool isVehicleInTheGarage(Vehicle i_Vehicle)
        {
            return m_GarageVehicles.ContainsKey(i_Vehicle.LicenceNumber);
        }

        public static bool IsVehicleInTheGarageByLicenseNumber(string i_LicenseNumber)
        {
            return m_GarageVehicles.ContainsKey(i_LicenseNumber);
        }

        #endregion
    }
}

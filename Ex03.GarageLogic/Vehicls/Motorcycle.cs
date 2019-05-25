using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        #region Properties

        private FuelBasedVehicle m_FuelBasedMotorcycle = null;
        private ElectricVehicle m_ElectricVehicle = null;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        #endregion

        #region Constructors
        
        public Motorcycle(Vehicle i_VehicleType, eLicenseType i_LicenseType, int i_EngineVolume) :
            base(i_VehicleType.ModelName, i_VehicleType.LicenceNumber, i_VehicleType.Wheels, i_VehicleType.VehicleType)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
            m_FuelBasedMotorcycle = i_VehicleType as FuelBasedVehicle;
            m_ElectricVehicle = i_VehicleType as ElectricVehicle;
        }

        #endregion

        #region FuelBased

        #region Getters And Setters

        public float MaxFuelAmount
        {

            get { return m_FuelBasedMotorcycle.MaxFuelAmount; }
        }

        public float CurrentFuelAmount
        {
            get { return m_FuelBasedMotorcycle.CurrentFuelAmount; }
            set { m_FuelBasedMotorcycle.CurrentFuelAmount = value; }
        }

        public eFuelType FuelType
        {
            get { return m_FuelBasedMotorcycle.FuelType; }
        }

        #endregion

        #region Methods

        public void FuelGas(float i_GasAmount, eFuelType i_FuelType)
        {
            if (m_VehicleType == eVehicleType.FuelBased)
            {
                m_FuelBasedMotorcycle.FuelGas(i_GasAmount, i_FuelType);
            }
            else
            {
                // TODO: Throw Exception If needed
                throw new NotImplementedException();
            }
        }
        
        #endregion

        #endregion FuelBased

        #region Electric

        #region Getters And Setters

        public float CurrentBatteryTime
        {
            get { return m_ElectricVehicle.CurrentBatteryTime; }
            set { m_ElectricVehicle.CurrentBatteryTime = value; }
        }

        public float MaxBatteryTIme
        {
            get { return m_ElectricVehicle.MaxBatteryTIme; }
        }

        #endregion

        #region Methods
        
        public void ChargeBattery(float i_ChargingTime)
        {
            if (m_VehicleType == eVehicleType.Electric)
            {
                m_ElectricVehicle.ChargeBattery(i_ChargingTime);
            }
            else
            {
                // TODO: Throw Exception If needed
                throw new NotImplementedException();
            }
        }

        #endregion

        #endregion Electric

        #region Motorcycle

        #region Getters And Setters

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
        }

        #endregion

        #region Methods

        public override float CalcRemainingEnergy()
        {
            float remainingEnergy = 0;

            if (VehicleType == eVehicleType.FuelBased)
            {
                remainingEnergy = m_FuelBasedMotorcycle.CalcRemainingEnergy();
            }
            else if (VehicleType == eVehicleType.Electric)
            {
                remainingEnergy = m_ElectricVehicle.CalcRemainingEnergy();
            }

            return remainingEnergy;
        }

        #endregion

        #endregion Motorcycle
    }
}

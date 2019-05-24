using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        #region Properties

        private FuelBasedVehicle m_FuelBasedMotorcycle = null;
        private ElectricVehicle m_ElectricMotorcycle = null;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        #endregion
        
        #region FuelBased

        #region Constructors

        public Motorcycle(FuelBasedVehicle i_FuelBasedVehicle, eLicenseType i_LicenseType, int i_EngineVolume) :
            base(i_FuelBasedVehicle.ModelName, i_FuelBasedVehicle.LicenceNumber, i_FuelBasedVehicle.Wheels, i_FuelBasedVehicle.VehicleType)
        {
            m_FuelBasedMotorcycle = i_FuelBasedVehicle;
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }

        #endregion

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

        #region Constructors

        public Motorcycle(ElectricVehicle i_ElectricVehicle, eLicenseType i_LicenseType, int i_EngineVolume) :
            base(i_ElectricVehicle.ModelName, i_ElectricVehicle.LicenceNumber, i_ElectricVehicle.Wheels, i_ElectricVehicle.VehicleType)
        {
            m_ElectricMotorcycle = i_ElectricVehicle;
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }

        #endregion

        #region Getters And Setters

        public float CurrentBatteryTime
        {
            get { return m_ElectricMotorcycle.CurrentBatteryTime; }
            set { m_ElectricMotorcycle.CurrentBatteryTime = value; }
        }

        public float MaxBatteryTIme
        {
            get { return m_ElectricMotorcycle.MaxBatteryTIme; }
        }

        #endregion

        #region Methods
        
        public void ChargeBattery(float i_ChargingTime)
        {
            if (m_VehicleType == eVehicleType.Electric)
            {
                m_ElectricMotorcycle.ChargeBattery(i_ChargingTime);
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
                remainingEnergy = m_ElectricMotorcycle.CalcRemainingEnergy();
            }

            return remainingEnergy;
        }

        #endregion

        #endregion Motorcycle
    }
}

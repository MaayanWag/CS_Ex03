using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Car : Vehicle
    {
        #region Properties
        private FuelBasedVehicle m_FuelBasedCar = null;
        private ElectricVehicle m_ElectricCar = null;
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;
        #endregion

        #region FuelBased

        #region Constructors
        
        public Car(FuelBasedVehicle i_FuelBasedVehicle, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors) :
            base(i_FuelBasedVehicle.ModelName, i_FuelBasedVehicle.LicenceNumber, i_FuelBasedVehicle.Wheels, i_FuelBasedVehicle.VehicleType)
        {
            m_FuelBasedCar = i_FuelBasedVehicle;
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }
        #endregion

        #region Getters And Setters

        public float MaxFuelAmount
        {

            get { return m_FuelBasedCar.MaxFuelAmount; }
        }

        public float CurrentFuelAmount
        {
            get { return m_FuelBasedCar.CurrentFuelAmount; }
            set { m_FuelBasedCar.CurrentFuelAmount = value; }
        }

        public eFuelType FuelType
        {
            get { return m_FuelBasedCar.FuelType; }
        }

        #endregion

        #region Methods

        public void FuelGas(float i_GasAmount, eFuelType i_FuelType)
        {
            if (m_VehicleType == eVehicleType.FuelBased)
            {
                m_FuelBasedCar.FuelGas(i_GasAmount, i_FuelType);
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

        public Car(ElectricVehicle i_ElectricVehicle, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors) :
            base(i_ElectricVehicle.ModelName, i_ElectricVehicle.LicenceNumber, i_ElectricVehicle.Wheels, i_ElectricVehicle.VehicleType)
        {
            m_ElectricCar = i_ElectricVehicle;
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
        }

        #endregion

        #region Getters And Setters

        public float CurrentBatteryTime
        {
            get { return m_ElectricCar.CurrentBatteryTime; }
            set { m_ElectricCar.CurrentBatteryTime = value; }
        }

        public float MaxBatteryTIme
        {
            get { return m_ElectricCar.MaxBatteryTIme; }
        }

        #endregion

        #region Methods

        public void ChargeBattery(float i_ChargingTime)
        {
            if (m_VehicleType == eVehicleType.Electric)
            {
                m_ElectricCar.ChargeBattery(i_ChargingTime);
            }
            else
            {
                // TODO: Throw Exception If needed
                throw new NotImplementedException();
            }
        }

        #endregion

        #endregion Electric

        #region Car

        #region Getters And Setters

        public eCarColor CarColor
        {
            get { return m_CarColor; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
        }

        #endregion

        #region Methods

        public override float CalcRemainingEnergy()
        {
            float remainingEnergy = 0;

            if (VehicleType == eVehicleType.FuelBased)
            {
                remainingEnergy = m_FuelBasedCar.CalcRemainingEnergy();
            }
            else if (VehicleType == eVehicleType.Electric)
            {
                remainingEnergy = m_ElectricCar.CalcRemainingEnergy();
            }

            return remainingEnergy;
        }

        #endregion

        #endregion Car
    }
}

﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        #region Properties
        private FuelBasedVehicle m_FuelBasedCar = null;
        private ElectricVehicle m_ElectricCar = null;
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

        #endregion

        #region Constructors

        public Car(Vehicle i_Vehicle, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors) :
            base(i_Vehicle.ModelName, i_Vehicle.LicenceNumber, i_Vehicle.Wheels, i_Vehicle.VehicleType)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
            m_FuelBasedCar = i_Vehicle as FuelBasedVehicle;
            m_ElectricCar = i_Vehicle as ElectricVehicle;
        }

        #endregion

        #region FuelBased

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

        #region Getters And Setters

        public float CurrentBatteryTime
        {
            get { return m_ElectricCar.CurrentBatteryTime; }
            set { m_ElectricCar.CurrentBatteryTime = value; }
        }

        public float MaxBatteryTIme
        {
            get { return m_ElectricCar.MaxBatteryTime; }
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

        #region To String

        public override string ToString()
        {
            StringBuilder carString = new StringBuilder();
            
            carString.Append(base.ToString());
            carString.AppendLine();
            if (m_FuelBasedCar != null)
            {
                carString.Append(m_FuelBasedCar.ToString());
            }
            else if (m_ElectricCar != null)
            {
                carString.Append(m_ElectricCar.ToString());
            }

            carString.AppendLine();
            carString.Append("Car color - ");
            carString.Append(CarColor);
            carString.Append(", Number of doors - ");
            carString.Append(NumberOfDoors);
            
            return carString.ToString();
        }

        #endregion
    }
}
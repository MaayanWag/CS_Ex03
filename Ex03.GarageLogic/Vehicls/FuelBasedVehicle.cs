﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelBasedVehicle : Vehicle
    {
        #region properties
        private eFuelType m_FuelType;
        private float m_CurrentFuelAmount;
        private float m_MaxFuelAmount;
        #endregion

        #region Constructors
        public FuelBasedVehicle(string i_ModelName, string i_LicenseNumber, Wheel[] i_Wheels,
            eFuelType i_FuelType, float i_MaxFuelAmount) :
            base(i_ModelName, i_LicenseNumber, i_Wheels, eVehicleType.FuelBased)
        {
            m_FuelType = i_FuelType;
            m_CurrentFuelAmount = i_MaxFuelAmount;
            m_MaxFuelAmount = i_MaxFuelAmount;
        }
        #endregion
        
        #region Getters And Setters
        public float MaxFuelAmount
        {
            get { return m_MaxFuelAmount; }
        }

        public float CurrentFuelAmount
        {
            get { return m_CurrentFuelAmount; }
            set { m_CurrentFuelAmount = value; }
        }

        public eFuelType FuelType
        {
            get { return m_FuelType; }
        }
        #endregion

        #region Methods

        public override float CalcRemainingEnergy()
        {
            return CurrentFuelAmount / MaxFuelAmount * 100;
        }

        public virtual void FuelGas(float i_GasAmount, eFuelType i_FuelType)
        {
            if (i_FuelType != FuelType)
            {
                // TODO: throw the correct Exception! 
                throw new Exception("Not the right fuel type");
            }
            else if(CurrentFuelAmount + i_GasAmount > MaxFuelAmount)
            {
                // TODO: throw the correct Exception! 
                throw new Exception("Not the right fuel amount");
            }

            CurrentFuelAmount += i_GasAmount;
        }
        #endregion
    }
}
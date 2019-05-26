﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        #region Properties

        private bool m_ContainDangerousMaterials;
        private float m_CargoVolume;
        private FuelBasedEnergy m_FuelEnergy;

        #endregion

        #region FuelBased

        #region Constructors

        public Truck(FuelBasedEnergy i_FuelEnergy, Wheel[] i_Wheels, bool i_ContainDangerousMaterials,
            float i_CargoVolume, string i_ModelName, string i_LicenseNumber) 
            : base( i_ModelName, i_LicenseNumber, i_Wheels, eVehicleType.FuelBased)
        {
            m_FuelEnergy = i_FuelEnergy;
            m_ContainDangerousMaterials = i_ContainDangerousMaterials;
            m_CargoVolume = i_CargoVolume;
        }

        #endregion

        #region Getters And Setters

        public float MaxFuelAmount
        {

            get { return m_FuelEnergy.MaxFuelAmount; }
        }

        public float CurrentFuelAmount
        {
            get { return m_FuelEnergy.CurrentFuelAmount; }
            set { m_FuelEnergy.CurrentFuelAmount = value; }
        }

        public eFuelType FuelType
        {
            get { return m_FuelEnergy.FuelType; }
        }

        #endregion

        #region Methods

        public void FuelGas(float i_GasAmount, eFuelType i_FuelType)
        {
            m_FuelEnergy.FuelGas(i_GasAmount, i_FuelType);
        }

        #endregion

        #endregion FuelBased

        #region Truck

        #region Getters And Setters

        public bool ContainDangerousMaterials
        {
            get { return m_ContainDangerousMaterials; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
        }

        #endregion

        #region Methods

        public override float CalcRemainingEnergy()
        {
            return m_FuelEnergy.CalcRemainigEnergy();
        }

        #endregion

        #endregion Truck

        #region To String

        public override string ToString()
        {
            StringBuilder truckString = new StringBuilder();

            truckString.Append(base.ToString());
            truckString.AppendLine();
            truckString.Append(m_FuelEnergy.ToString());
            truckString.AppendLine();
            truckString.Append("Contain dangerous materials - ");
            truckString.Append(ContainDangerousMaterials);
            truckString.Append(", Cargo volume - ");
            truckString.Append(CargoVolume);

            return truckString.ToString();
        }

        #endregion
    }
}

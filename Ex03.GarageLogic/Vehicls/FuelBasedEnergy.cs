using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelBasedEnergy : Energy
    {
        #region properties
        private eFuelType m_FuelType;
        #endregion

        #region Constructors
        public FuelBasedEnergy(eFuelType i_FuelType, float i_MaxFuelAmount , float i_CurrentFuelAmount)             
        {
            m_FuelType = i_FuelType;
            base.MaxAmount = i_MaxFuelAmount;
            base.CurrentAmount = i_CurrentFuelAmount;
        }
        #endregion
        
        #region Getters And Setters
        public float MaxFuelAmount
        {
            get { return MaxAmount; }
        }

        public float CurrentFuelAmount
        {
            get { return CurrentAmount; }
            set { CurrentAmount = value; }
        }

        public eFuelType FuelType
        {
            get { return m_FuelType; }
        }
        #endregion

        #region Methods

        public virtual void FuelGas(float i_GasAmount, eFuelType i_FuelType)
        {
            if (i_FuelType != FuelType)
            {
                string errorMessage = $"Fuel Type '{i_FuelType}' is not correct. Should be '{FuelType}' only for this vehicle.";
                throw new ArgumentException(errorMessage);
            }
            else if(CurrentFuelAmount + i_GasAmount > MaxFuelAmount)
            {
                throw new ValueOutOfRangeException(i_GasAmount, MaxFuelAmount - CurrentFuelAmount, 0.0f);
            }

            CurrentFuelAmount += i_GasAmount;
        }

        #endregion

        #region To String

        public override string ToString()
        {
            StringBuilder fuelString = new StringBuilder();

            fuelString.Append("Fuel Type - ");
            fuelString.Append(FuelType);
            fuelString.Append(", Current fuel amount - ");
            fuelString.Append(CurrentFuelAmount);
            fuelString.Append(", Max fuel amount - ");
            fuelString.Append(MaxFuelAmount);

            return fuelString.ToString();

        }

        #endregion
    }
}

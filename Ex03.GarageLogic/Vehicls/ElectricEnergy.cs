using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEnergy : Energy
    {
        #region Properties
        //private float m_CurrentBatteryTimeAmount;
        //private float m_MaxBatteryTimeAmount;
        #endregion

        #region Constructor
        public ElectricEnergy(float i_MaxBatteryTimeAmount, float i_CurrentBatteryTimeAmount)
        {
            base.MaxAmount = i_MaxBatteryTimeAmount;
            base.CurrentAmount = i_CurrentBatteryTimeAmount;
        }
        #endregion

        #region Getters And Setters
        public float CurrentBatteryTime
        {
            get { return CurrentAmount; }
            set { CurrentAmount = value; }
        }

        public float MaxBatteryTime
        {
            get { return MaxAmount; }
        }
        #endregion

        #region Methods
        
        public virtual void ChargeBattery(float i_ChargingTime)
        {
            if (i_ChargingTime + CurrentBatteryTime > MaxBatteryTime)
            {
                throw new ValueOutOfRangeException(i_ChargingTime, MaxBatteryTime - CurrentBatteryTime, 0.0f);
            }

            CurrentBatteryTime += i_ChargingTime;
        }
        #endregion

        #region To String

        public override string ToString()
        {
            StringBuilder electricSting = new StringBuilder();

            electricSting.Append("Current battery time amount - ");
            electricSting.Append(CurrentBatteryTime);
            electricSting.Append(", Max battery time amount - ");
            electricSting.Append(MaxBatteryTime);

            return electricSting.ToString();
        }

        #endregion
    }
}

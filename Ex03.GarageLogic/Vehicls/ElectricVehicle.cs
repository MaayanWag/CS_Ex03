using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricVehicle : Vehicle
    {
        #region Properties
        private float m_CurrentBatteryTimeAmount;
        private float m_MaxBatteryTimeAmount;
        #endregion

        #region Constructor
        public ElectricVehicle(string i_ModelName, string i_LicenseNumber, Wheel[] i_Wheels,
            float i_MaxBatteryTimeAmount) : 
            base(i_ModelName,  i_LicenseNumber, i_Wheels, eVehicleType.Electric)
        {
            m_CurrentBatteryTimeAmount = i_MaxBatteryTimeAmount;
            m_MaxBatteryTimeAmount = i_MaxBatteryTimeAmount;
        }
        #endregion

        #region Getters And Setters
        public float CurrentBatteryTime
        {
            get { return m_CurrentBatteryTimeAmount; }
            set { m_CurrentBatteryTimeAmount = value; }
        }

        public float MaxBatteryTime
        {
            get { return m_MaxBatteryTimeAmount; }
        }
        #endregion

        #region Methods

        public override float CalcRemainingEnergy()
        {
            return CurrentBatteryTime / MaxBatteryTime * 100;
        }

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

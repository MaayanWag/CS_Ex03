using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public struct Wheel
    {
        #region properties

        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        private string m_ManufacturerName;

        #endregion

        #region Constructors

        public Wheel(string i_ManufacturerName, float i_MaxAirPressure, float i_CurrentAirPressure)
        {
            m_CurrentAirPressure = i_CurrentAirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
            m_ManufacturerName = i_ManufacturerName;
        }

        #endregion

        #region Getters And Setters

        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        #endregion

        #region Methods

        public void InflateAction()
        {
            CurrentAirPressure = MaxAirPressure;
        }

        #endregion

        #region To String

        public override string ToString()
        {
            StringBuilder wheelString = new StringBuilder();

            wheelString.Append("Current air pressure - ");
            wheelString.Append(CurrentAirPressure);
            wheelString.Append(", Max air pressure - ");
            wheelString.Append(MaxAirPressure);
            wheelString.Append(", Manufacturer name - ");
            wheelString.Append(CurrentAirPressure);

            return wheelString.ToString();
        }
        #endregion
    }
}

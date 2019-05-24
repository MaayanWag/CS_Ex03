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

        public Wheel(string i_ManufacturerName, float i_MaxAirPressure)
        {
            m_CurrentAirPressure = i_MaxAirPressure;
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

        public void InflateAction(float i_AmountOfAirToAdd)
        {
            if (i_AmountOfAirToAdd + CurrentAirPressure >= MaxAirPressure)
            {
                // TODO: add the right Exception
                throw new Exception("Too much air!");
            }

            CurrentAirPressure += i_AmountOfAirToAdd;
        }
        
        #endregion
    }
}

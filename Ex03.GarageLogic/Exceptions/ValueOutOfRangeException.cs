using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public ValueOutOfRangeException(float i_Value, float i_MaxValue, float i_MinValue)
            : base(string.Format("Value '{0}' out of range. Should be between {1} - {2}.", i_Value, i_MinValue, i_MaxValue))
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(Exception i_InnerException, float i_Value, float i_MaxValue, float i_MinValue)
            : base(string.Format("Value '{0}' out of range. Should be between {1} - {2}.", i_Value, i_MinValue, i_MaxValue),
            i_InnerException)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}

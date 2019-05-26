using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Energy
    {
        private float m_CurrentAmount;
        private float m_MaxAmount;

        public float CurrentAmount
        {
            get { return m_CurrentAmount; }
            set { m_CurrentAmount = value; }
        }

        public float MaxAmount
        {
            get { return m_MaxAmount; }
            set { m_MaxAmount = value; }
        }

        public float CalcRemainigEnergy()
        {
            return m_CurrentAmount / m_MaxAmount * 100;
        }
    }
}

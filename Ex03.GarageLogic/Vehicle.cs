using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        private string m_ModelName;
        private string m_LicenseNumber;
        float m_RemainingEnergy;
        Wheel[] m_Wheels;
        
    }
}

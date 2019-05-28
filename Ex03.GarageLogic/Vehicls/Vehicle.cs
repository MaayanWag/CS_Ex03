using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        #region Properties

        private string m_ModelName;
        private string m_LicenseNumber;
        protected Wheel[] m_Wheels;
        protected float m_RemainingEnergy;
        protected eVehicleType m_VehicleType;
        protected Energy m_Energy;

        #endregion

        #region Constructor

        public Vehicle(string i_ModelName, string i_LicenseNumber, Wheel[] i_Wheels, Energy i_Energy, eVehicleType i_VehicleType)
        {
            m_ModelName = i_ModelName;
            m_LicenseNumber = i_LicenseNumber;
            m_Wheels = i_Wheels;
            m_VehicleType = i_VehicleType;
            m_Energy = i_Energy;
        }
        
        #endregion

        #region Getters And Setters
        
        public string ModelName
        {
            get { return m_ModelName; }
        }

        public string LicenceNumber
        {
            get { return m_LicenseNumber; }
        }

        public Wheel[] Wheels
        {
            get { return m_Wheels; }
        }

        public Energy Energy
        {
            get { return m_Energy; }
        }

        public eVehicleType VehicleType
        {
            get { return m_VehicleType; }
            set { m_VehicleType = value;  }
        }

        public float RemainingEnergy
        {
            get { return CalcRemainingEnergy(); }
        }

        #endregion

        #region Methods
        
        #region Abstract Methods

        public abstract float CalcRemainingEnergy();

        #endregion

        #region Object Overide Methods

        public override bool Equals(object obj)
        {
            // TODO: is it the right comparing logic?
            bool isEqual = false;
            Vehicle toCompare = obj as Vehicle;

            if (toCompare != null)
            {
                isEqual = this.LicenceNumber == toCompare.LicenceNumber;
            }

            return isEqual;
        }

        public override int GetHashCode()
        {
            return LicenceNumber.GetHashCode();
        }

        #endregion

        #endregion

        #region To String

        public override string ToString()
        {
            StringBuilder vechileString = new StringBuilder();
            
            vechileString.Append("License number - ");
            vechileString.Append(LicenceNumber);
            vechileString.AppendLine();
            vechileString.Append("Model name - ");
            vechileString.Append(ModelName);
            vechileString.AppendLine();
            vechileString.Append("Remaining energy - ");
            vechileString.Append(RemainingEnergy);
            vechileString.AppendLine();
            vechileString.Append("Wheels Details - ");
            vechileString.AppendLine();
            for (int i = 0; i < m_Wheels.Length; i++)
            {
                vechileString.Append((i + 1) + ". ");
                vechileString.Append(m_Wheels[i].ToString());
                vechileString.AppendLine();
            }

            return vechileString.ToString();
        }

        #endregion
    }
}

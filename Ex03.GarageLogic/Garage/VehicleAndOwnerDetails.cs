using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class VehicleAndOwnerDetails
    {
        #region Properties

        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private Vehicle m_Vehicle;
        private eVehicleState m_OwnerVehicleState = eVehicleState.InRepair;

        #endregion

        #region Constructors

        public VehicleAndOwnerDetails(Vehicle i_Vehicle, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            m_Vehicle = i_Vehicle;
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
        }
   
        #endregion

        #region Getters And Setters

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public string OwnerPhoneNumber
        {
            get { return m_OwnerPhoneNumber; }
            set { m_OwnerPhoneNumber = value; }
        }

        public eVehicleState OwnerVehicleState
        {
            get { return m_OwnerVehicleState; }
            set { m_OwnerVehicleState = value; }
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }
        
        #endregion
    }
}

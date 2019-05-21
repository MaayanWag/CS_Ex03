using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class VehicleAndOwnerDetails
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleState m_OwnerVehicleState;

        public string OwnerName
        {
            set { m_OwnerName = value; }
        }

        public string OwnerPhoneNumber
        {
            set { m_OwnerPhoneNumber = value; }
        }

        public eVehicleState OwnerVehicleState
        {
            set { m_OwnerVehicleState = value; }
        }
    }
}

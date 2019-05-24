using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        #region Properties

        private bool m_ContainDangerousMaterials;
        private float m_CargoVolume;
        private FuelBasedVehicle m_FuelBasedTruck;

        #endregion
        
        #region FuelBased

        #region Constructors

        public Truck(FuelBasedVehicle iFuelBasedTruck, bool i_ContainDangerousMaterials, float i_CargoVolume) :
            base(iFuelBasedTruck.ModelName, iFuelBasedTruck.LicenceNumber, iFuelBasedTruck.Wheels, iFuelBasedTruck.VehicleType)
        {
            m_FuelBasedTruck = iFuelBasedTruck;
            m_ContainDangerousMaterials = i_ContainDangerousMaterials;
            m_CargoVolume = i_CargoVolume;
        }

        #endregion

        #region Getters And Setters

        public float MaxFuelAmount
        {

            get { return m_FuelBasedTruck.MaxFuelAmount; }
        }

        public float CurrentFuelAmount
        {
            get { return m_FuelBasedTruck.CurrentFuelAmount; }
            set { m_FuelBasedTruck.CurrentFuelAmount = value; }
        }

        public eFuelType FuelType
        {
            get { return m_FuelBasedTruck.FuelType; }
        }

        #endregion

        #region Methods

        public void FuelGas(float i_GasAmount, eFuelType i_FuelType)
        {
            if (m_VehicleType == eVehicleType.FuelBased)
            {
                m_FuelBasedTruck.FuelGas(i_GasAmount, i_FuelType);
            }
            else
            {
                // TODO: Throw Exception If needed
                throw new NotImplementedException();
            }
        }

        #endregion

        #endregion FuelBased

        #region Truck

        #region Getters And Setters

        public bool ContainDangerousMaterials
        {
            get { return m_ContainDangerousMaterials; }
        }

        public float CargoVolume
        {
            get { return CargoVolume; }
        }

        #endregion

        #region Methods
        
        public override float CalcRemainingEnergy()
        {
            float remainingEnergy = 0;

            remainingEnergy = m_FuelBasedTruck.CalcRemainingEnergy();

            return remainingEnergy;
        }
    
        #endregion

        #endregion Truck
    }
}

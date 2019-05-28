using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        #region Properties
        
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        #endregion

        #region Constructors

        public Motorcycle(Energy i_Energy, Wheel[] i_Wheels, string i_LicenseNumber,
            eLicenseType i_LicenseType, int i_EngineVolume, string i_ModelName, eVehicleType i_VehicleType)
            : base(i_ModelName, i_LicenseNumber, i_Wheels, i_Energy, i_VehicleType)
        {
            m_LicenseType = i_LicenseType;
            m_EngineVolume = i_EngineVolume;
        }

        #endregion

        #region FuelBased

        #region Getters And Setters

        public float MaxFuelAmount
        {

            get { return m_Energy.MaxAmount; }
        }

        public float CurrentFuelAmount
        {
            get { return m_Energy.CurrentAmount; }
            set { m_Energy.CurrentAmount = value; }
        }

        public eFuelType FuelType
        {
            get
            {
                FuelBasedEnergy energy = m_Energy as FuelBasedEnergy;
                if (energy == null)
                {
                    throw new ArgumentException("This morotcycle is not fuel based!");
                }

                return energy.FuelType;
            }
        }

        #endregion

        #region Methods

        public void FuelGas(float i_GasAmount, eFuelType i_FuelType)
        {
            FuelBasedEnergy energy = m_Energy as FuelBasedEnergy;
            if (energy == null)
            {
                throw new ArgumentException("This morotcycle is not fuel based!");
            }

            energy.FuelGas(i_GasAmount, i_FuelType); ;

        }


        #endregion

        #endregion FuelBased

        #region Electric

        #region Getters And Setters

        public float CurrentBatteryTime
        {
            get { return m_Energy.CurrentAmount; }
            set { m_Energy.CurrentAmount = value; }
        }

        public float MaxBatteryTIme
        {
            get { return m_Energy.MaxAmount; }
        }

        #endregion

        #region Methods

        public void ChargeBattery(float i_ChargingTime)
        {
            ElectricEnergy energy = m_Energy as ElectricEnergy;
            if (energy != null)
            {
                energy.ChargeBattery(i_ChargingTime);
            }
            else
            {
                throw new ArgumentException("This motorcycle is not electric!");
            }
        }

        #endregion

        #endregion Electric

        #region Motorcycle

        #region Getters And Setters

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
        }

        #endregion

        #region Methods

        public override float CalcRemainingEnergy()
        {
            return m_Energy.CalcRemainigEnergy();
        }

        #endregion

        #endregion Motorcycle

        #region To String

        public override string ToString()
        {
            StringBuilder motorcycleString = new StringBuilder();

            motorcycleString.Append(base.ToString());
            motorcycleString.AppendLine();
            motorcycleString.Append(m_Energy.ToString());
            motorcycleString.AppendLine();
            motorcycleString.Append("License type - ");
            motorcycleString.Append(LicenseType);
            motorcycleString.Append(", Engine volume - ");
            motorcycleString.Append(EngineVolume);

            return motorcycleString.ToString();
        }

        #endregion
    }
}

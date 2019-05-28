using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        #region Properties
        private eCarColor m_CarColor;
        private eNumberOfDoors m_NumberOfDoors;

        #endregion

        #region Constructors

        public Car(Energy i_Energy, Wheel[] i_Wheels, eCarColor i_CarColor, eNumberOfDoors i_NumberOfDoors, string i_ModelName,
            string i_LicenseNumber, eVehicleType i_VehicleType ) 
            : base(i_ModelName, i_LicenseNumber, i_Wheels, i_Energy, i_VehicleType)
        {
            m_CarColor = i_CarColor;
            m_NumberOfDoors = i_NumberOfDoors;
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
                    throw new ArgumentException("This car is not fuel based!");
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
                throw new ArgumentException("This car is not fuel based!");
            }

            energy.FuelGas(i_GasAmount, i_FuelType);
            
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
                throw new ArgumentException("This car is not electric!");
            }
        }

        #endregion

        #endregion Electric

        #region Car

        #region Getters And Setters

        public eCarColor CarColor
        {
            get { return m_CarColor; }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get { return m_NumberOfDoors; }
        }

        #endregion

        #region Methods

        public override float CalcRemainingEnergy()
        {
            return m_Energy.CalcRemainigEnergy();
        }

        #endregion

        #endregion Car

        #region To String

        public override string ToString()
        {
            StringBuilder carString = new StringBuilder();

            carString.Append(base.ToString());
            carString.AppendLine();
            carString.Append(m_Energy.ToString());
            carString.AppendLine();
            carString.Append("Car color - ");
            carString.Append(CarColor);
            carString.Append(", Number of doors - ");
            carString.Append(NumberOfDoors);

            return carString.ToString();
        }

        #endregion
    }
}

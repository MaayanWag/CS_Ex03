using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Services;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI.Windows
{
    internal class ChargeBatteryWindow : Window
    {
        private String m_LicenseNumber;
        private float m_BatteryAmount;

        public override void MainWindow()
        {
            Console.Clear();
            showMainMessage();

            // Get license number
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                m_IsInputValid = false;
                getLicenseNumber();
            }
            
            // Get desired fuel amount
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getDesiredBatteryAmount();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            try
            {
                Garage.ChargeVehicle(m_LicenseNumber, m_BatteryAmount);
                Console.WriteLine($"Vehicle charged successfully.");

            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (ValueOutOfRangeException voore)
            {
                Console.WriteLine(voore.Message);
            }

            ReturnToMainWindow();
        }

        private void getDesiredBatteryAmount()
        {
            Console.Write("Please insert battery amount to charge:");
            string fuelAmount = Console.ReadLine();

            try
            {
                m_BatteryAmount = float.Parse(fuelAmount);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{fuelAmount}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getLicenseNumber()
        {
            Console.Write("Please insert vehicle license number: ");
            m_LicenseNumber = Console.ReadLine();
            try
            {
                InputValidations.CheckIfLicenseNumberIsValid(m_LicenseNumber);
                m_IsInputValid = true;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }

        private void showMainMessage()
        {
            StringBuilder mainMsg = new StringBuilder();
            mainMsg.AppendLine("You chose to charge vehicle's battery in the garage.");

            Console.WriteLine(mainMsg.ToString());
        }
    }
}

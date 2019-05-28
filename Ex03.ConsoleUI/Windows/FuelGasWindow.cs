using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Services;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI.Windows
{
    internal class FuelGasWindow : Window
    {
        private String m_LicenseNumber;
        private eFuelType m_FuelType;
        private float m_FuelAmount;

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

            // Get desired fuel type
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getDesiredFuelType();
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

            // Get desired fuel amount
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getDesiredFuelAmount();
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
                Garage.RefuelFuelBasedVehicle(m_LicenseNumber, m_FuelType, m_FuelAmount);
                Console.WriteLine($"Vehicle is refuel successfully.");
                                
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

        private void getDesiredFuelAmount()
        {
            Console.Write("Please insert fuel amount to refuel: ");
            string fuelAmount = Console.ReadLine();

            try
            {
                m_FuelAmount = float.Parse(fuelAmount);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{fuelAmount}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getDesiredFuelType()
        {
            StringBuilder fuelTypeMessage = new StringBuilder();
            fuelTypeMessage.AppendLine("Please choose the fuel type:");
            fuelTypeMessage.AppendLine("Press 1 for Soler");
            fuelTypeMessage.AppendLine("Press 2 for Octan95");
            fuelTypeMessage.AppendLine("Press 3 for Octan96");
            fuelTypeMessage.AppendLine("Press 4 for Octan98");
            fuelTypeMessage.Append("(and then press enter)");
            Console.Write($"{fuelTypeMessage}: ");
            string desiredFuelTypeStr = Console.ReadLine(); ;

            try
            {
                m_FuelType = (eFuelType)Enum.Parse(typeof(eFuelType), desiredFuelTypeStr);
                if (!Enum.IsDefined(typeof(eFuelType), m_FuelType))
                {
                    throw new FormatException($"'{desiredFuelTypeStr}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{desiredFuelTypeStr}' is not a valid input!");
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
            mainMsg.AppendLine("You chose to fuel gas in the garage.");

            Console.WriteLine(mainMsg.ToString());
        }
    }
}

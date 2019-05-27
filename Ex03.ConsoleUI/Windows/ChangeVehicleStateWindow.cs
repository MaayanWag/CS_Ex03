using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI.Windows
{
    internal class ChangeVehicleStateWindow : Window
    {
        private eVehicleState m_DesiredNewVehicleState;
        private string m_LicenseNumber;

        public override void MainWindow()
        {
            
            Console.Clear();
            showMainMessage();
            // Get license number
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getLicenseNumber();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get desired state name
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getDesiredNewState();
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
                Garage.ChangeVehicleState(m_LicenseNumber, m_DesiredNewVehicleState);
                Console.WriteLine($"State changed to {m_DesiredNewVehicleState} successfully");
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            ReturnToMainWindow();
        }

        private void getDesiredNewState()
        {
            Console.Write("Please insert the the requested state P, F or I (and then press Enter): ");
            string desiredStatesStr = Console.ReadLine();;
            char state;

            try
            {
                if (!char.TryParse(desiredStatesStr, out state))
                {
                    throw new FormatException($"'{desiredStatesStr}' is not a valid input!");
                }
                else if (state != 'I' && state != 'F' && state != 'P')
                {
                    throw new ArgumentException($"'{desiredStatesStr}' is not a valid input!");
                }


                m_DesiredNewVehicleState = (eVehicleState)Convert.ToInt32(state);

                if (!Enum.IsDefined(typeof(eVehicleState), m_DesiredNewVehicleState))
                {
                    throw new FormatException($"'{desiredStatesStr}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{desiredStatesStr}' is not a valid input!");
            }
            
            m_IsInputValid = true;
        }

        private void getLicenseNumber()
        {
            Console.Write("Please insert vehicle license number (and then press enter): ");
            m_LicenseNumber = Console.ReadLine();
            try
            {
                InputValidations.CheckIfLicensePlateIsValid(m_LicenseNumber);
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
            mainMsg.AppendLine("You chose to change a vehicle state.");
            mainMsg.AppendLine("You can choose one of 3 options:");
            mainMsg.AppendLine("P - change state to 'Paid'.");
            mainMsg.AppendLine("F - change state to 'Fixed.");
            mainMsg.AppendLine("I - change state to 'In Repair'.");

            Console.WriteLine(mainMsg.ToString());
        }
    }
}

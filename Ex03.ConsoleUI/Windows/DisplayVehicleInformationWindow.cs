using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI.Windows
{
    internal class DisplayVehicleInformationWindow : Window
    {
        private string m_DesiredLicenseNumber;

        public override void MainWindow()
        {
            Console.Clear();
            showMainMessage();

            // Get requested License number
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getDesiredLicenseNumber();
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
                showDesiredVehicleInformation();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            
            ReturnToMainWindow();
        }

        private void showDesiredVehicleInformation()
        {
            string vehicleInformation = Garage.DisplayVehicleInformation(m_DesiredLicenseNumber);
            Console.WriteLine(vehicleInformation);
        }

        private void getDesiredLicenseNumber()
        {
            Console.Write("Please insert vehicle license number: ");
            m_DesiredLicenseNumber = Console.ReadLine();
            try
            {
                InputValidations.CheckIfLicenseNumberIsValid(m_DesiredLicenseNumber);
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
            mainMsg.AppendLine("You chose to view display vehicle information in the garage.");
            
            Console.WriteLine(mainMsg.ToString());
        }
    }
    
}

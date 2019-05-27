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
            //TODO: continue
            Console.Clear();
            showMainMessage();
            // Get requested states
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
            string desiredicenseNumberStr = Console.ReadLine();
            int licenseNumber;

            if (!int.TryParse(desiredicenseNumberStr, out licenseNumber))
            {
                throw new FormatException("This license number should be numbers only");
            }

            m_DesiredLicenseNumber = desiredicenseNumberStr;
            m_IsInputValid = true;
        }

        private void showMainMessage()
        {
            StringBuilder mainMsg = new StringBuilder();
            mainMsg.AppendLine("You chose to view display vehicle information in the garage.");
            mainMsg.AppendLine("Enter the license nubmer of the desired vehicle");

            Console.WriteLine(mainMsg.ToString());
        }
    }
    
}

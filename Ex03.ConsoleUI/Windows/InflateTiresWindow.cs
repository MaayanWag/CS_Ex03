using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI.Windows
{
    internal class InflateTiresWindow : Window
    {
        private string m_VehicleLicensePlate;

        public override void MainWindow()
        {
            // Get Owner name
            Console.Clear();
            Console.WriteLine("You chose to inflate tires of specific car.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getLicenseNumber();
                    Garage.InflateTiresToMaximum(m_VehicleLicensePlate);
                    Console.WriteLine($"Tires been inflated for vehicle with license number '{m_VehicleLicensePlate}'");
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

            ReturnToMainWindow();
        }

        private void getLicenseNumber()
        {
            Console.Write("Please insert vehicle license number: ");
            m_VehicleLicensePlate = Console.ReadLine();
            try
            {
                InputValidations.CheckIfLicenseNumberIsValid(m_VehicleLicensePlate);
                m_IsInputValid = true;
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI.Windows
{
    internal class DisplayLicensePlateWindow : Window
    {
        private List<eVehicleState> m_VehicleDesiredStates = new List<eVehicleState>();

        public override void MainWindow()
        {
            Console.Clear();
            showMainMessage();
            // Get requested states
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getDesiredStates();
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

            List<string> filteredLicensePlate = Garage.GetAllVehicleLicensePlatesByFilter(m_VehicleDesiredStates.ToArray());

            showDesiredStates(filteredLicensePlate);
            ReturnToMainWindow();
        }

        private void showDesiredStates(List<string> i_FilteredLicensePlate)
        {
            if (i_FilteredLicensePlate.Count == 0)
            {
                Console.WriteLine("No vehicles that much your request");
            }
            else
            {
                foreach (string licensePlate in i_FilteredLicensePlate)
                {
                    Console.WriteLine(licensePlate);
                }
            }
        }

        private void getDesiredStates()
        {
            string desiredStatesStr = Console.ReadLine();
            string[] desiredStates =  desiredStatesStr.Split(' ');
            char state;

            foreach (string stateStr in desiredStates)
            {
                try
                {
                    if (!char.TryParse(stateStr, out state))
                    {
                        throw new FormatException($"'{stateStr}' is not a valid input!");
                    }
                    else if (state != 'I' && state != 'F' && state != 'P')
                    {
                        throw new ArgumentException($"'{stateStr}' is not a valid input!");
                    }


                    eVehicleState vehicleState = (eVehicleState) Convert.ToInt32(state);

                    if (!Enum.IsDefined(typeof(eVehicleState), vehicleState))
                    {
                        throw new FormatException($"'{stateStr}' is not a valid input!");
                    }

                    m_VehicleDesiredStates.Add(vehicleState);
                }
                catch (ArgumentException)
                {
                    throw new FormatException($"'{stateStr}' is not a valid input!");
                }
            }

            m_IsInputValid = true;
        }
        
        private void showMainMessage()
        {
            StringBuilder mainMsg = new StringBuilder();
            mainMsg.AppendLine("You chose to view the license plate in the garage.");
            mainMsg.AppendLine("You can filter By 3 Options:");
            mainMsg.AppendLine("P - for all the cars that there Owner already paid for them.");
            mainMsg.AppendLine("F - for all the cars that already fixed.");
            mainMsg.AppendLine("I - for all the cars that currently during repairing.");
            mainMsg.AppendLine("Please insert the the requested states P, F or I (and then press Enter)");

            Console.WriteLine(mainMsg.ToString());
        }
    }
}

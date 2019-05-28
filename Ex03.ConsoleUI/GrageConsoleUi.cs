using System;
using System.Collections.Generic;
using System.Text;
using Ex03.ConsoleUI.Windows;
using GarageMain = Ex03.GarageLogic.GarageMain;

namespace Ex03.ConsoleUI
{
    public static class GarageConsoleUi
    {
        #region Main
        
        public static void MainWindow()
        {
            Console.Clear();
            GarageMain.RunGarageSystem();

            string garageFunctionality = getGarageFunctionalityAsString();
            Console.WriteLine(garageFunctionality);
            eUserInstructions userInstruction = eUserInstructions.Insert;
            bool isUserInstructionIsValid = false;

            while (!isUserInstructionIsValid)
            {
                string userInstructionStr = Console.ReadLine();
                isUserInstructionIsValid = InputValidations.CheckUserInstruction(userInstructionStr, out userInstruction);

                if (!isUserInstructionIsValid)
                {
                    Console.Clear();
                    Console.WriteLine(garageFunctionality);
                    string errMsg = $"'{userInstructionStr}' is not A valid input!";
                    Console.WriteLine(errMsg);
                }
            }

            switch (userInstruction)
            {
                case eUserInstructions.Insert:
                    insertFunctionality();
                    break;
                case eUserInstructions.ChangeVehicleState:
                    changeVehicleStateFunctionality();
                    break;
                case eUserInstructions.ChargeBattery:
                    chargeBatteryFunctionality();
                    break;
                case eUserInstructions.DisplayLicensePlate:
                    displayLicensePlateFunctionality();
                    break;
                case eUserInstructions.DisplayVehicleInformation:
                    displayVehicleInformationFunctionality();
                    break;
                case eUserInstructions.FuelGas:
                    fuelGasFunctionality();
                    break;
                case eUserInstructions.InflateTires:
                    inflateTiresFunctionality();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Instructions Functionality
        

        private static void chargeBatteryFunctionality()
        {
            ChargeBatteryWindow chargeBatteryWindow = new ChargeBatteryWindow();
            chargeBatteryWindow.MainWindow();
        }

        private static void displayLicensePlateFunctionality()
        {
            DisplayLicensePlateWindow displayLicensePlateWindow = new DisplayLicensePlateWindow();
            displayLicensePlateWindow.MainWindow();
        }

        private static void displayVehicleInformationFunctionality()
        {
            DisplayVehicleInformationWindow displayVehicleInformationWindow = new DisplayVehicleInformationWindow();
            displayVehicleInformationWindow.MainWindow();
        }

        private static void fuelGasFunctionality()
        {
            FuelGasWindow fuelGasWindow = new FuelGasWindow();
            fuelGasWindow.MainWindow();
        }

        private static void inflateTiresFunctionality()
        {
            InflateTiresWindow inflateTiresWindow = new InflateTiresWindow();
            inflateTiresWindow.MainWindow();
        }

        private static void changeVehicleStateFunctionality()
        {
            ChangeVehicleStateWindow changeVehicleStateWindow = new ChangeVehicleStateWindow();
            changeVehicleStateWindow.MainWindow();
        }

        private static void insertFunctionality()
        {
            InsertWindow insertWindow = new InsertWindow();
            insertWindow.MainWindow();
        }
        
        #endregion
        
        private static string getGarageFunctionalityAsString()
        {
            StringBuilder garageFunctionality = new StringBuilder();
            welcomeMessage();

            garageFunctionality.Append($"1. To insert a new Vehicle - press 1{Environment.NewLine}");
            garageFunctionality.Append($"2. To display all license plate in the garage by specific state press - 2{Environment.NewLine}");
            garageFunctionality.Append($"3. To change a Vehicle state - press 3{Environment.NewLine}");
            garageFunctionality.Append($"4. To inflate Vehicle tires - press 4{Environment.NewLine}");
            garageFunctionality.Append($"5. To refuel a Fuel based vehicle - press 5{Environment.NewLine}");
            garageFunctionality.Append($"6. To charge an Electric based vehicle - press 6{Environment.NewLine}");
            garageFunctionality.Append($"7. To display vehicle information - press 7{Environment.NewLine}");

            return garageFunctionality.ToString();
        }

        private static void welcomeMessage()
        {
            StringBuilder welcomeMsg = new StringBuilder();

            welcomeMsg.AppendLine("__        __   _                                 ___  ");
            welcomeMsg.AppendLine("\\ \\      / /__| | ___ ___  _ __ ___   ___      {~._.~}");
            welcomeMsg.AppendLine(" \\ \\ /\\ / / _ \\ |/ __/ _ \\| '_ ` _ \\ / _ \\      ( Y )");
            welcomeMsg.AppendLine("  \\ V  V /  __/ | (_| (_) | | | | | |  __/     ()~*~()  ");
            welcomeMsg.AppendLine("   \\_/\\_/ \\___|_|\\___\\___/|_| |_| |_|\\___|     (_)-(_)   ");
            welcomeMsg.AppendLine("");
            welcomeMsg.AppendLine("");
            Console.Write(welcomeMsg.ToString());
        }
    }
}

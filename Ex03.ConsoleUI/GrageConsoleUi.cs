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
        
        public static void StartGarage()
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
                isUserInstructionIsValid = checkUserInstruction(userInstructionStr, out userInstruction);

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

        #region Charge Battery Functionality

        private static void chargeBatteryFunctionality()
        {
            Console.Clear();
            bool isInputValid = false;
            StringBuilder chargeBatteryMsgBuilder = new StringBuilder();

            while (!isInputValid)
            {
                Exception inputException = new Exception();

                try
                {
                    chargeBatteryMsgBuilder.AppendLine("You chose to charge A vehicle battery");
                    chargeBatteryMsgBuilder.AppendLine(
                        "Please insert vehicle license plate and amount of minutes to charge");
                    string chargeBatteryMsg = chargeBatteryMsgBuilder.ToString();

                    Console.WriteLine(chargeBatteryMsg);
                    Console.Write("Vehicle License Plate Number: ");
                    string licensePlateNumberStr = Console.ReadLine();

                    //checkIfLicensePlateIsValid(licensePlateNumberStr);
                    Console.Write("Amount Of Minutes To Charge: ");
                    string amountOfMinutesToChargeStr = Console.ReadLine();

                    if (!isInputValid)
                    {
                        Console.Clear();
                        string errMsg = "";
                        Console.WriteLine(errMsg);
                        throw new NotImplementedException();
                    }
                }
                catch (FormatException fe)
                {
                    inputException = fe;
                }
                catch (ArgumentException ae)
                {
                    inputException = ae;
                }
                catch (Exception ex)
                {
                    inputException = ex;
                }

                if (!isInputValid)
                {
                    Console.Clear();
                    continue;
                }
            }
        }

        private static bool checkIfAmountOfMinutesIsValid(string i_AmountOfMinutesToChargeStr)
        {
            throw new NotImplementedException();
        }

        #endregion

        private static void displayLicensePlateFunctionality()
        {
            throw new NotImplementedException();
        }

        private static void displayVehicleInformationFunctionality()
        {
            throw new NotImplementedException();
        }

        private static void fuelGasFunctionality()
        {
            throw new NotImplementedException();
        }

        private static void inflateTiresFunctionality()
        {
            throw new NotImplementedException();
        }

        private static void changeVehicleStateFunctionality()
        {
            throw new NotImplementedException();
        }

        private static void insertFunctionality()
        {
            InsertWindow insertWindow = new InsertWindow();
            insertWindow.MainWindow();
        }
        

        #endregion

        #region InputValidations

        private static bool checkUserInstruction(string i_UserInstructionStr, out eUserInstructions i_UserInstruction)
        {
            bool isUserInstructionValid = true;
            i_UserInstruction = eUserInstructions.Insert;

            try
            {
                i_UserInstruction = (eUserInstructions)Enum.Parse(typeof(eUserInstructions), i_UserInstructionStr);

                isUserInstructionValid = Enum.IsDefined(typeof(eUserInstructions), i_UserInstruction);

            }
            catch (ArgumentException)
            {
                isUserInstructionValid = false;
            }

            return isUserInstructionValid;
        }

        internal static void CheckIfLicensePlateIsValid(string i_LicensePlateNumber)
        {
            foreach (char digit in i_LicensePlateNumber)
            {
                if (!char.IsDigit(digit))
                {
                    throw new FormatException($"'{i_LicensePlateNumber}' is not a valid input!");
                }
            }
        }
        
        #endregion


        private static string getGarageFunctionalityAsString()
        {
            StringBuilder garageFunctionality = new StringBuilder();

            garageFunctionality.Append($"To insert a new Vehicle - press 1{Environment.NewLine}");
            garageFunctionality.Append($"To display all license plate in the garage by specific state press - 2{Environment.NewLine}");
            garageFunctionality.Append($"To change a Vehicle state - press 3{Environment.NewLine}");
            garageFunctionality.Append($"To inflate Vehicle tires - press 4{Environment.NewLine}");
            garageFunctionality.Append($"To refuel a Fuel based vehicle - press 5{Environment.NewLine}");
            garageFunctionality.Append($"To charge an Electric based vehicle - press 6{Environment.NewLine}");
            garageFunctionality.Append($"To display vehicle information - press 7{Environment.NewLine}");

            return garageFunctionality.ToString();
        }
        
        private static void clearBuilder(StringBuilder value)
        {
            value.Length = 0;
            value.Capacity = 0;
        }
    }
}

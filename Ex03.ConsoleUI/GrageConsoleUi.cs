using System;
using System.Collections.Generic;
using System.Text;
using GarageMain = Ex03.GarageLogic.GarageMain;

namespace Ex03.ConsoleUI
{
    public class GarageConsoleUi
    {
        private const int k_NumberOfInstructions = 7;
        private readonly string[] r_InstructionNames = 
            new string[k_NumberOfInstructions] {};

        public static void StartGarage()
        {
            GarageMain.RunGarageSystem();
            showGarageFunctionality();
            Console.ReadLine();
        }

        private static void showGarageFunctionality()
        {
            StringBuilder garageFunctionality = new StringBuilder();
            garageFunctionality.Append($"For insert press 1{Environment.NewLine}");
            garageFunctionality.Append($"For insert press 1{Environment.NewLine}");
        }
    }
}

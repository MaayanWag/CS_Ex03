using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    internal static class InputValidations
    {
        public static bool ValidateEnum(Type i_EnumType, Enum i_Enum, string i_CheckIfEnum)
        {
            bool v_IsValidEnum = true;

            try
            {
                if (!Enum.IsDefined(i_EnumType, i_Enum))
                {
                    throw new FormatException($"'{i_CheckIfEnum}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{i_CheckIfEnum}' is not a valid input!");
            }

           return v_IsValidEnum;
        }

        public static bool CheckUserInstruction(string i_UserInstructionStr, out eUserInstructions i_UserInstruction)
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

        public static void CheckIfLicensePlateIsValid(string i_LicensePlateNumber)
        {
            foreach (char licenseDigit in i_LicensePlateNumber)
            {
                if (!char.IsDigit(licenseDigit) && !char.IsLetter(licenseDigit))
                {
                    throw new FormatException($"'{i_LicensePlateNumber}' is not a valid input!");
                }
            }
        }
    }
}

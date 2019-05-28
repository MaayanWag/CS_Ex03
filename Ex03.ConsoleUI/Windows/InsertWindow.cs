using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Services;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI.Windows
{
    internal class InsertWindow : Window
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private string m_ModelName;
        private string m_LicenseNumber;
        private string m_WheelManufacturer;
        private eVehicleType m_VehicleType;
        private eElectricVehicleOptions m_ElectricVehicleOptions;
        private eFuelBasedOptions m_FuelBasedVehicleOptions;
        private eCarColor m_CarColor;
        private eNumberOfDoors m_CarNumberOfDoors;
        private eLicenseType m_MotorcycleLicenseType;
        private eFuelType m_FuelType;
        private bool m_IsContainsDangerousMaterials;
        private int m_MotorcycleEngineVolume;
        private int m_TruckCargoVolume;
        private float m_WheelMaxAirPressure;
        private float m_WheelCurrentAirPressure;
        private float m_CurrentBatteryTimeAmount;
        private float m_MaxBatteryTimeAmount;
        private float m_MaxFuelAmount;
        private float m_CurrentFuelAmount;
        private Wheel[] m_Wheels;
        
        public override void MainWindow()
        {
            // Get Owner name
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getOwnerName();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get Oner phone number
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getOwnerPhoneNumber();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get Model Name
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                getModelName();
            }

            // Get license number
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
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

            // get Wheel Manufacturer
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                m_IsInputValid = false;
                getWheelManufacturer();
            }
            
            // Get current Air pressure
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getWheelCurrentAirPressure();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get max Air pressure
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getWheelMaxAirPressure();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get vehicle type
            Console.Clear();
            Console.WriteLine("You chose to insert a new Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getVehicleType();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Split to each  vehcile type
            switch (m_VehicleType)
            {
                case eVehicleType.Electric:
                    insertElectricWindow();
                    break;
                case eVehicleType.FuelBased:
                    insertFuelBasedWindow();
                    break;
            }

            ReturnToMainWindow();
        }

        private void getOwnerPhoneNumber()
        {
            Console.Write("Please insert owner phone number: ");
            m_OwnerPhoneNumber = Console.ReadLine();
            foreach(char digit in m_OwnerPhoneNumber)
            {
                if (!char.IsDigit(digit))
                {
                    throw new FormatException($"'{m_OwnerPhoneNumber}' is not a valid input");
                }
            }
            m_IsInputValid = true;
        }

        private void getOwnerName()
        {
            Console.Write("Please insert owner name: ");
            m_OwnerName = Console.ReadLine();
            foreach(char letter in m_OwnerName)
            {
                if (!char.IsLetter(letter) && !char.IsSeparator(letter))
                {
                    throw new FormatException($"'{m_OwnerName}' is not a valid input!");
                }
            }
            m_IsInputValid = true;
        }

        private void insertFuelBasedWindow()
        {
            Console.Clear();
            Console.WriteLine("You chose to insert a new fuel based Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getFuelType();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get current fuel amount
            Console.Clear();
            Console.WriteLine("You chose to insert a new fuel based Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getFuelCurrentAmount();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get max fuel amount
            Console.Clear();
            Console.WriteLine("You chose to insert a new fuel based Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getFuelMaxAmount();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get Fuel Based Vehicle Fuel Type
            Console.Clear();
            Console.WriteLine("You chose to insert a new fuel based Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getFuelBasedVehicleClass();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            switch (m_FuelBasedVehicleOptions)
            {
                case eFuelBasedOptions.Car:
                    insertCarWindow();
                    break;
                case eFuelBasedOptions.Motorcycle:
                    insertMotorcycleWindow();
                    break;
                case eFuelBasedOptions.Truck:
                    insertTruckWindow();
                    break;
            }
        }

        private void getFuelCurrentAmount()
        {
            Console.Write("Please insert the current fuel amount: ");
            string currentFuelAmount = Console.ReadLine();

            try
            {
               m_CurrentFuelAmount = float.Parse(currentFuelAmount);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{currentFuelAmount}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getFuelMaxAmount()
        {
            Console.Write("Please insert the maximum fuel amount: ");
            string maxFuelAmount = Console.ReadLine();

            try
            {
                m_MaxFuelAmount = float.Parse(maxFuelAmount);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{m_MaxFuelAmount}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getFuelType()
        {
            StringBuilder fuelType = new StringBuilder();
            fuelType.AppendLine("Please choose the fuel type:");
            fuelType.AppendLine("Press 1 for Soler");
            fuelType.AppendLine("Press 2 for Octan95");
            fuelType.AppendLine("Press 3 for Octan96");
            fuelType.AppendLine("Press 4 for Octan98");
            fuelType.Append("(and then press enter)");
            Console.Write($"{fuelType}: ");
            string fuelTypeStr = Console.ReadLine();

            try
            {
                m_FuelType = (eFuelType)Enum.Parse(typeof(eFuelType), fuelTypeStr);
                if (!Enum.IsDefined(typeof(eFuelType), m_FuelType))
                {
                    throw new FormatException($"'{fuelTypeStr}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{fuelTypeStr}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void insertElectricWindow()
        {
            // Get Electric Current battery amount
            Console.Clear();
            Console.WriteLine("You chose to insert a new electric based Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getCurrentBatteryAmount();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get Electric Max battery amount
            Console.Clear();
            Console.WriteLine("You chose to insert a new electric based Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getMaxBatteryAmount();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get Electric Based Vehicle Class
            Console.Clear();
            Console.WriteLine("You chose to insert a new electric based Vehicle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getElectricBasedVehicleClass();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            switch (m_ElectricVehicleOptions)
            {
                case eElectricVehicleOptions.Car:
                    insertCarWindow();
                    break;
                case eElectricVehicleOptions.Motorcycle:
                    insertMotorcycleWindow();
                    break;
            }
        }

        private void getCurrentBatteryAmount()
        {
            Console.Write("Please insert Current battery time: ");
            string currentBatteryAmount = Console.ReadLine();

            try
            {
                m_CurrentBatteryTimeAmount = float.Parse(currentBatteryAmount);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{currentBatteryAmount}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getMaxBatteryAmount()
        {
            Console.Write("Please insert Max battery time: ");
            string maxBatteryAmount = Console.ReadLine();

            try
            {
                m_MaxBatteryTimeAmount = float.Parse(maxBatteryAmount);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{maxBatteryAmount}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void insertTruckWindow()
        {
            // Get truck Contain Dangerous Materials status
            Console.Clear();
            Console.WriteLine("You chose to insert a new Truck.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getTruckContainDangerousMaterialsStatus();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get motorcycle cargoVolume volume
            Console.Clear();
            Console.WriteLine("You chose to insert a new Truck.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getTruckCargoVolume();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            try
            {
                createNewTruck();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (ValueOutOfRangeException voore)
            {
                Console.WriteLine(voore.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }

            // ReturnToMainWindow();
        }

        private void createNewTruck()
        {
                m_Wheels = GarageMain.CreateWheels(m_WheelManufacturer, m_WheelMaxAirPressure,
                    m_WheelCurrentAirPressure, 12);
                FuelBasedEnergy fuelBasedEnergy =
                    GarageMain.CreateFuelBasedEnergy(m_FuelType, m_MaxFuelAmount, m_CurrentFuelAmount);
                Truck newTruck = GarageMain.CreateTruck(fuelBasedEnergy, m_Wheels, m_LicenseNumber, m_ModelName,
                    m_IsContainsDangerousMaterials, m_TruckCargoVolume);
                Garage.AddNewVehicle(newTruck, m_OwnerName, m_OwnerPhoneNumber);
                vehicleAddedSuccessfullyMessage();
        }

        private void insertMotorcycleWindow()
        {
            // Get motorcycle license type
            Console.Clear();
            Console.WriteLine("You chose to insert a new Motorcycle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getMotorcycleLicenseType();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get motorcycle engine volume
            Console.Clear();
            Console.WriteLine("You chose to insert a new Motorcycle.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getMotorCycleEngineVolume();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            try
            {
                createNewMotorcycle();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (ValueOutOfRangeException voore)
            {
                Console.WriteLine(voore.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }

        private void createNewMotorcycle()
        {
            m_Wheels = GarageMain.CreateWheels(m_WheelManufacturer, m_WheelMaxAirPressure, m_WheelCurrentAirPressure,
                2);
            Motorcycle newMotorcycle = null;

            if (m_VehicleType == eVehicleType.FuelBased)
            {
                FuelBasedEnergy fuelBasedEnergy =
                    GarageMain.CreateFuelBasedEnergy(m_FuelType, m_MaxFuelAmount, m_CurrentFuelAmount);
                newMotorcycle = GarageMain.CreateMotorcycle(fuelBasedEnergy, m_Wheels, m_LicenseNumber,
                    m_ModelName, m_MotorcycleLicenseType, m_MotorcycleEngineVolume);
            }

            if (m_VehicleType == eVehicleType.Electric)
            {
                ElectricEnergy electricEnergy =
                    GarageMain.CreateElectricEnergy(m_MaxBatteryTimeAmount, m_CurrentBatteryTimeAmount);
                newMotorcycle = GarageMain.CreateMotorcycle(electricEnergy, m_Wheels, m_LicenseNumber, m_ModelName,
                    m_MotorcycleLicenseType, m_MotorcycleEngineVolume);

            }

            Garage.AddNewVehicle(newMotorcycle, m_OwnerName, m_OwnerPhoneNumber);
            vehicleAddedSuccessfullyMessage();

        }

        private void insertCarWindow()
        {
            // Get car color
            Console.Clear();
            Console.WriteLine("You chose to insert a Car.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getCarColor();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            // Get car number od doors
            Console.Clear();
            Console.WriteLine("You chose to insert a new Car.");
            m_IsInputValid = false;
            while (!m_IsInputValid)
            {
                try
                {
                    m_IsInputValid = false;
                    getCarNumberOfDoors();
                }
                catch (FormatException fe)
                {
                    Console.WriteLine(fe.Message);
                }
            }

            try
            {
                createNewCar();
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (ValueOutOfRangeException voore)
            {
                Console.WriteLine(voore.Message);
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
        }

        private void createNewCar()
        {
            m_Wheels = GarageMain.CreateWheels(m_WheelManufacturer, m_WheelMaxAirPressure, m_WheelCurrentAirPressure,
                4);
            Car newCar = null;

            if (m_VehicleType == eVehicleType.FuelBased)
            {
                FuelBasedEnergy fuelBasedEnergy =
                    GarageMain.CreateFuelBasedEnergy(m_FuelType, m_MaxFuelAmount, m_CurrentFuelAmount);

                newCar = GarageMain.CreateCar(fuelBasedEnergy, m_Wheels, m_LicenseNumber, m_ModelName,
                    m_CarColor, m_CarNumberOfDoors);
            }

            if (m_VehicleType == eVehicleType.Electric)
            {
                ElectricEnergy electricEnergy =
                    GarageMain.CreateElectricEnergy(m_MaxBatteryTimeAmount, m_CurrentBatteryTimeAmount);

                newCar = GarageMain.CreateCar(electricEnergy, m_Wheels, m_LicenseNumber, m_ModelName,
                    m_CarColor, m_CarNumberOfDoors);
            }

            Garage.AddNewVehicle(newCar, m_OwnerName, m_OwnerPhoneNumber);
            vehicleAddedSuccessfullyMessage();
        }

        private void vehicleAddedSuccessfullyMessage()
        {
            Console.Clear();
            Console.WriteLine($"Vehicle with license number '{m_LicenseNumber}' added successfully :){Environment.NewLine}");
        }

        private void getTruckCargoVolume()
        {
            Console.Write("Please insert truck cargo volume: ");
            string truckCargoVolume = Console.ReadLine();

            try
            {
                m_TruckCargoVolume = int.Parse(truckCargoVolume);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{truckCargoVolume}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getTruckContainDangerousMaterialsStatus()
        {
            Console.Write("Please insert if truck contains dangerous materials <True, False>(and then press enter): ");
            string isContainsDangerousMaterials = Console.ReadLine();

            try
            {
                m_IsContainsDangerousMaterials = bool.Parse(isContainsDangerousMaterials);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{isContainsDangerousMaterials}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getMotorCycleEngineVolume()
        {
            Console.Write("Please insert Motorcycle engine volume: ");
            string motorcycleEngineVolume = Console.ReadLine();

            try
            {
                m_MotorcycleEngineVolume = int.Parse(motorcycleEngineVolume);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{motorcycleEngineVolume}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getMotorcycleLicenseType()
        {
            StringBuilder licenseType = new StringBuilder();
            licenseType.AppendLine("Please choose the Motorcycle license type");
            licenseType.AppendLine("Press 1 for A");
            licenseType.AppendLine("Press 2 for A1");
            licenseType.AppendLine("Press 3 for A2");
            licenseType.AppendLine("Press 4 for B");
            licenseType.AppendLine("(and then press enter)");
            Console.WriteLine($"{licenseType}: ");
            string motorCycleLicenseType = Console.ReadLine();

            try
            {
                m_MotorcycleLicenseType = (eLicenseType) Enum.Parse(typeof(eLicenseType), motorCycleLicenseType);
                if (!Enum.IsDefined(typeof(eLicenseType), m_MotorcycleLicenseType))
                {
                    throw new FormatException($"'{motorCycleLicenseType}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{motorCycleLicenseType}' is not a valid input!");
            }

            m_IsInputValid = true;
        }
        
        private void getCarNumberOfDoors()
        {
            Console.Write("Please insert the number of Car doors <2-5>: ");
            string carNumberOfDoors = Console.ReadLine();

            try
            {
                m_CarNumberOfDoors = (eNumberOfDoors) Enum.Parse(typeof(eNumberOfDoors), carNumberOfDoors);
                if (!Enum.IsDefined(typeof(eNumberOfDoors), m_CarNumberOfDoors))
                {
                    throw new FormatException($"'{carNumberOfDoors}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{carNumberOfDoors}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getCarColor()
        {
            StringBuilder carColorNumber = new StringBuilder();
            carColorNumber.AppendLine("Please choose the Car color");
            carColorNumber.AppendLine("Press 1 for Red");
            carColorNumber.AppendLine("Press 2 for Blue");
            carColorNumber.AppendLine("Press 3 for Black");
            carColorNumber.AppendLine("Press 4 for Gray");
            carColorNumber.AppendLine("(and then press enter)");
            Console.WriteLine($"{carColorNumber}: ");
            string carColor = Console.ReadLine();

            try
            {
                m_CarColor = (eCarColor) Enum.Parse(typeof(eCarColor), carColor);
                if (!Enum.IsDefined(typeof(eCarColor), m_CarColor))
                {
                    throw new FormatException($"'{carColor}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{carColor}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getFuelBasedVehicleClass()
        {
            Console.WriteLine("Please select the desired vehicle: ");
            Console.WriteLine("1 for Car");
            Console.WriteLine("2 for Motorcycle");
            Console.WriteLine("3 for Truck");
            string vheicleClass = Console.ReadLine();

            try
            {
                m_FuelBasedVehicleOptions = (eFuelBasedOptions) Enum.Parse(typeof(eFuelBasedOptions), vheicleClass);
                if (!Enum.IsDefined(typeof(eFuelBasedOptions), m_FuelBasedVehicleOptions))
                {
                    throw new FormatException($"'{vheicleClass}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{vheicleClass}' is not a valid input!");
            }

            m_IsInputValid = true;
        }
        
        private void getElectricBasedVehicleClass()
        {
            Console.Write("Please insert 1 for Car OR 2 for Motorcycle: ");
            string vheicleClass = Console.ReadLine();

            try
            {
                m_ElectricVehicleOptions = (eElectricVehicleOptions) Enum.Parse(typeof(eElectricVehicleOptions), vheicleClass);
                if (!Enum.IsDefined(typeof(eElectricVehicleOptions), m_ElectricVehicleOptions))
                {
                    throw new FormatException($"'{vheicleClass}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{vheicleClass}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getVehicleType()
        {
            Console.Write("Please insert 1 for electric vehicle OR 2 for fuel based vehicle: ");
            string vheicleType = Console.ReadLine();

            try
            {
                m_VehicleType = (eVehicleType)Enum.Parse(typeof(eVehicleType), vheicleType);
                if (!Enum.IsDefined(typeof(eVehicleType), m_VehicleType))
                {
                    throw new FormatException($"'{vheicleType}' is not a valid input!");
                }
            }
            catch (ArgumentException)
            {
                throw new FormatException($"'{vheicleType}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getWheelMaxAirPressure()
        {
            Console.Write("Please insert vehicle wheel manufacturer max air pressure: ");
            string wheelMaxAirPressure = Console.ReadLine();

            try
            {
                m_WheelMaxAirPressure = float.Parse(wheelMaxAirPressure);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{wheelMaxAirPressure}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getWheelCurrentAirPressure()
        {
            Console.Write("Please insert vehicle wheel manufacturer current air pressure: ");
            string wheelCurrentAirPressure = Console.ReadLine();

            try
            {
                m_WheelCurrentAirPressure = float.Parse(wheelCurrentAirPressure);
            }
            catch (FormatException)
            {
                throw new FormatException($"'{wheelCurrentAirPressure}' is not a valid input!");
            }

            m_IsInputValid = true;
        }

        private void getWheelManufacturer()
        {
            Console.Write("Please insert vehicle wheel manufacturer: ");
            m_WheelManufacturer = Console.ReadLine();
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

        private void getModelName()
        {
            Console.Write("Please insert vehicle model name: ");
            m_ModelName = Console.ReadLine();
            m_IsInputValid = true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;


namespace Ex03.ConsoleUI.Windows
{
    internal abstract class Window
    {
        protected bool m_IsInputValid = false;

        public abstract void MainWindow();

        public virtual void ReturnToMainWindow()
        {
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            GarageConsoleUi.MainWindow();
        }
    }
}

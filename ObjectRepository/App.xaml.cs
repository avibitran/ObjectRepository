using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace ObjectRepository
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        string original_file;
        string temp_file;

        void App_Startup(object sender, StartupEventArgs e)
        {
            string xmlFilePath;

            // Application is running
            // Process command line args
            xmlFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); //@"C:\Users\avib\Dropbox\Projects\Ab.UnitTestFramework\Ab.UnitTestFramework.Generic\MapGenerator\UIMap.xml";
            xmlFilePath = xmlFilePath + @"\UIMap.xml";

            //if (e.Args.Length == 0)
            //    throw new ApplicationException("the application started with no arguments.");

            //xmlFilePath = e.Args[0];
            original_file = xmlFilePath;
            temp_file = xmlFilePath.Replace(Path.GetExtension(xmlFilePath), "_tmp" + Path.GetExtension(xmlFilePath));

            File.Copy(xmlFilePath, temp_file, true);

            if (!File.Exists(temp_file))
                throw new ApplicationException("the application could not find the specified file.");

            // Create main application window, starting minimized if specified
            MainWindow mainWindow = new MainWindow(temp_file);
            mainWindow.Show();
        }
    }
}

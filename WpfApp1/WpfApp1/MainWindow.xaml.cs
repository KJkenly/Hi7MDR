using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using System.Diagnostics;
using System.Xml.Linq;
using System.IO;
using Path = System.IO.Path;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckForUpdates_Click(object sender, RoutedEventArgs e)
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            //MessageBox.Show(fileVersionInfo.FileVersion);
            string profileFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Properties", "PublishProfiles", "ClickOnceProfile.pubxml");

            if (File.Exists(profileFilePath))
            {
                XElement root = XElement.Load(profileFilePath);

                XNamespace ns = root.GetDefaultNamespace();
                string applicationVersion = root.Element(ns + "PropertyGroup")?.Element(ns + "ApplicationVersion")?.Value;
                string updateEnabled = root.Element(ns + "PropertyGroup")?.Element(ns + "UpdateEnabled")?.Value;

                // ทำสิ่งที่ต้องการด้วย applicationVersion และ updateEnabled
            }
            else
            {
                // ไม่พบไฟล์ ClickOnceProfile.pubxml
            }
        }
    }
}

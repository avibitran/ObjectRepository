using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml;
using System.Xml.Linq;
using Ab.Wpf.Controls;

namespace ObjectRepository
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : CustomMainWindow
    {
        #region Members
        private string _filePath;
        #endregion

        #region Ctor
        public MainWindow(string filePath)
            : base()
        {
            _filePath = filePath;
            InitializeComponent();

            LoadFile(filePath);

        }
        #endregion

        #region Methods
        private void LoadFile(string path)
        {
            XmlDocument doc;

            XmlDataProvider dataProvider = this.FindResource("xmlDataProvider") as XmlDataProvider;
            if(dataProvider != null)
            {

                doc = new XmlDocument();
                doc.Load(path);

                dataProvider.Document = doc;
            }
        }

        #region Handling Events
        private void trvItems_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            XmlElement element = e.NewValue as XmlElement;

            if(element.LocalName.Equals("Browser"))
            {
                this.grdProperties.SelectedObject = new Browser() 
                { 
                    Name = "Browser", 
                    DriverType = (DriverType)Enum.Parse(typeof(DriverType), element.Attributes["driver"].Value),
                };
            }
            else if(element.LocalName.Equals("Page"))
            {
                this.grdProperties.SelectedObject = new Ab.Wpf.Controls.Page() 
                {
                    Name = element.Attributes["name"].Value,
                    Url = element.Attributes["url"].Value,
                };
            }
            else
            {
                string identificationMethod, identificationValue;

                if(element.Attributes["xsi:type"].Value.Equals("Simple"))
                {
                    identificationMethod = element.SelectSingleNode("./Identification/IdentificationMethod").InnerText;
                    identificationValue = element.SelectSingleNode("./Identification/Value").InnerText;

                    this.grdProperties.SelectedObject = new WebObject()
                    {
                        Name = element.Attributes["name"].Value,
                        Type = (ObjectTypes)Enum.Parse(typeof(ObjectTypes), element.Attributes["webElementType"].Value),
                        External = (element.Attributes["externalize"] == null) ? false : Convert.ToBoolean(element.Attributes["externalize"].Value),
                        Description = (element.Attributes["description"] == null) ? "" : element.Attributes["description"].Value,
                        IdentificationMethod = (Identification.MethodType)Enum.Parse(typeof(Identification.MethodType), identificationMethod),
                        Expression = identificationValue,
                    };
                }
                else
                {
                    identificationMethod = element.SelectSingleNode("./Identification/IdentificationMethod").InnerText;
                    identificationValue = element.SelectSingleNode("./Identification/Value").InnerText;

                    this.grdProperties.SelectedObject = new WebObjectCollection()
                    {
                        Name = element.Attributes["name"].Value,
                        Type = (ObjectTypes)Enum.Parse(typeof(ObjectTypes), element.Attributes["webElementType"].Value),
                        External = (element.Attributes["externalize"] == null) ? false : Convert.ToBoolean(element.Attributes["externalize"].Value),
                        Description = (element.Attributes["description"] == null) ? "" : element.Attributes["description"].Value,
                        IdentificationMethod = (Identification.MethodType)Enum.Parse(typeof(Identification.MethodType), identificationMethod),
                        Expression = identificationValue,
                    };
                }
            }
            //this.grdProperties.SelectedObject = e.NewValue;
        }

        #endregion
        #endregion

        #region Fields
        public string FilePath
        {
            get { return _filePath; }
        }
        #endregion

        private void grdProperties_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            
        }
    }
}

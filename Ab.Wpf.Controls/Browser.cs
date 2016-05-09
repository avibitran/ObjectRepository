using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab.Wpf.Controls
{
    public class Browser
        : INotifyPropertyChanged, IWebObject
    {
        #region Members
        private string _name;
        private DriverType _type;
        #endregion

        #region Fields
        [Category("Misc")]
        [DisplayName("Name"), ReadOnly(true), Browsable(true)]
        [Description("the name of the browser.")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Category("Misc")]
        [DisplayName("Driver")]
        [Description("the type of driver to use.")]
        public DriverType DriverType
        {
            get { return _type; }
            set 
            { 
                _type = value;
                NotifyPropertyChanged("Type");
            }
        }

        public ObjectTypes Type
        {
            get { return ObjectTypes.Browser; }
        }

        [Category("Misc")]
        [DisplayName("Type"), ReadOnly(true), Browsable(true)]
        [Description("the type of the element.")]
        public string TypeAsString
        {
            get { return "Browser"; }
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        #endregion
    }
}

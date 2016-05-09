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
            set
            {
                string oldValue = _name;
                _name = value;
                OnPropertyChanged("Name", value, oldValue);
            }
        }

        [Category("Misc")]
        [DisplayName("Driver")]
        [Description("the type of driver to use.")]
        public DriverType DriverType
        {
            get { return _type; }
            set
            {
                DriverType oldValue = _type;
                _type = value;
                OnPropertyChanged("DriverType", value, oldValue);
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

        protected void OnPropertyChanged<T>(string propertyName, T oldValue, T newValue)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs<T>(propertyName, oldValue, newValue));
        }
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ab.Wpf.Controls
{
    public interface IWebObject
    {
        string Name { get; set; }
        string TypeAsString { get; }
        ObjectTypes Type { get; }
        
        event PropertyChangedEventHandler PropertyChanged;
    }

    public interface IWebObjectElement
    {
        string Description { get; set; }
        bool External { get; set; }
        Identification.MethodType IdentificationMethod { get; set; }
        string Expression { get; set; }
    }

    public abstract class WebObjectBase
        : IWebObjectElement, IWebObject, INotifyPropertyChanged
    {
        #region Members
        private string _name;
        private string _description;
        private bool _external;
        private Identification _identification = new Identification();
        #endregion

        #region Fields
        [Category("Misc")]
        [DisplayName("Name")]
        [Description("A unique name to identify the element.")]
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

        public abstract ObjectTypes Type
        { 
            get; 
            set; 
        }

        public abstract string TypeAsString { get; }

        [Category("Misc")]
        [DisplayName("Description")]
        [Description("A description for the element.")]
        public string Description
        {
            get { return _description; }
            set 
            {
                string oldValue = _description;
                _description = value;
                OnPropertyChanged("Description", value, oldValue);
            }
        }

        [Category("Advanced")]
        [DisplayName("External")]
        [Description("if this element will have a proeprty in the page class for quick access, true, else false.")]
        public bool External
        {
            get { return _external; }
            set 
            {
                bool oldValue = _external;
                _external = value;
                OnPropertyChanged("External", value, oldValue);
            }
        }

        [Category("Identification")]
        [DisplayName("Method")]
        [Description("The method that should be used to identify the object.")]
        public Identification.MethodType IdentificationMethod
        {
            get { return _identification.Type; }
            set
            {
                Identification.MethodType oldValue = _identification.Type;
                _identification.Type = value;
                OnPropertyChanged("IdentificationMethod", value, oldValue);
            }
        }

        [Category("Identification")]
        [DisplayName("Expression")]
        [Description("The method that should be used to identify the object.")]
        public string Expression
        {
            get { return _identification.Value; }
            set
            {
                string oldValue = _identification.Value;
                _identification.Value = value;
                OnPropertyChanged("Expression", value, oldValue);
            }
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

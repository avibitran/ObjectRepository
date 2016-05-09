using System;
using System.Collections.Generic;
//using System.;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Ab.Wpf.Controls
{
    public interface IWebObject
        : INotifyPropertyChanged
    {
        string Name { get; set; }
        string TypeAsString { get; }
        ObjectTypes Type { get; }
    }

    public interface IWebObjectElement
    {
        string Description { get; set; }
        bool External { get; set; }
        Identification.MethodType IdentificationMethod { get; set; }
        string Expression { get; set; }
    }

    public abstract class WebObjectBase
        : IWebObjectElement, IWebObject
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
                string oldValue;

                oldValue = _name;
                _name = value;
                NotifyPropertyChanged("Name", oldValue, _name);
            }
        }

        [Category("Misc")]
        [DisplayName("Description")]
        [Description("A description for the element.")]
        public string Description
        {
            get { return _description; }
            set
            {
                string oldValue;

                oldValue = _description;
                _description = value;
                NotifyPropertyChanged("Description", oldValue, _description);
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
                bool oldValue;

                oldValue = _external;
                _external = value;
                NotifyPropertyChanged("External", oldValue, _external);
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
                Identification.MethodType oldValue;

                oldValue = _identification.Type;
                _identification.Type = value;
                NotifyPropertyChanged("IdentificationMethod", oldValue, _identification.Type);
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
                string oldValue;

                oldValue = _identification.Value;
                _identification.Value = value;
                NotifyPropertyChanged("Expression", oldValue, _identification.Value);
            }
        }

        public abstract ObjectTypes Type
        {
            get;
            set;
        }

        public abstract string TypeAsString { get; }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged<T>(string propertyName, T oldvalue, T newvalue)
        {
            OnPropertyChanged(this, new PropertyChangedEventArgs<T>(propertyName, oldvalue, newvalue));
        }

        public virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(sender, e);
        }
    }
}

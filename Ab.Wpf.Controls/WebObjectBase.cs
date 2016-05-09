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

    public class PropertyChangedEventArgs
        : RoutedEventArgs
    {
        public PropertyChangedEventArgs()
        { }

        public PropertyChangedEventArgs(object target, string propertyName, string newValue, string oldValue)
        {
            this.PropertyName = propertyName;
            this.OldValue = oldValue;
            this.NewValue = newValue;
            this.Target = target;
        }

        public string PropertyName;
        public string OldValue;
        public string NewValue;
        public object Target;
    }

    public abstract class WebObjectBase
        : UIElement, IWebObjectElement, IWebObject // , INotifyPropertyChanged
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
            get { return (string)GetValue(NameProperty); }
            set 
            {
                SetValue(NameProperty, value);
                //string oldValue = _name;
                //_name = value;
                ////NotifyPropertyChanged("Name");
                //RaiseNamePropertyChanged(value, oldValue);
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
                _description = value;
                //NotifyPropertyChanged("Description");
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
                _external = value;
                //NotifyPropertyChanged("External");
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
                _identification.Type = value;
                //NotifyPropertyChanged("IdentificationMethod");
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
                _identification.Value = value;
                //NotifyPropertyChanged("Expression");
            }
        }
        #endregion

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(object), typeof(WebObjectBase),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, NamePropertyChanged));

        private static void NamePropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            WebObjectBase sender = source as WebObjectBase;
            RaiseNamePropertyChanged((UIElement)source, (string)e.NewValue, (string)e.OldValue);
        }

        /// <summary>
        /// A helper method to raise the AnimationStarted event.
        /// </summary>
        protected RoutedEventArgs RaiseNamePropertyChanged(string newValue, string oldValue)
        {
            return RaiseNamePropertyChanged((UIElement)this, newValue, oldValue);
        }

        internal static RoutedEventArgs RaiseNamePropertyChanged(UIElement target, string newValue, string oldValue)
        {
            if (target == null) return null;

            PropertyChangedEventArgs args = new PropertyChangedEventArgs(target, "Name", newValue, oldValue);

            RaiseEvent(target, args);
            return args;
        }

        private static void RaiseEvent(DependencyObject target, RoutedEventArgs args)
        {
            if (target is UIElement)
            {
                (target as UIElement).RaiseEvent(args);
            }
            else if (target is ContentElement)
            {
                (target as ContentElement).RaiseEvent(args);
            }
        }


        //#region INotifyPropertyChanged Members
        //public event PropertyChangedEventHandler PropertyChanged;

        //protected void NotifyPropertyChanged(String info)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(info));
        //    }
        //}
        //#endregion
    }
}

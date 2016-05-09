using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab.Wpf.Controls
{
    public class Page
        : INotifyPropertyChanged, IWebObject
    {
        #region Members
        private string _name;
        private Uri _uri;
        #endregion

        #region Fields
        [Category("Misc")]
        [DisplayName("Name"), ReadOnly(true), Browsable(true)]
        [Description("A unique name to identify the element.")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Category("Misc")]
        [DisplayName("Url"), ReadOnly(true), Browsable(true)]
        [Description("The relative url of the page.")]
        public string Url
        {
            get { return _uri.ToString(); }
            set { _uri = new Uri(value, UriKind.Relative); }
        }

        public ObjectTypes Type
        {
            get { return ObjectTypes.Page; }
        }

        [Category("Misc")]
        [DisplayName("Type")]
        [Description("the type of the element.")]
        public string TypeAsString
        {
            get { return "Page"; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab.Wpf.Controls
{
    public class Identification
    {
        #region Members
        private string _value;
        private MethodType _type;
        #endregion

        #region Fields
        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public MethodType Type
        {
            get { return _type; }
            set { _type = value; }
        }
        #endregion

        #region Internal Classes
        public enum MethodType
        {
            ClassName,
            CssSelector,
            Id,
            LinkText,
            Name,
            PartialLinkText,
            TagName,
            XPath
        }
        #endregion
    }
}

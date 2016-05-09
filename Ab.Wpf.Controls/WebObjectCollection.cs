using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab.Wpf.Controls
{
    public class WebObjectCollection
        : WebObjectBase
    {
        #region Members
        private ObjectTypes _type;
        #endregion

        #region Fields
        public override ObjectTypes Type
        {
            get { return _type; }
            set
            {
                if (((int)value >= 200) && ((int)value < 300))
                {
                    ObjectTypes oldValue;

                    oldValue = _type;
                    _type = value;
                    base.NotifyPropertyChanged("Type", oldValue, _type);
                }
                else
                    throw new ArgumentOutOfRangeException("the given value is not allowed for this class.");
            }
        }

        [Category("Misc")]
        [DisplayName("Type")]
        [Description("the type of the element.")]
        public override string TypeAsString
        {
            get { return Enum.GetName(typeof(ObjectTypes), _type); }
        }
        #endregion

        //#region Internal Classes

        //public enum ObjectType
        //{
        //    TabCollectionElement,
        //    TabControlElement,
        //    TableHeaderCollectionElement,
        //    TableRowCollectionElement,
        //    TabPageCollectionElement
        //}
        //#endregion
    }
}

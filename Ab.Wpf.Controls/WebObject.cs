using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab.Wpf.Controls
{
    public class WebObject
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
                if (((int)value >= 100) && ((int)value < 200))
                {
                    ObjectTypes oldValue;

                    oldValue = _type;
                    _type = value;
                    base.NotifyPropertyChanged<ObjectTypes>("Type", oldValue, _type);
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
        //    ButtonElement,
        //    CheckBoxElement,
        //    ComboboxElement,
        //    DataGridElement,
        //    FormElement,
        //    ImageElement,
        //    LabelElement,
        //    LinkElement,
        //    MainMenuElement,
        //    MenuItemElement,
        //    PageHeaderElement,
        //    PagerElement,
        //    PanelElement,
        //    RadioButtonElement,
        //    TabElement,
        //    TableElement,
        //    TabPageElement,
        //    TextBoxElement,
        //    ToolBarCollectionElement,
        //    ToolbarHolderElement,
        //    ToolBarItemElement,
        //    WebAreaElement
        //}
        //#endregion
    }
}

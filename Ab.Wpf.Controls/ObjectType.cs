using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab.Wpf.Controls
{
    public enum ObjectType
    {
        // Single object
        ButtonElement = 101,
        CheckBoxElement = 102,
        ComboboxElement = 103,
        DataGridElement = 104,
        FormElement = 105,
        ImageElement = 106,
        LabelElement = 107,
        LinkElement = 108,
        MainMenuElement = 109,
        MenuItemElement = 110,
        PageHeaderElement = 111,
        PagerElement = 112,
        PanelElement = 113,
        RadioButtonElement = 114,
        TabElement = 115,
        TableElement = 116,
        TabPageElement = 117,
        TextBoxElement = 118,
        ToolBarCollectionElement = 119,
        ToolbarHolderElement = 120,
        ToolBarItemElement = 121,
        WebAreaElement = 122,
        TabControlElement = 124,
    }

    public enum ObjectCollectionType
    {
        // Collection object
        TableHeaderCollectionElement = 200,
        TableRowCollectionElement = 201,
        TabPageCollectionElement = 202,
        TabCollectionElement = 203,
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ab.Wpf.Controls
{
    class PropertyChangedEventArgs<T> : PropertyChangedEventArgs
    {
        public T OldValue { get; private set; }

        public T NewValue { get; private set; }

        public PropertyChangedEventArgs(string propertyName, T oldValue, T newValue)
            : base(propertyName)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }
    }
}

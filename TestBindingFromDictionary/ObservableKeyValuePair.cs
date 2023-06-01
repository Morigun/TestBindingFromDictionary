using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestBindingFromDictionary
{
    [Serializable]
    public class ObservableKeyValuePair<TKey, TValue> : INotifyPropertyChanged
    {
        #region properties
        private TKey _key;
        private TValue _value;

        public TKey Key
        {
            get { return _key; }
            set
            {
                _key = value;
                OnPropertyChanged();
            }
        }

        public TValue Value
        {
            get { return _value; }
            set
            {
                this._value = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region INotifyPropertyChanged Members

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}

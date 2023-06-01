using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace TestBindingFromDictionary
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private  ObservableDictionary<string, object> _observableDictionaryData;

        public ObservableDictionary<string, object> ObservableDictionaryData
        {
            get => _observableDictionaryData;
            set
            {
                _observableDictionaryData = value;
                OnPropertyChanged();
            }
        }

        private Dictionary<string, object> _dictionaryData;

        public Dictionary<string, object> DictionaryData
        {
            get => _dictionaryData;
            set
            {
                _dictionaryData = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            _observableDictionaryData = new ObservableDictionary<string, object>()
            {
                { "test", 1 },
            };
            ObservableDictionaryData.ValueChanged += Data_ValueChanged;
            _dictionaryData = new Dictionary<string, object>()
            {
                { "test", 1 },
            };
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("ObservableDictionaryData:");
            foreach (var data in ObservableDictionaryData)
                result.Append($"[{data.Key}:{data.Value}]");
            result.AppendLine();
            result.AppendLine("DictionaryData:");
            foreach (var data in DictionaryData)
                result.Append($"[{data.Key}:{data.Value}]");
            return result.ToString();
        }

        private void Data_ValueChanged(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(ObservableDictionaryData));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}

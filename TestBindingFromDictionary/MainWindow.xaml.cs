using System.Windows;
using System.Windows.Controls;

namespace TestBindingFromDictionary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckDictionaryValue(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Content = DataContext.ToString();
        }
    }
}

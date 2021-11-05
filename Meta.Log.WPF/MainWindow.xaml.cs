using System.Windows;
using System.Windows.Input;

namespace Meta.Log.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;

        //public static void OnCloseWindow(object sender, ExecutedRoutedEventArgs e)
        //{
        //    if (e.Parameter is MainWindow window)
        //        window.Close();
        //}

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            count++;
            CounterLabel.Content = $"Current count: {count}";
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}

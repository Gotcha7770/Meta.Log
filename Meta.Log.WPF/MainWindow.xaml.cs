using System.Windows.Input;
using Meta.Log.Core.ViewModels;
using Microsoft.Win32;
using ReactiveUI;

namespace Meta.Log.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainViewModel>
    {
        public MainWindow(MainViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = viewModel;

            InitializeComponent();            
        }

        private void OnOpen(object sender, ExecutedRoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Multiselect = true
            };
            
            if(openFileDialog.ShowDialog() == true)
                ViewModel?.OpenFilesCommand.Execute(openFileDialog.FileNames);
        }
    }
}

using Meta.Log.Core.ViewModels;
using ReactiveUI;
using System.Windows;

namespace Meta.Log.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IViewFor<MainViewModel>
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainViewModel ViewModel { get; set; }

        object IViewFor.ViewModel
        {
            get => ViewModel; 
            set => ViewModel = value as MainViewModel;
        }
    }
}

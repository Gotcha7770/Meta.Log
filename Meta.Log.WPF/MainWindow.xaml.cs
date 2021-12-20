using Meta.Log.Core.ViewModels;
using ReactiveUI;
using System.Windows;

namespace Meta.Log.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ReactiveWindow<MainViewModel>
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

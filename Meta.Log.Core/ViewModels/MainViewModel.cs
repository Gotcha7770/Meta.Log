using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Windows.Input;
using DynamicData;
using ReactiveUI;

namespace Meta.Log.Core.ViewModels
{
    public class MainViewModel : ReactiveObject
    {
        private readonly ISourceCache<TabViewModel, Guid> _tabsCache;
        private readonly ReadOnlyObservableCollection<TabViewModel> _tabs;
        private readonly IDisposable _cleanup;

        public MainViewModel(ISourceCache<TabViewModel, Guid> tabsCache)
        {
            _tabsCache = tabsCache;
            OpenFilesCommand = ReactiveCommand.Create<IEnumerable<string>>(OpenFiles);

            _cleanup = tabsCache.Connect()
                .Bind(out _tabs)
                .Subscribe();
        }

        public ICommand OpenFilesCommand { get; }

        public ReadOnlyObservableCollection<TabViewModel> Tabs => _tabs;

        private void OpenFiles(IEnumerable<string> fileNames)
        {
            _tabsCache.Edit(updater =>
            {
                foreach (string fileName in fileNames)
                {
                    //updater.AddOrUpdate();
                }
            });
        }
    }
}
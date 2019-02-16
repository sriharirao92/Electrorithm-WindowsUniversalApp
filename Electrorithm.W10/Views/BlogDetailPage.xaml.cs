using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Rss;
using Electrorithm;
using Electrorithm.Sections;
using Electrorithm.ViewModels;

namespace Electrorithm.Views
{
    public sealed partial class BlogDetailPage : PageBase
    {
        private DataTransferManager _dataTransferManager;

        public BlogDetailPage()
        {
            this.ViewModel = new DetailViewModel<RssSchema>(new BlogConfig());            
            this.InitializeComponent();
        }

        public DetailViewModel<RssSchema> ViewModel { get; set; }        

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync(navParameter as ItemViewModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            ViewModel.ShareContent(args.Request);
        }
    }
}

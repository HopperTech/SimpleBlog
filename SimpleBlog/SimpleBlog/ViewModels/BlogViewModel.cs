using Prism.Navigation;
using SimpleBlog.Models;

namespace SimpleBlog.ViewModels
{
    public class BlogViewModel : ViewModelBase
	{
        public BlogViewModel(INavigationService navigationService)
            : base(navigationService)
        {
               
        }

        private Blog _blogDetail;
        public Blog BlogDetail
        {
            get { return _blogDetail; }
            set { SetProperty(ref _blogDetail, value); }
        }
        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            BlogDetail = (Blog)parameters["Blog"];
            Title = BlogDetail.BlogTitle;
            base.OnNavigatedTo(parameters);
        }
    }
}

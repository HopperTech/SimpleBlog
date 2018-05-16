using Prism.Commands;
using Prism.Navigation;
using SimpleBlog.Models;
using SimpleBlog.Services;
using System;
using System.Collections.Generic;

namespace SimpleBlog.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand NavigateToBlogCommand { get; private set; }

        private List<Blog> _blogs;
        SimpleBlogRepository _simpleBlogRepository;

        private Blog _selectedBlog;
        public Blog SelectedBlog
        {
            get { return _selectedBlog; }
            set { SetProperty(ref _selectedBlog, value); }
        }

        public List<Blog> Blogs
        {
            get { return _blogs; }
            set { SetProperty(ref _blogs, value); }
        }
        public MainPageViewModel(INavigationService navigationService, SimpleBlogRepository simpleBlogRepository)
            : base(navigationService)
        {
            Title = "Blogs";
            _simpleBlogRepository = simpleBlogRepository;
            NavigateToBlogCommand = new DelegateCommand(NavigateToBlog, () => SelectedBlog != null).ObservesProperty(() => SelectedBlog);

        }
        public override async void OnNavigatingTo(NavigationParameters parameters)
        {
            Blogs = await _simpleBlogRepository.GetBlogsAsync();

            base.OnNavigatingTo(parameters);
        }

        private void NavigateToBlog()
        {
            var parameter = new NavigationParameters();
            parameter.Add("Blog", SelectedBlog);
            NavigationService.NavigateAsync("Blog", parameter);
        }
    }
}

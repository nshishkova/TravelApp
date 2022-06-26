using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TravelRecordApp.Helpers;
using TravelRecordApp.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryPage : ContentPage
    {
        private IAuth auth;
        private string searchedText;


        public HistoryPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Filters.IsVisible = false;
            SortLabel.IsVisible = false;
            SortButton.IsVisible = false;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                postListView.ItemsSource = posts.Where(p => p.UserId == this.auth.GetCurrentUserId());
                conn.Close();

            }
        }

        void postListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedPost = postListView.SelectedItem as Post;

            if (selectedPost != null)
            {
                Navigation.PushAsync(new PostDetailPage(selectedPost));
            }
        }
        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();

                conn.Close();

                if (string.IsNullOrEmpty(e.NewTextValue))
                {
                    Filters.IsVisible = false;
                    SortLabel.IsVisible = false;
                    SortButton.IsVisible = false;
                }
                else
                {
                    Filters.IsVisible = true;
                    SortLabel.IsVisible = true;
                    SortButton.IsVisible = true;
                }

                postListView.ItemsSource = posts.Where(p => p.Experience.StartsWith(e.NewTextValue, true, CultureInfo.InvariantCulture) && p.UserId == this.auth.GetCurrentUserId());
                searchedText = e.NewTextValue;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var selectedItem = Filters.SelectedItem.ToString();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                var posts = conn.Table<Post>().ToList();
                posts = posts
                    .Where(p => p.Experience.StartsWith(searchedText, true, CultureInfo.InvariantCulture) && p.UserId == this.auth.GetCurrentUserId())
                    .ToList();

                conn.Close();

                switch (selectedItem)
                {
                    case "Experience":
                        postListView.ItemsSource = posts.OrderBy(x => x.Experience);
                        break;
                    case "Category":
                        postListView.ItemsSource = posts.OrderBy(x => x.CategoryName);
                        break;
                    case "Venue Name":
                        postListView.ItemsSource = posts.OrderBy(x => x.VenueName);
                        break;
                    case "Address":
                        postListView.ItemsSource = posts.OrderBy(x => x.Address);
                        break;
                    case "Distance":
                        postListView.ItemsSource = posts.OrderBy(x => x.Distance);
                        break;
                    case "Date":
                        postListView.ItemsSource = posts.OrderBy(x => x.CreatedOn);
                        break;
                }
            }
        }
    }
}
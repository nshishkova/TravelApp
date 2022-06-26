using System;
using System.Collections.Generic;
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
    public partial class ProfilePage : ContentPage
    {
        private IAuth auth;

        public ProfilePage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().AsEnumerable().Where(x => x.UserId == auth.GetCurrentUserId()).ToList();

                var categories = (from p in postTable
                                  orderby p.CategoryId
                                  select p.CategoryName).Distinct().ToList();

                var categories2 = postTable.OrderBy(p => p.CategoryId).Select(p => p.CategoryName).Distinct().ToList();

                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                foreach (var category in categories)
                {
                    var count = (from p in postTable
                                 where p.CategoryName == category
                                 select p).ToList().Count;

                    var count2 = postTable.Where(p => p.CategoryName == category).ToList().Count;

                    categoriesCount.Add(category, count2);
                }

                categoriesListView.ItemsSource = categoriesCount;

                postCountLabel.Text = postTable.Count.ToString();
            }

        }
    }
}
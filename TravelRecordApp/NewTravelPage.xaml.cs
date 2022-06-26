using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TravelRecordApp.Model;
using SQLite;
using Plugin.Geolocator;
using TravelRecordApp.Logic;
using System.Reflection;
using System.IO;
using TravelRecordApp.Helpers;

namespace TravelRecordApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTravelPage : ContentPage
    {
        private IAuth auth;

        public NewTravelPage()
        {
            InitializeComponent();
            this.auth = DependencyService.Get<IAuth>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var locator = CrossGeolocator.Current;
            var position = await locator.GetPositionAsync();

            var venues = await VenueLogic.GetVenues(position.Latitude, position.Longitude);
            venueListView.ItemsSource = venues;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            try
            {

                var selectedVenue = venueListView.SelectedItem as Result;
                var firstCategory = selectedVenue.categories.FirstOrDefault();

                Post post = new Post()
                {
                    Experience = experienceEntry.Text,
                    CategoryId = firstCategory.id,
                    CategoryName = firstCategory.name,
                    Address = selectedVenue.location.address,
                    Distance = selectedVenue.distance,
                    Latitude = selectedVenue.geocodes.main.latitude,
                    Longitude = selectedVenue.geocodes.main.longitude,
                    VenueName = selectedVenue.name,
                    CreatedOn = DateTime.Now,
                    LastModified18118060 = DateTime.Now,
                    UserId = auth.GetCurrentUserId()
                };

                using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                {
                    conn.CreateTable<Category>(CreateFlags.AutoIncPK);
                    conn.CreateTable<Post>(CreateFlags.AutoIncPK);
                    int rows = conn.Insert(post);

                    if (rows > 0)
                    {
                        experienceEntry.Text = string.Empty;
                        DisplayAlert("Success", "Experience succesfully inserter", "Ok");
                    }
                    else
                        DisplayAlert("Failure", "Experience failed to be inserted, please try again", "Ok");

                }
            }
            catch (NullReferenceException nrex)
            {
                DisplayAlert("Alert", "You have been alerted nre", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Alert", "You have been alerted ex ", "OK");
            }
        }
    }
}


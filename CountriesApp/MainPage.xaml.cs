using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace CountriesApp
{
    public partial class MainPage : ContentPage
    {
        private CountryViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new CountryViewModel();
            BindingContext = viewModel;
        }

        // Handler for adding a country
        private void OnAddCountryClicked(object sender, EventArgs e)
        {
            var country = new Country
            {
                Name = "France",
                Capital = "Paris",
                Population = 67000000,
                Flag = "france_flag.png" // Set a valid image path
            };
            viewModel.AddCountry(country);
        }

        // Handler for removing a country
        private void OnRemoveCountryClicked(object sender, EventArgs e)
        {
            if (viewModel.SelectedCountry != null)
            {
                viewModel.RemoveCountry(viewModel.SelectedCountry);
            }
        }

        // Handler for updating country details
        private void OnUpdateCountryClicked(object sender, EventArgs e)
        {
            if (viewModel.SelectedCountry != null)
            {
                var updatedCountry = new Country
                {
                    Name = viewModel.SelectedCountry.Name,
                    Capital = "Updated Capital",
                    Population = 75000000,
                    Flag = "updated_flag.png" // Set a valid image path
                };
                viewModel.UpdateCountry(updatedCountry);
            }
        }
    }
}

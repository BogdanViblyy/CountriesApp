using Microsoft.Maui.Controls;

namespace CountriesApp
{
    public partial class CountryDetailPage : ContentPage
    {
        public CountryDetailPage(Country country)
        {
            InitializeComponent();

            Title = country.Name;
            countryNameLabel.Text = $"Столица: {country.Capital}";
            countryPopulationLabel.Text = $"Население: {country.Population}";
            countryFlagImage.Source = country.Flag;
        }
    }
}
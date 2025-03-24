using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;

namespace CountriesApp
{

    public class Country
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public int Population { get; set; }
        public string Flag { get; set; } // путь к изображению флага
    }

    public class CountryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Country> Countries { get; set; } = new ObservableCollection<Country>();

        private Country _selectedCountry;
        public Country SelectedCountry
        {
            get => _selectedCountry;
            set
            {
                _selectedCountry = value;
                OnPropertyChanged(nameof(SelectedCountry));
            }
        }

        public void AddCountry(Country country)
        {
            if (!Countries.Any(c => c.Name == country.Name))
                Countries.Add(country);
        }

        public void RemoveCountry(Country country)
        {
            Countries.Remove(country);
        }

        public void UpdateCountry(Country updatedCountry)
        {
            var country = Countries.FirstOrDefault(c => c.Name == updatedCountry.Name);
            if (country != null)
            {
                country.Capital = updatedCountry.Capital;
                country.Population = updatedCountry.Population;
                country.Flag = updatedCountry.Flag;
                OnPropertyChanged(nameof(Countries));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Command ShowDetailsCommand { get; }

        public CountryViewModel()
        {
            ShowDetailsCommand = new Command(ShowDetails);
        }

        private async void ShowDetails()
        {
            if (SelectedCountry != null)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new CountryDetailPage(SelectedCountry));
            }
        }
        public class CountryDetailPage : ContentPage
        {
            public CountryDetailPage(Country country)
            {
                Title = country.Name;
                Content = new StackLayout
                {
                    Padding = 20,
                    Children =
            {
                new Label { Text = $"Столица: {country.Capital}", FontSize = 18 },
                new Label { Text = $"Население: {country.Population}", FontSize = 18 },
                new Image { Source = country.Flag, HeightRequest = 100 }
            }
                };
            }
        }
    }

}

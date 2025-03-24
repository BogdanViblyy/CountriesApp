using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CountriesApp
{
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

        // Add a country to the list if it's not already in it
        public void AddCountry(Country country)
        {
            if (!Countries.Any(c => c.Name == country.Name))
                Countries.Add(country);
        }

        // Remove a country from the list
        public void RemoveCountry(Country country)
        {
            Countries.Remove(country);
        }

        // Update a country with new information
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
    }
}
}
  

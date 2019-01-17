using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WeatherAppExample.Model;

namespace WeatherAppExample.ViewModel
{
    public class WeatherForcastVM : INotifyPropertyChanged
    {
        private string query;
        public string Query
        {
            get { return query; }
            set
            {
                query = value;
                OnPropertyChanged("Query");
                GetLocations();
            }
        }

        private bool isResultsVisible;
        public bool IsResultsVisible
        {
            get { return isResultsVisible; }
            set
            {
                isResultsVisible = value;
                OnPropertyChanged("IsResultsVisible");
            }
        }

        private Location selectedLocation;
        public Location SelectedLocation
        {
            get { return selectedLocation; }
            set
            {
                selectedLocation = value;
                IsResultsVisible = false;
                OnPropertyChanged("SelectedLocation");
                GetForecasts();
            }
        }

        public ObservableCollection<Location> Locations { get; set; }

        public ObservableCollection<DailyForecast> FiveDayForecast { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public WeatherForcastVM()
        {
            IsResultsVisible = false;
            Locations = new ObservableCollection<Location>();
            FiveDayForecast = new ObservableCollection<DailyForecast>();
        }

        private async void GetForecasts()
        {
            var forecasts = await ForecastAPIHelper.GetFiveDayForecast(SelectedLocation.Key);

            FiveDayForecast.Clear();
            foreach(var f in forecasts)
            {
                FiveDayForecast.Add(f);
            }
        }

        private async void GetLocations()
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                var locations = await Autocomplete.GetLocations(Query);

                Locations.Clear();
                foreach (var location in locations)
                    Locations.Add(location);

                if (Locations.Count > 0)
                    IsResultsVisible = true;
            }
            else
            {
                Locations.Clear();
                IsResultsVisible = false;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

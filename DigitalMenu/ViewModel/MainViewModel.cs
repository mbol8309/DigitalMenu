
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DigitalMenu.DataServices;
using DigitalMenu.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DigitalMenu.ViewModel;

public partial class MainViewModel : ObservableObject
{
    IConnectivity connectivity;
    private IRestaurantDataService _dataService;
    public CollectionView collectionView;

    public MainViewModel(IConnectivity conn, IRestaurantDataService dataService) {

        this.connectivity = conn;
        _dataService = dataService;
    }

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text="";

    [RelayCommand]
    async Task Search()
    {
        //add
        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No connection","No internet","ok");
            return;
        }
        if (string.IsNullOrWhiteSpace(Text))
            return;

        List<Restaurant> restaurants = await _dataService.SearchAsync(Text);
        collectionView.ItemsSource = restaurants;
        
    }

    [RelayCommand]
    void Delete(string s) { Items.Remove(s); }

    //[RelayCommand]
    //async Task Tap(string s)
    //{
    //    await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    //}
}

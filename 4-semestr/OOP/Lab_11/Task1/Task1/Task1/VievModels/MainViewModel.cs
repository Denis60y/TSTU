using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using Task1.Commands;

namespace Task1.VievModels
{
    public class Product
    {
        public string Name { get; set; }
        public bool IsBought { get; set; }
    }

    internal class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Product> Products { get; set; }

        private ICollectionView productsView;


        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private bool isBought;
        public bool IsBought 
        {
            get => isBought;
            set 
            {
                isBought = value; 
                OnPropertyChanged(nameof(IsBought));
            }
        }

        public ICommand AddElementCommand { get; }
        public ICommand ShowOnlyBoughtCommand { get; }
        public ICommand ShowOnlyNotBoughtCommand { get; }
        public ICommand ShowAllCommand { get; }

        public MainViewModel()
        {
            Products = new ObservableCollection<Product>();
            productsView = CollectionViewSource.GetDefaultView(Products);

            AddElementCommand = new RelayCommand(AddElement);
            ShowOnlyBoughtCommand = new RelayCommand(ShowOnlyBought);
            ShowOnlyNotBoughtCommand = new RelayCommand(ShowOnlyNotBought);
            ShowAllCommand = new RelayCommand(ShowAll);
        }

        private void AddElement()
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                Products.Add(new Product { Name = Name, IsBought = IsBought });
                Name = ""; 
            }
        }

        private void ShowOnlyBought()
        {
            productsView.Filter = p => ((Product)p).IsBought;
        }

        private void ShowOnlyNotBought()
        {
            productsView.Filter = p => !((Product)p).IsBought;
        }

        private void ShowAll()
        {
            productsView.Filter = null; 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
using StoreTaskAdoNet.Commands;
using StoreTaskAdoNet.DataAccess.SqlServer;
using StoreTaskAdoNet.Domain.Services;
using StoreTaskAdoNet.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTaskAdoNet.Domain.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public RelayCommand ProductsCommand { get; set; }
        public RelayCommand OrdersCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand SelectProductCommand { get; set; }

        private readonly ProductService _productService;
        private ObservableCollection<Product> allProducts;
        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }

        private Product selectedProduct;
        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }

        public MainViewModel()
        {
            _productService = new ProductService();
            AllProducts = _productService.GetAllProducts();

            ProductsCommand = new RelayCommand((obj) =>
            {
                var vm = new ProductsViewModel();
                var view = new Products();
                view.DataContext = vm;
                view.ShowDialog();
            });

            OrdersCommand = new RelayCommand((obj) =>
            {
                var vm = new OrdersViewModel();
                var view = new Orders();
                view.DataContext = vm;
                view.ShowDialog();
            });

            RefreshCommand = new RelayCommand((obj) =>
            {
                AllProducts = _productService.GetAllProducts();
            });

            SelectProductCommand = new RelayCommand((obj) =>
            {
                var vm = new OrderProductViewModel();
                vm.ProductInfo = SelectedProduct;
                var view = new OrderProduct();
                view.DataContext = vm;
                view.ShowDialog();
            });
        }
    }
}
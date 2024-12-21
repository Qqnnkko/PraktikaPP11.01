using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System;

namespace seryiPraktika
{
    public partial class ProductsWindow : Page
    {
        private seryiPractikaEntities _context;

        public ProductsWindow()
        {
            InitializeComponent();
            _context = new seryiPractikaEntities();
            LoadCategories();
            LoadProducts();
        }
        private void LoadCategories()
        {
            var categories = _context.categ.ToList();
            categories.Insert(0, new categ { id = 0, category_name = "Все категории" });
            CategoryFilterComboBox.ItemsSource = categories;
            CategoryFilterComboBox.SelectedIndex = 0;
        }

        private void LoadProducts()
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var selectedCategory = CategoryFilterComboBox.SelectedItem as categ;
            var query = _context.prodact.AsQueryable();

            if (selectedCategory != null && selectedCategory.id != 0)
            {
                query = query.Where(p => p.id_cat == selectedCategory.id);
            }

            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                query = query.Where(p =>
                    p.name_prod.StartsWith(SearchTextBox.Text));
            }
            ProductsListView.ItemsSource = query.ToList();
        }
        private void CategoryFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }
        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }
        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductEditWindow());
        }
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductsListView.SelectedItem as prodact;
            if (selectedProduct != null)
                NavigationService.Navigate(new ProductEditWindow(selectedProduct));
            else
            {
                MessageBox.Show("Выберите продукт для редактирования.", "Ошибка",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = ProductsListView.SelectedItem as prodact;
            if (selectedProduct != null)
            {
                try
                {
                    _context.prodact.Remove(selectedProduct);
                    _context.SaveChanges();
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении продукта: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Выберите продукт для удаления.", "Ошибка",
                      MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
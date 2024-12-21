using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace seryiPraktika
{
    public partial class AddPaymentWindow : Page
    {
        private seryiPractikaEntities _context;

        public AddPaymentWindow()
        {
            InitializeComponent();
            _context = new seryiPractikaEntities();
             LoadCategories();
            DateLabel.Content = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }
        private void LoadCategories()
        {
            CategoryComboBox.ItemsSource = _context.categ.ToList();
        }
        private void LoadProducts()
        {
                var selectedCategory = CategoryComboBox.SelectedItem as categ;
                ProductComboBox.ItemsSource = _context.prodact.Where(p => p.id_cat == selectedCategory.id).ToList();
        }
        private void CategoryComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadProducts();
        }
        private void AddPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            if (CategoryComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите категорию.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (ProductComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите продукт.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
             if (string.IsNullOrWhiteSpace(QuantityTextBox.Text))
             {
                 MessageBox.Show("Введите количество", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                 return;
             }
             if (string.IsNullOrWhiteSpace(PriceTextBox.Text))
            {
                MessageBox.Show("Введите цену", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                 return;
            }
             var selectedProduct = ProductComboBox.SelectedItem as prodact;

            try
            {
                var newOrder = new order()
                {
                   product_id = selectedProduct.id,
                    price = PriceTextBox.Text.Trim(),
                    count = QuantityTextBox.Text.Trim(),
                    sum = (decimal.Parse(PriceTextBox.Text) * int.Parse(QuantityTextBox.Text)).ToString(),
                        date = DateTime.Now
                };
                 _context.order.Add(newOrder);
                _context.SaveChanges();

                
                NavigationService.GoBack();


            }
            catch (FormatException)
            {
                 MessageBox.Show("Неверный формат данных в полях \"Цена\" или \"Количество\".", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                  MessageBox.Show($"Ошибка при добавлении платежа: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
             NavigationService.GoBack();
        }
    }
}
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
    public partial class ProductEditWindow : Page
    {
        private seryiPractikaEntities _context;
        private prodact _product;

        public ProductEditWindow(prodact product = null)
        {
            InitializeComponent();
            _context = new seryiPractikaEntities(); //инициализируем наш контекст.
            LoadCategories();

            _product = product ?? new prodact();

            if (product != null)
            {
                ProductNameTextBox.Text = product.name_prod;
                CategoryComboBox.SelectedValue = product.id_cat;
            }
        }
        private void LoadCategories()
        {
            CategoryComboBox.ItemsSource = _context.categ.ToList();
            CategoryComboBox.SelectedIndex = 0;

        }
        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductNameTextBox.Text) ||
               CategoryComboBox.SelectedValue == null)
            {
                InfoTextBlock.Text = "Заполните все поля!";
                return;
            }
            _product.name_prod = ProductNameTextBox.Text.Trim();
            var selectedCategory = (int)CategoryComboBox.SelectedValue;
            _product.id_cat = selectedCategory;


            if (_product.id == 0)
            {
                int max = 0;
                if (_context.prodact.Count() != 0)
                {
                    max = _context.prodact.Max(pr => pr.id);
                }
                _product.id = max + 1;
                _context.prodact.Add(_product);
            }


            try
            {
                _context.SaveChanges();
                MessageBox.Show("Продукт успешно сохранен!", "Информация",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        private void CancelProduct_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
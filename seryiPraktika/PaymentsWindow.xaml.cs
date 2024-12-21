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
    public partial class PaymentsWindow : Page
    {
        private seryiPractikaEntities _context;

        public PaymentsWindow()
        {
            InitializeComponent();
            _context = new seryiPractikaEntities();
            LoadCategories();
            LoadPayments();
        }
        private void LoadCategories()
        {
            var categories = _context.categ.ToList();
            categories.Insert(0, new categ { id = 0, category_name = "Все категории" });
            CategoryFilterComboBox.ItemsSource = categories;
            CategoryFilterComboBox.SelectedIndex = 0;
        }
        private void LoadPayments()
        {
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            var selectedCategory = CategoryFilterComboBox.SelectedItem as categ;
            var startDate = StartDatePicker.SelectedDate;
            var endDate = EndDatePicker.SelectedDate;
            var query = _context.order.AsQueryable();
            if (selectedCategory != null && selectedCategory.id != 0)
            {
                query = query.Where(p => p.id == selectedCategory.id);
            }
            if (startDate != null && endDate != null)
            {
                query = query.Where(p => p.date >= startDate && p.date <= endDate);
            }
            PaymentsListView.ItemsSource = query.ToList();
        }
        private void CategoryFilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ApplyFilter();
        }
        private void ApplyDateFilter_Click(object sender, RoutedEventArgs e)
        {
            ApplyFilter();
        }

        private void AddPayment_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPaymentWindow());
        }

        private void DeletePayment_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Страница удаления в разработке", "Сообщение",
                    MessageBoxButton.OK, MessageBoxImage.Information);
       
        }

    }
    public class PaymentView
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public categ Category { get; set; }
    }
}
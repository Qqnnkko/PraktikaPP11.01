using System.Linq;
using System.Windows.Controls;
using System.Windows;
using System;

namespace seryiPraktika
{
    public partial class CategoryWindow : Page
    {
        private seryiPractikaEntities _context;

        public CategoryWindow()
        {
            InitializeComponent();
            _context = new seryiPractikaEntities();
            LoadCategories();
        }

        private void LoadCategories()
        {
            ApplyFilter();
        }
        private void ApplyFilter()
        {
            var query = _context.categ.AsQueryable();
            if (!string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                query = query.Where(p =>
                    p.category_name.StartsWith(SearchTextBox.Text));
            }
            CategoriesListView.ItemsSource = query.ToList();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void AddCategory_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CategoryEditWindow());
        }

        private void EditCategory_Click(object sender, RoutedEventArgs e)
        {
            var selectedCategory = CategoriesListView.SelectedItem as categ;
            if (selectedCategory != null)
            {
                NavigationService.Navigate(new CategoryEditWindow(selectedCategory));
            }
            else
            {
                MessageBox.Show("Выберите категорию для редактирования.", "Ошибка",
                       MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
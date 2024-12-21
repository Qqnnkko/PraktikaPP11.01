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
    public partial class CategoryEditWindow : Page
    {
        private seryiPractikaEntities _context;
         private categ _editingCategory;

        public CategoryEditWindow()
        {
            InitializeComponent();
              _context = new seryiPractikaEntities();
        }
        public CategoryEditWindow(categ category)
        {
             InitializeComponent();
             _context = new seryiPractikaEntities();
              _editingCategory = category;
             CategoryNameTextBox.Text = _editingCategory.category_name;
        }
        private int GenerateNextCategoryId()
        {
            if (_context.categ.Any())
            {
                return _context.categ.Max(c => c.id) + 1;
            }
            else
            {
                return 1; // Если таблица пуста, то возвращаем 1 как начальный ID
            }
        }
        private void SaveCategory_Click(object sender, RoutedEventArgs e)
        {
            if(string.IsNullOrWhiteSpace(CategoryNameTextBox.Text))
            {
                 MessageBox.Show("Введите название категории", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_editingCategory == null)
            {
                // Добавление новой категории
                var newCategory = new categ()
                {
                      id = GenerateNextCategoryId(),
                      category_name = CategoryNameTextBox.Text.Trim()
                };
                try
                {
                     _context.categ.Add(newCategory);
                    _context.SaveChanges();
                  NavigationService.GoBack();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении категории: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                // Редактирование существующей категории
                try
                {
                    _editingCategory.category_name = CategoryNameTextBox.Text.Trim();
                    _context.SaveChanges();
                    NavigationService.GoBack();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при редактировании категории: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

        }
    }
}

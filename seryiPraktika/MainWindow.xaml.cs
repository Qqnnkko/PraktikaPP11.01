﻿using System;
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
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   
        public MainWindow()
        {
            InitializeComponent();  

        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CategoryWindow());
        }

        private void Products_CLick(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsWindow());
        }

        private void Payments_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PaymentsWindow());
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportWindow());
        }

        private void Products_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductsWindow());
        }
    }
}
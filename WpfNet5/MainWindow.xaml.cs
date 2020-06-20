﻿using Microsoft.Extensions.DependencyInjection;
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
using WpfNet5.Core.Services;
using WpfNet5.Views;

namespace WpfNet5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IXNavigationService _navigationService;
        public MainWindow(IServiceProvider serviceProvider)
        {
            _navigationService = serviceProvider.GetRequiredService<IXNavigationService>();
            InitializeComponent();

            var contentPage = _navigationService.CurrentPage;
            //navMenu.Init(serviceProvider.GetRequiredService<MenuViewModel>());
            // MainFrame.Navigate(menuPage);
            menuFrame.Navigate(new Menu(serviceProvider.GetRequiredService<MenuViewModel>()));
            contentFrame.Navigate(contentPage);
        }
    }
}

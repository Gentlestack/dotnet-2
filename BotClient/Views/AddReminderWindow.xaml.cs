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
using System.Windows.Shapes;
using BotClient.ViewModels;

namespace BotClient.Views
{
    /// <summary>
    /// Interaction logic for AddReminderWindow.xaml
    /// </summary>
    public partial class AddReminderWindow : Window
    {
        public AddReminderWindow()
        {
            InitializeComponent();
            DataContext = new AddReminderViewModel();
        }
    }
}

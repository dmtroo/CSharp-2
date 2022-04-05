using System;
using System.Windows;
using ProgrammingInCSharp.Lab02.Views;

namespace ProgrammingInCSharp.Lab02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Content = new DatePickerView();
        }


    }
}
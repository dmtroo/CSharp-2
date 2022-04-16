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

namespace ProgrammingInCSharp.Lab02.Tools.Controls
{
    /// <summary>
    /// Interaction logic for TextBoxWithCaption.xaml
    /// </summary>
    public partial class TextBoxWithCaption : UserControl
    {
        public TextBoxWithCaption()
        {
            InitializeComponent();
        }
        public string Caption
        {
            get
            {
                return TBoxCaption.Text;
            }
            set
            {
                TBoxCaption.Text = value;
            }
        }

        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register
        (
            "Text",
            typeof(string),
            typeof(TextBoxWithCaption),
            new PropertyMetadata(null)
        );

    }
}
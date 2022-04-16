using System.Windows.Controls;
using ProgrammingInCSharp.Lab02.ViewModels;

namespace ProgrammingInCSharp.Lab02.Views
{
    /// <summary>
    /// Interaction logic for DatePickerView.xaml
    /// </summary>
    public partial class DatePickerView : UserControl
    {
        public DatePickerView()
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
        }
    }
}

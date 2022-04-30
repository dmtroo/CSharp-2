using System.Windows.Controls;
using ProgrammingInCSharp.Lab02.ViewModels;

namespace ProgrammingInCSharp.Lab02.Views
{
    /// <summary>
    /// Interaction logic for AuthView.xaml
    /// </summary>
    public partial class AuthView : UserControl
    {
        public AuthView()
        {
            InitializeComponent();
            DataContext = new AuthViewModel();
        }
    }
}

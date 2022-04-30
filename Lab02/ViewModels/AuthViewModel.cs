using ProgrammingInCSharp.Lab02.Navigation;

namespace ProgrammingInCSharp.Lab02.ViewModels
{
    internal class AuthViewModel : BaseNavigationViewModel, INavigatable
    {

        #region Constructors
        public AuthViewModel()
        {
            Navigate(MainNavigationTypes.SignIn);
        }
        #endregion

        #region Properties
        public MainNavigationTypes ViewType
        {
            get => MainNavigationTypes.Main;
        }
        #endregion

        protected override INavigatable CreateViewModel(MainNavigationTypes type)
        {
            switch (type)
            {
                case MainNavigationTypes.SignIn:
                    return new SignInViewModel(() => Navigate(MainNavigationTypes.Main));
                case MainNavigationTypes.Main:
                    return new MainViewModel(() => Navigate(MainNavigationTypes.SignIn));
                default:
                    return null;
            }
        }

    }
}

using System;
using ProgrammingInCSharp.Lab02.Models;
using ProgrammingInCSharp.Lab02.Navigation;
using ProgrammingInCSharp.Lab02.Tools;

namespace ProgrammingInCSharp.Lab02.ViewModels
{
    internal class MainViewModel : INavigatable
    {
        #region Fields
        private Action _gotoSignIn;
        public static Person Person;
        #endregion

        #region Commands
        public MainNavigationTypes ViewType => MainNavigationTypes.Main;
        private RelayCommand<object> _gotoSignInCommand;
        #endregion

        #region Constructors
        public MainViewModel(Action gotoSignIn)
        {
            _gotoSignIn = gotoSignIn;
        }

        #endregion

        #region Properties
        public string Name
        {
            get => Person.Name;
        }
        public string Surname
        {
            get => Person.Surname;
        }
        public string Email
        {
            get => Person.Email;
        }
        public DateTime? Birthdate
        {
            get => Person.Birthdate;
        }
        public string StringBirthdate
        {
            get => Birthdate.Value.ToShortDateString();
        }
        public string ChineseSign
        {
            get => Person.ChineseSign;
        }
        public string SunSign
        {
            get => Person.SunSign;
        }
        public bool IsAdult
        {
            get => Person.IsAdult;
        }
        public string IsBirthday
        {
            get => Person.IsBirthday ? "TRUE" : "FALSE";
        }

        #endregion
        public RelayCommand<object> GotoSignInCommand
        {
            get
            {
                return _gotoSignInCommand ??= new RelayCommand<object>(_ => GotoSignIn());
            }
        }

        private void GotoSignIn()
        {
            _gotoSignIn.Invoke();
        }

    }
}
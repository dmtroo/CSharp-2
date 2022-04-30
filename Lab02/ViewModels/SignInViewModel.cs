using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using ProgrammingInCSharp.Lab02.Exceptions;
using ProgrammingInCSharp.Lab02.Models;
using ProgrammingInCSharp.Lab02.Navigation;
using ProgrammingInCSharp.Lab02.Tools;

namespace ProgrammingInCSharp.Lab02.ViewModels
{
    class SignInViewModel : INotifyPropertyChanged, INavigatable
    {
        #region Fields

        private bool _isEnabled = true;
        private Person _person;
        private Action _gotoMain;

        #endregion

        #region Constructors

        public SignInViewModel(Action gotoMain)
        {
            _gotoMain = gotoMain;
        }

        #endregion

        #region Commands

        private RelayCommand<object> _proceedCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        public MainNavigationTypes ViewType => MainNavigationTypes.SignIn;

        #endregion

        #region Properties
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }

        public bool IsEnabled
        {
            get => _isEnabled;

            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }

        }

        #endregion

        public RelayCommand<object> ProceedCommand
        {
            get
            {
                return _proceedCommand ??= new RelayCommand<object>(_ => Proceed(), CanExecute);
            }

        }

        private bool CanExecute(object obj)
        {
            return !(string.IsNullOrWhiteSpace(Birthdate.ToString()) || string.IsNullOrWhiteSpace(Name) ||
                     string.IsNullOrWhiteSpace(Surname) || string.IsNullOrWhiteSpace(Email));
        }

        private async void Proceed()
        {
            DateTime? oldBirthdate = DateTime.Today;
            if (_person != null && _person.Birthdate < DateTime.Today) 
                oldBirthdate = _person.Birthdate;

            try
            {
                _person = new Person(Name, Surname, Email, Birthdate);
            }
            catch (InvalidEmailException e)
            {
                MessageBox.Show(e.Message, "Error");
                return;
            }
            catch (PastBirthdateException e)
            {
                MessageBox.Show(e.Message, "Error");
                ReturnDate(oldBirthdate);
                return;
            }
            catch (FutureBirthdateException e)
            {
                MessageBox.Show(e.Message, "Error");
                ReturnDate(oldBirthdate);
                return;
            }

            IsEnabled = false;
            await Task.Run(() => MainViewModel.Person = _person);
            IsEnabled = true;
            _gotoMain.Invoke();

            if(_person.IsBirthday) 
                MessageBox.Show("Happy birthday!");
        }

        private void ReturnDate( DateTime? oldBirthdate)
        {
            Birthdate = oldBirthdate;
            OnPropertyChanged(nameof(Birthdate));
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

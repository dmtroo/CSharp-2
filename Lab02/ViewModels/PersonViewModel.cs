using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using ProgrammingInCSharp.Lab02.Models;
using ProgrammingInCSharp.Lab02.Tools;

namespace ProgrammingInCSharp.Lab02.ViewModels
{
    class PersonViewModel : INotifyPropertyChanged
    {
        #region Fields
        private int _age;
        private bool _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;
        private bool _isEnabled = true;
        #endregion
        private Person _person = new();

        #region Commands
        private RelayCommand<object> _calculateCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        #region Properties

        public string Name
        {
            get
            {
                return _person.Name;
            }
            set
            {
                _person.Name = value;
            }
        }

        public string Surname
        {
            get
            {
                return _person.Surname;
            }
            set
            {
                _person.Surname = value;
            }
        }
        public string Email
        {
            get
            {
                return _person.Email;
            }
            set
            {
                _person.Email = value;
            }
        }
        public DateTime? Birthdate
        {
            get
            {
                return _person.Birthdate;
            }
            set
            {
                _person.Birthdate = value;
            }
        }

        public bool IsAdult
        {
            get
            {
                return _isAdult;
            }
            private set
            {
                _isAdult = value;
                OnPropertyChanged("IsAdult");
            }
        }

        public string SunSign
        {
            get
            {
                return _sunSign;
            }
            private set
            {
                _sunSign = value;
                OnPropertyChanged("SunSign");
            }
        }

        public string ChineseSign
        {
            get
            {
                return _chineseSign;
            }
            private set
            {
                _chineseSign = value;
                OnPropertyChanged("ChineseSign");
            }
        }

        public bool IsBirthday
        {
            get
            {
                return _isBirthday;
            }
            private set
            {
                _isBirthday = value;
                OnPropertyChanged("IsBirthday");
            }
        }



        public RelayCommand<object> ProceedCommand
        {
            get
            {

                return _calculateCommand ??= new RelayCommand<object>(_ => Proceed(), CanExecute);
            }

        }

        private bool CanExecute(object obj)
        {
            return !(string.IsNullOrWhiteSpace(Birthdate.ToString()) || string.IsNullOrWhiteSpace(Name) ||
                     string.IsNullOrWhiteSpace(Surname) || string.IsNullOrWhiteSpace(Email));
        }

        private async void Proceed()
        {
            _person = new Person(Name, Surname, Email, Birthdate);

            if (_person.Age < 0)
            {
                MessageBox.Show($"Wrong birthdate!\n -- You haven't been born yet --");
                return;
            }

            if (_person.Age > 135)
            {
                MessageBox.Show($"Wrong birthdate!\n -- You are probably dead -- \n must be less than 135");
                return;
            }

            IsEnabled = false;
            await Task.Run(() => Calculate());
            IsEnabled = true;
        }

        private void Calculate()
        {
            IsAdult = _person.IsAduld;
            SunSign = _person.SunSign;
            ChineseSign = _person.ChineseSign;
            OnPropertyChanged("Name");
            OnPropertyChanged("Surname");
            OnPropertyChanged("Email");
            OnPropertyChanged("Birthdate");
            if (IsBirthday = _person.IsBirthday)
            {
                MessageBox.Show($"Happy birthday!!!");
            }
        }

        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }

            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }

        }

        #endregion

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

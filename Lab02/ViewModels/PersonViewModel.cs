using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ProgrammingInCSharp.Lab02.Models;
using ProgrammingInCSharp.Lab02.Tools;

namespace ProgrammingInCSharp.Lab02.ViewModels
{
    class PersonViewModel : INotifyPropertyChanged
    {
        #region Fields

        private string _sunSign;
        private string _chineseSign;
        private string _birthdate;
        private bool _isEnabled = true;
        private Person _person;

        #endregion
        
        #region Commands

        private RelayCommand<object> _calculateCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }

        public string StringBirthdate
        {
            get => _birthdate;
            set
            {
                _birthdate = Birthdate.Value.ToShortDateString();
                OnPropertyChanged("StringBirthdate");
            }
        }

        public string IsAdult
        {
            get
            {
                if (_person == null)
                    return "";
                if (_person.IsAdult)
                    return "TRUE";
                
                return "FALSE";
            }
            private set => OnPropertyChanged("IsAdult");
        }

        public string SunSign
        {
            get => _sunSign;
            private set
            {
                _sunSign = value;
                OnPropertyChanged("SunSign");
            }
        }

        public string ChineseSign
        {
            get => _chineseSign;
            private set
            {
                _chineseSign = value;
                OnPropertyChanged("ChineseSign");
            }
        }

        public string IsBirthday
        {
            get
            {
                if (_person == null)
                    return "";

                return _person.IsBirthday ? "TRUE" : "FALSE";
            }
            private set => OnPropertyChanged("IsBirthday");
        }

        #endregion

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

            switch (_person.Age)
            {
                case < 0:
                    MessageBox.Show($"Wrong birthdate!\n -- You haven't been born yet --");
                    return;
                case > 135:
                    MessageBox.Show($"Wrong birthdate!\n -- You are probably dead -- \n must be less than 135");
                    return;
            }

            IsEnabled = false;
            await Task.Run(() => Calculate());
            IsEnabled = true;
        }

        private void Calculate()
        {
            //Thread.Sleep(3000);
            IsAdult = _person.IsAdult.ToString();
            SunSign = _person.SunSign;
            ChineseSign = _person.ChineseSign;
            IsBirthday = _person.IsBirthday.ToString();
            StringBirthdate = "";

            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(Surname));
            OnPropertyChanged(nameof(Email));

            if (_person.IsBirthday)
                MessageBox.Show($"Happy birthday!!!");

        }

        public bool IsEnabled
        {
            get => _isEnabled;

            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

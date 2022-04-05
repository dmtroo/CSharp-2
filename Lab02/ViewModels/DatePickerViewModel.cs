using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Documents;
using ProgrammingInCSharp.Lab02.Models;
using ProgrammingInCSharp.Lab02.Tools;

namespace ProgrammingInCSharp.Lab02.ViewModels
{
    class DatePickerViewModel : INotifyPropertyChanged
    {
        #region Fields
        private User _user = new();
        private string[] animals = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        private string[] elements = { "Wood", "Fire", "Earth", "Metal", "Water" };
        #region Commands
        private RelayCommand<object> _calculateCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #endregion


        #region Properties

        public DateTime? Birthdate
        {
            get { return _user.Birthdate; }
            set { _user.Birthdate = value; }
        }

        public string Age
        {
            get
            {
                return _user.Age;
            }
            set
            {
                _user.Age = value;
                OnPropertyChanged("Age");
            }
        }
        public string WestZodiac
        {
            get { return _user.WestZodiac; }
            set
            {
                _user.WestZodiac = value;
                OnPropertyChanged("WestZodiac");
            }
        }

        public string ChineseZodiac
        {
            get { return _user.ChineseZodiac; }
            set
            {
                _user.ChineseZodiac = value;
                OnPropertyChanged("ChineseZodiac");
            }
        }

        public RelayCommand<object> CalculateCommand
        {
            get
            {
                return _calculateCommand ??= new RelayCommand<object>(_ => Calculate());
            }

        }

        private void Calculate()
        {
            if (string.IsNullOrWhiteSpace(_user.Birthdate.ToString()))
            {
                MessageBox.Show($"Date field is empty!");
                MakeEmpty();
                return;
            }

            int age = CountAge(_user.Birthdate);
            if (age < 0 || age > 135)
            {
                MakeEmpty();
                MessageBox.Show($"Wrong birthdate!");
                return;
            }

            Age = age == 0 ? "less than 1 year" : age.ToString();

            if (IsBirthday(_user.Birthdate))
            {
                MessageBox.Show($"Happy birthday!!!");
            }

            WestZodiac = WesternZodiacSign(_user.Birthdate.Value.Day, _user.Birthdate.Value.Month);
            ChineseZodiac = ChineseZodiacSign(_user.Birthdate.Value.Year);
        }

        private void MakeEmpty()
        {
            Age = "";
            WestZodiac = "";
            ChineseZodiac = "";
        }

        #endregion

        private int CountAge(DateTime? birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Value.Year;

            if (DateTime.Today.Month < birthDate.Value.Month || (DateTime.Today.Month == birthDate.Value.Month && DateTime.Today.Day < birthDate.Value.Day))
                age--;
            return age;
        }
        private bool IsBirthday(DateTime? birthDate)
        {
            return (DateTime.Today.Month == birthDate.Value.Month) && (DateTime.Today.Day == birthDate.Value.Day);
        }

        private string WesternZodiacSign(int day, int month)
        {
            if (month == 12)
            {

                if (day < 22)
                    return "Sagittarius";
                else
                    return "Capricorn";
            }

            else if (month == 1)
            {
                if (day < 20)
                    return "Capricorn";
                else
                    return "Aquarius";
            }

            else if (month == 2)
            {
                if (day < 19)
                    return "Aquarius";
                else
                    return "Pisces";
            }

            else if (month == 3)
            {
                if (day < 21)
                    return "Pisces";
                else
                    return "Aries";
            }
            else if (month == 4)
            {
                if (day < 20)
                    return "Aries";
                else
                    return "Taurus";
            }

            else if (month == 5)
            {
                if (day < 21)
                    return "Taurus";
                else
                    return "Gemini";
            }

            else if (month == 6)
            {
                if (day < 21)
                    return "Gemini";
                else
                    return "Cancer";
            }

            else if (month == 7)
            {
                if (day < 23)
                    return "Cancer";
                else
                    return "Leo";
            }

            else if (month == 8)
            {
                if (day < 23)
                    return "Leo";
                else
                    return "Virgo";
            }

            else if (month == 9)
            {
                if (day < 23)
                    return "Virgo";
                else
                    return "Libra";
            }

            else if (month == 10)
            {
                if (day < 23)
                    return "Libra";
                else
                    return "Scorpio";
            }

            else 
            {
                if (day < 22)
                    return "Scorpio";
                else
                    return "Sagittarius";
            }
        }

        private string ChineseZodiacSign(int year)
        {
            int ei = (int)Math.Floor((year - 4.0) % 10 / 2);
            int ai = (year - 4) % 12;
            return $"{elements[ei]} {animals[ai]}";
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

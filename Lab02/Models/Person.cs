using System;

namespace ProgrammingInCSharp.Lab02.Models
{
    class Person
    {
        #region Fields

        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _birthdate;
        private string[] animals = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        private string[] elements = { "Wood", "Fire", "Earth", "Metal", "Water" };

        #endregion

        #region Constructors

        public Person(string name, string surname, string email, DateTime? birthdate = null): this(name, surname, email)
        { 
            if(birthdate != null) 
                Birthdate = birthdate.Value;
        }

        public Person(string name = " ", string surname = " ", string email = " ")
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        public Person(string name, string surname, DateTime? birthdate)
        {
            _name = name;
            _surname = surname;
            _birthdate = birthdate;
        }

        #endregion


        #region Properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public DateTime? Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        public int Age { get { return DateTime.Today.Month < Birthdate.Value.Month || (DateTime.Today.Month == Birthdate.Value.Month &&
            DateTime.Today.Day < Birthdate.Value.Day) ? DateTime.Today.Year - Birthdate.Value.Year - 1 : DateTime.Today.Year - Birthdate.Value.Year; } }
        public string SunSign { get { return FindSunSign(Birthdate.Value.Day, Birthdate.Value.Month); } }
        public string ChineseSign { get { return FindChineseSign(_birthdate.Value.Year); } }
        public bool IsAduld { get { return Age >= 18; } }

        public bool IsBirthday
        { 
            get 
            {
                return (DateTime.Today.Month == Birthdate.Value.Month) && (DateTime.Today.Day == Birthdate.Value.Day);
            }
        }

        #endregion

        private string FindSunSign(int day, int month)
        {
            switch (month)
            {
                case 12:
                    return day < 22 ? "Sagittarius" : "Capricorn";
                case 1:
                    return day < 20 ? "Capricorn" : "Aquarius";
                case 2:
                    return day < 19 ? "Aquarius" : "Pisces";
                case 3:
                    return day < 21 ? "Pisces" : "Aries";
                case 4:
                    return day < 20 ? "Aries" : "Taurus";
                case 5:
                    return day < 21 ? "Taurus" : "Gemini";
                case 6:
                    return day < 21 ? "Gemini" : "Cancer";
                case 7:
                    return day < 23 ? "Cancer" : "Leo";
                case 8:
                    return day < 23 ? "Leo" : "Virgo";
                case 9:
                    return day < 23 ? "Virgo" : "Libra";
                case 10:
                    return day < 23 ? "Libra" : "Scorpio";
                default:
                    return day < 22 ? "Scorpio" : "Sagittarius";
            }
        }

        private string FindChineseSign(int year)
        {
            int ei = (int)Math.Floor((year - 4.0) % 10 / 2);
            int ai = (year - 4) % 12;
            return $"{elements[ei]} {animals[ai]}";
        }

    }
}

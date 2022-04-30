using System;
using System.Text.RegularExpressions;
using ProgrammingInCSharp.Lab02.Exceptions;

namespace ProgrammingInCSharp.Lab02.Models
{
    class Person
    {
        #region Fields

        private static readonly string[] Animals = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        private static readonly string[] Elements = { "Wood", "Fire", "Earth", "Metal", "Water" };

        #endregion

        #region Constructors

        public Person(string name, string surname, string email, DateTime? birthdate): this(name, surname, email)
        {
            Birthdate = ValidateBirthdate(birthdate);
        }

        public Person(string name, string surname, string email)
        {
            Name = name;
            Surname = surname;
            Email = ValidateEmail(email);
        }

        public Person(string name, string surname, DateTime? birthdate): this(name, surname, "new_email@gmail.com", birthdate) {}

        #endregion

        #region Properties

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public int Age { get; set; }

        public string SunSign => FindSunSign(Birthdate.Value.Day, Birthdate.Value.Month);
        public string ChineseSign => FindChineseSign(Birthdate.Value.Year);
        public bool IsAdult => Age >= 18;
        public bool IsBirthday => (DateTime.Today.Month == Birthdate.Value.Month) && (DateTime.Today.Day == Birthdate.Value.Day);

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
            var ei = (int)Math.Floor((year - 4.0) % 10 / 2);
            var ai = (year - 4) % 12;
            return $"{Elements[ei]} {Animals[ai]}";
        }

        public string ValidateEmail(string email)
        {
            Regex validator = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return validator.IsMatch(email) ? email : throw new InvalidEmailException("You've entered invalid email");
        }

        public DateTime? ValidateBirthdate(DateTime? birthdate)
        {
            Age = DateTime.Today.Month < birthdate.Value.Month || (DateTime.Today.Month == birthdate.Value.Month &&
                                                                   DateTime.Today.Day < birthdate.Value.Day) ? DateTime.Today.Year - birthdate.Value.Year - 1 : DateTime.Today.Year - birthdate.Value.Year;

            switch (Age)
            {
                case < 0:
                    throw new FutureBirthdateException("You haven't born yet -- \n!Age must be higher than 0!");
                case > 135:
                    throw new PastBirthdateException("You are probably dead -- \n!Age must be less than 135!");
            }

            return birthdate;
        }
    }
}

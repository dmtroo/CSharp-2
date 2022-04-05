using System;

namespace ProgrammingInCSharp.Lab02.Models
{
    class User
    {
        #region Fields
        private DateTime? _birthdate;
        private string _age;
        private string _westZodiac;
        private string _chineseZodiac;
        #endregion

        #region Properties
        public DateTime? Birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }
        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string WestZodiac
        {
            get { return _westZodiac; }
            set { _westZodiac = value; }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set { _chineseZodiac = value; }
        }
        #endregion
    }
}

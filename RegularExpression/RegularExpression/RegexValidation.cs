using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace RegularExpression
{
    class RegexValidation
    {
        //start with capital and lenght must be 6
        public string NAME_REGEX = "^[A-Z]{1}[a-zA-Z]{6}$";
        //start with 6,7,8 or 9 and lenght must be 10
        public string MOBILENUMBER_REGEX = "^[6-9]{1}[0-9]{9}$";
        //skselva312000@gmail.com like this
        public string EMAIL_REGEX = "^[a-zA-Z0-9]+[+-.,]*[@]{1}[a-z]{5,7}[.]{1}[a-z]{3}$";
        //lenght must be 8
        public string PASSWORD_REGEX = "^[a-zA-Z0-6]{8}$";

        public bool ValidateName()
        {
            return Regex.IsMatch("Selvamk", NAME_REGEX);
        }
        public bool ValidateMobileNumber()
        {
            return Regex.IsMatch("8870862782", MOBILENUMBER_REGEX);
        }
        public bool ValidateEmail()
        {
            return Regex.IsMatch("skselva312000@gmail.com", EMAIL_REGEX);
        }
        public bool ValidatePassword()
        {
            return Regex.IsMatch("Selva123", PASSWORD_REGEX);
        }
    }
}

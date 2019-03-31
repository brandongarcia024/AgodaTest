using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace core
{

    public class PasswordManager
    {
        private const int MIN_LENGTH = 18;
        private string oldPassword = ""; 
        private string newPassword = "";
        private int specialCharacterCount = 0;
        private bool meetsLengthRequirements = false;
        private bool meetsCharacterContentRequirements = false;
        private bool hasWhiteSpaces = false;
        private bool meetsSpecialCharCount = false;


        public void ChangePassword(string oldPassword, string newPassword, out string ErrorMessage)
        {

            ErrorMessage = string.Empty;
            if (newPassword == null) throw new ArgumentNullException();
            if (newPassword.Contains(" "))
            {
                hasWhiteSpaces = true;
            }

            meetsLengthRequirements = newPassword.Length >= 18;//Checks the length and makes sure that it doesn't go over 18 characters.

            if (meetsLengthRequirements && !hasWhiteSpaces)
            {
                var hasLowerChar = new Regex(@"[a-z]+");//Match with a letter in lower case from a-z one or more times
                var hasUpperChar = new Regex(@"[A-Z]+");//Match with a letter in upper case from A-Z one or more times
                var hasNumber = new Regex(@"[0-9]+"); //Match with a number from 0-9 one or more times.
                var hasSymbols = new Regex(@"[!@#$&*]+");//Match with a special character 1-4 times only

                if (hasLowerChar.IsMatch(newPassword) && hasUpperChar.IsMatch(newPassword) && hasNumber.IsMatch(newPassword) && hasSymbols.IsMatch(newPassword))
                {
                    meetsCharacterContentRequirements = true;
                }
            }

            if (meetsLengthRequirements && meetsCharacterContentRequirements)
            {
                Dictionary<char, int> CharacterCount = new Dictionary<char, int>();
                foreach(char c in newPassword)
                {
                    if(CharacterCount.ContainsKey(c))
                    {
                        CharacterCount[c]++;
                    }
                    else
                    {
                        CharacterCount.Add(c, 1);
                    }
                }
                

                CharacterCount.TryGetValue()



            }




        }

    

    }

}



              /* if (!hasLowerChar.IsMatch(newPassword))
                {
                    ErrorMessage = "Password should contain At least one lower case letter";
                }
                else if (!hasUpperChar.IsMatch(newPassword))
                {
                    ErrorMessage = "Password should contain At least one upper case letter";
                }
                else if (!hasNumber.IsMatch(newPassword))
                {
                    ErrorMessage = "Password should contain At least one numeric value";
                }
                else if (!hasSymbols.IsMatch(newPassword))
                {
                    ErrorMessage = "Password should contain At least one special case characters";
                }*/
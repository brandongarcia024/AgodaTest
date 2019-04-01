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

          public bool ChangePassword(string oldPassword, string newPassword)
          {
            if (newPassword == null || oldPassword == null) throw new ArgumentNullException();

            if (!newPassword.Contains(" "))
            {
                var newPasswordIsValid = CheckNewPassword(newPassword);
                var oldPasswordIsVerified = VerifyOldPassword(oldPassword);
                var newPasswordIsUnique = ComparePasswords(oldPassword, newPassword);

                if (newPasswordIsValid && oldPasswordIsVerified && newPasswordIsUnique) return true;
            }
            return false;
          }



        /// <summary>
        /// Checks the new password if it conforms to the required password strength requirements. Returns true if it does and false if it doesn't
        /// </summary>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        private bool CheckNewPassword(string newPassword)
        {
                //Define Regex
                var hasCharacterRequirements = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d!@#&*]{18,}$");
                var hasNumber = new Regex(@"[0-9]");
                var hasSymbols = new Regex(@"[!@#$&*]");
                var hasConsecutiveDuplicates = new Regex(@"(.+)\1\1\1");

                var symbols = hasSymbols.Matches(newPassword);
                var numbers = hasNumber.Matches(newPassword);

                if (hasCharacterRequirements.IsMatch(newPassword) &
                    hasConsecutiveDuplicates.IsMatch(newPassword) &
                    symbols.Count <= 4 &
                    numbers.Count < newPassword.Length / 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                
            
        }

        /// <summary>
        /// Checks if the old password matches with the one in the database. Returns true if it is matched successfully and false if it doesn't
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        private bool VerifyOldPassword(string oldPassword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if the new password is not similar to the old password (less than 80% match)
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        private bool ComparePasswords(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }


    }
}




using System;
using System.Text.RegularExpressions;


namespace core
{
    public class PasswordManager
    {
          public bool ChangePassword(string oldPassword, string newPassword, bool mockIsVerified, bool mockCompared)
          {
            if (newPassword == null || oldPassword == null) return false;

            if (!newPassword.Contains(" "))
            {
                var newPasswordIsValid = CheckNewPassword(newPassword);
                var newPasswordIsUnique = mockCompared; // Passing in bool from mock in unit tests
                var oldPasswordIsVerified = mockIsVerified; // Passing in bool from mock in unit tests
                //  var newPasswordIsUnique = ComparePasswords(oldPassword, newPassword); - Once implemented, this will be used
                //  var oldPasswordIsVerified = VerifyOldPassword(oldPassword); Once implemented, this will be used
               
                if (newPasswordIsValid && oldPasswordIsVerified && newPasswordIsUnique) return true;
            }
            return false;
          }

        /// <summary>
        /// Checks the new password if it conforms to the required password strength requirements. Returns true if it does and false if it doesn't
        /// </summary>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool CheckNewPassword(string newPassword)
        {
                //Define Regex
                var hasCharacterRequirements = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d!@#&*]{18,}$");
                var hasNumber = new Regex(@"[0-9]");
                var hasSymbols = new Regex(@"[!@#$&*]");
                var hasConsecutiveDuplicates = new Regex(@"(.+)\1\1\1");

                var symbols = hasSymbols.Matches(newPassword);
                var numbers = hasNumber.Matches(newPassword);

                if (hasCharacterRequirements.IsMatch(newPassword) &&
                    !hasConsecutiveDuplicates.IsMatch(newPassword) &&
                    symbols.Count <= 4 &&
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
        public virtual bool VerifyOldPassword(string oldPassword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if the new password is not similar to the old password (less than 80% match)
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        public virtual bool ComparePasswords(string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}




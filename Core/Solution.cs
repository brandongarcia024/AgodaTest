using System;
using System.Text.RegularExpressions;


namespace core
{
    public class PasswordManager
    {
        
        public bool NewPasswordIsValid { get; private set; } //This is set to true if the new password meets the conditions specified in the requirement.
        public bool NewPasswordIsUnique { get; private set; }//This is set to true if the new password is less than 80% similar to the old password.
        public bool OldPasswordIsVerified { get; private set; }//This is set to true if the old password matches the one in the database.
        private const int MAX_SYMBOL_COUNT = 4;
    
        /// <summary>
        /// Checks if a given old password can be changed to the new password. Returns true if all conditions specified in the requirement are met.
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <param name="isMatch"></param>
        /// <returns></returns>
        public bool ChangePassword(string oldPassword, string newPassword, bool isMatch)
        {

            NewPasswordIsValid = false;
            NewPasswordIsUnique = false;
            OldPasswordIsVerified = false;

            if (newPassword == null || oldPassword == null)
		    {
			    return false;
		    }

        if (!newPassword.Contains(" "))
            {
                NewPasswordIsValid = CheckNewPassword(newPassword);
                NewPasswordIsUnique = ComparePasswords(oldPassword, newPassword);
                OldPasswordIsVerified = VerifyOldPassword(oldPassword, isMatch);
               
                if (NewPasswordIsValid && NewPasswordIsUnique && OldPasswordIsVerified) return true;
            }

            return false;
        }

        /// <summary>
        /// Checks the new password if it conforms to the required password strength requirements. Returns true if it does and false if it doesn't.
        /// </summary>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        private static bool CheckNewPassword(string newPassword)
        {
            //Define Regex
            var hasCharacterRequirements = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$&*])[A-Za-z\d!@#$&*]{18,}$");
            var hasNumber = new Regex(@"[0-9]");
            var hasSymbols = new Regex(@"[!@#$&*]");
            var hasConsecutiveDuplicates = new Regex(@"(.)\1{4,}");
            bool numberIsMinor;
            bool _hasCharacterRequirements = hasCharacterRequirements.IsMatch(newPassword);
            bool _hasConsecutiiveDuplicates = hasConsecutiveDuplicates.IsMatch(newPassword);

            var symbols = hasSymbols.Matches(newPassword);
            var numbers = hasNumber.Matches(newPassword);
            if (newPassword.Length % 2 == 1)
            {
                 numberIsMinor = numbers.Count <= newPassword.Length / 2;
            }
            else
            {
                numberIsMinor = numbers.Count < newPassword.Length / 2;
            }
            
            if (_hasCharacterRequirements &&
                !_hasConsecutiiveDuplicates &&
                symbols.Count <= MAX_SYMBOL_COUNT &&
                numberIsMinor)
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
        private bool VerifyOldPassword(string oldPassword, bool isMatch)
        {
            var oldPasswordDB = GetPasswordFromDB(isMatch,oldPassword);
            if (oldPassword == oldPasswordDB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// This is a mock function that simulates a call to the DB. It depends on the isMatch bool. If isMatch is true, then it returns the oldPassword. Else, it returns a different string.
        /// </summary>
        /// <param name="isMatch"></param>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        private string GetPasswordFromDB(bool isMatch, string oldPassword)
        {
            if(isMatch)
            {
                return oldPassword;
            }
            else
            {
                return $"{oldPassword} + sdafd";// Makes sure that we return a value different from oldPassword
            }
        }

        /// <summary>
        /// Checks if the new password is not similar to the old password (less than 80% match). 
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        private bool ComparePasswords(string oldPassword, string newPassword)
        {
            var levenshteinDistance = CalculateLevenshteinDistance(oldPassword, newPassword);
            var similarity = CalculateSimilarity(oldPassword, newPassword);
            if (similarity >= 0.8)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Calculates the minimum number of single-character edits (insertions, deletions or substitutions) required to change one word into the other. 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private int CalculateLevenshteinDistance(string source, string target)
        {
            // Basic cases
            if (source == target) return 0;
            if (source.Length == 0) return target.Length;
            if (target.Length == 0) return source.Length;

            // create two work vectors of integer distances
            int[] v0 = new int[target.Length + 1];
            int[] v1 = new int[target.Length + 1];

            // initialize v0 (the previous row of distances)
            // this row is A[0][i]: edit distance for an empty s
            // the distance is just the number of characters to delete from t
            for (int i = 0; i < v0.Length; i++)
                v0[i] = i;

            for (int i = 0; i < source.Length; i++)
            {
                // calculate v1 (current row distances) from the previous row v0

                // first element of v1 is A[i+1][0]
                // edit distance is delete (i+1) chars from s to match empty t
                v1[0] = i + 1;

                // use formula to fill in the rest of the row
                for (int j = 0; j < target.Length; j++)
                {
                    var cost = (source[i] == target[j]) ? 0 : 1;
                    v1[j + 1] = Math.Min(v1[j] + 1, Math.Min(v0[j + 1] + 1, v0[j] + cost));
                }

                // copy v1 (current row) to v0 (previous row) for next iteration
                for (int j = 0; j < v0.Length; j++)
                    v0[j] = v1[j];
            }

            return v1[target.Length];           
        }

        /// <summary>
        /// Calculates the similarity between two strings using the Levenshtein Distance. Returns a value from 0 to 1. 1 being completely identical.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = CalculateLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }
    }
}




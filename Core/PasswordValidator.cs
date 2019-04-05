using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Core
{
    public class PasswordValidator
    {
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
        public static bool VerifyOldPassword(string oldPassword)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if the new password is not similar to the old password (less than 80% match)
        /// </summary>
        /// <param name="oldPassword"></param>
        /// <returns></returns>
        public static bool ComparePasswords(string oldPassword, string newPassword)
        {
            var levenshteinDistance = LevenshteinDistance(oldPassword, newPassword);
            var similarity = CalculateSimilarity(levenshteinDistance);
            if (similarity >= 80)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public static int LevenshteinDistance(string oldPassword, string newPassword)
        {
            //Basic Cases
            if (oldPassword == newPassword) return 0;
            if (oldPassword.Length == 0) return newPassword.Length;
            if (newPassword.Length == 0) return oldPassword.Length;

            // create two work vectors of integer distances
            int[] v0 = new int[newPassword.Length + 1];
            int[] v1 = new int[newPassword.Length + 1];

            // initialize v0 (the previous row of distances)
            // this row is A[0][i]: edit distance for an empty s
            // the distance is just the number of characters to delete from t
            for (int i = 0; i < v0.Length; i++)
                v0[i] = i;

            for (int i = 0; i < source.Length; i++)
            {
                // calculate v1 (current row distances) from the previous row v0

                // first element of v1 is A[i+1][0]
                //   edit distance is delete (i+1) chars from s to match empty t
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
            //Number of operations needed to transform old to new.
            return v1[target.Length];
        }

        public static double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target) return 1.0;

            int stepsToSame = LevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }
    }
}

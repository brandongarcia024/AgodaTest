using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using core;

namespace Agoda.Test.UnitTests
{
    [TestClass]
    public class ChangePasswordTests
    {
        string oldPassword;
        string newPassword;
        bool isMatch;

        [TestMethod]
        public void ChangePassword_PasswordsAreNull_False()
        {
            oldPassword = "ASDSDFasdadf!@#!123";
            newPassword = "DFGDFHasWERWETWETEVSDGEHdf!@#!123";
            isMatch = true;

            var AgodaPasswordManager = CreatePasswordManager();
            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword, isMatch);

            Assert.IsTrue(passwordChanged);
        }

        /*[TestMethod]
        public void ChangePassword_PasswordsAreEmpty_False()
        {
            oldPassword = "";
            newPassword = "";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword,userName)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_NewPasswordContainsWhiteSpaces_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = " AWsdfsdf1231sdfsfWaa sw!@#213 ";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_NewPasswordIsValid_True()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "AAADDDWWWaasw!@#213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsTrue(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_NewPasswordHasInvalidLength_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "qqeeww22!@SD";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_NewPasswordHasTooManyNumbers_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "asdQWRT12345!@#123452";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_NewPasswordHasTooManySymbols_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "AAADDDWWWaasw!@@@$#213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_NewPasswordHasInvalidCharacters_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "AAADDDWWWa^&*(asw#213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_NewPasswordLacksUppercaseLetter_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "23234asdsaasw!@#213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_NewPasswordLacksLowerCaseLetter_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "AAADDDWWWDS!@#213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_NewPasswordLacksNumber_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "AAADDDWWWaasw!@#asdASDasdaASD";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_NewPasswordLacksValidSymbol_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "AAADDDWWWaaswasdsdf213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_DuplicateRepeatCharactersMoreThanFour_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "AAAADDDWWWaasw!@#213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_OnlyOldPasswordIsNull_False()
        {
            oldPassword = null;
            newPassword = "AAADDDWWWaasw!@#213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(false);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_OnlyNewPasswordIsNull_False()
        {
            oldPassword = "fgsdfgASDsdf!@#23";
            newPassword = null;

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(false);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_OldPasswordIsEmpty_False()
        {
            oldPassword = "";
            newPassword = "AAADDDWWWaasw!@#213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(false);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_OldPasswordIsUnverified_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "AAADDDWWWaasw!@#213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(false);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(true);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_OldPasswordIsTooSimilarToNewPassword_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "AAADDDWWWaasw!@#213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(false);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);
        }

        [TestMethod]
        public void ChangePassword_NumberLength_False()
        {
            oldPassword = "asdjhadsjkhASDSDFG!#!@1231";
            newPassword = "AAADDDWWWaasw!@#213";

            var AgodaPasswordManager = CreatePasswordManager();
            var verify = CreateMockPasswordManager();
            var compare = CreateMockPasswordManager();

            verify.Setup(x => x.VerifyOldPassword(oldPassword)).Returns(true);
            compare.Setup(y => y.ComparePasswords(oldPassword, newPassword)).Returns(false);

            var passwordChanged = AgodaPasswordManager.ChangePassword(oldPassword, newPassword,
                                                                      verify.Object.VerifyOldPassword(oldPassword),
                                                                      compare.Object.ComparePasswords(oldPassword, newPassword));

            Assert.IsFalse(passwordChanged);

        }*/

// Helper Methods

        /// <summary>
        /// Creates a new mock object based on the PasswordManager Class
        /// </summary>
        /// <returns></returns>
        private Mock<PasswordManager> CreateMockPasswordManager()
        {
            return new Mock<PasswordManager>();
        }

        /// <summary>
        /// Creates a new PasswordManager Object
        /// </summary>
        /// <returns></returns>
        private PasswordManager CreatePasswordManager()
        {
            return new PasswordManager();
        }
    }
}


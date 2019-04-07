using Microsoft.VisualStudio.TestTools.UnitTesting;
using core;
using System;

namespace Agoda.Test.UnitTests
{

    [TestClass]
    public class ChangePasswordTest
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        string oldPassword;
        string newPassword;
        bool isMatch;
        bool passwordChanged;

        [DataSource(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source='D:\Brandon Garcia\Documents\Test Data - Change Password.xlsx'; Extended Properties='Excel 12.0;HDR=YES;'", "Sheet1$")]
        [TestMethod()]
        public void ChangePassword__RequirementValidationTests()
        {
            oldPassword = Convert.ToString(TestContext.DataRow["oldPassword"]);
            newPassword = Convert.ToString(TestContext.DataRow["newPassword"]);
            isMatch = Convert.ToBoolean(TestContext.DataRow["isMatch"]);
            passwordChanged = Convert.ToBoolean(TestContext.DataRow["passwordChanged"]);

            if (oldPassword == "NULL")
            {
                oldPassword = null;
            }
            if (newPassword == "NULL")
            {
                newPassword = null;
            }

            var AgodaPasswordManager = CreatePasswordManager();
            var passwordChangeState = AgodaPasswordManager.ChangePassword(oldPassword, newPassword, isMatch);

            Assert.AreEqual(passwordChanged, passwordChangeState);
        }


        // Helper Methods
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


# Project Title

This is a ChangePassword function coded in c#. 

## Requirements

ChangePassword(oldPassword: String, newPassword: String)

### Tasks

Please complete the point below

Code for change password function
Implement automate test for the created function, test cases with test data provide in each case
The verify password with system and similar check function should be a mock which return True/False
 
### Password requirement

At least 18 alphanumeric characters and list of special chars !@#$&*
At least 1 Upper case, 1 lower case ,least 1 numeric, 1 special character
No duplicate repeat characters more than 4
No more than 4 special characters
50 % of password should not be a number
 
### Change password requirement

Old password should match with system
New password should be a valid password
password is not similar to old password < 80% match.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.
### Prerequisites

```
Install Visual Studio Community Edition (works free for 30 days.)
```

```
Install the necessary NuGet Packages:
1. Moq v4.10.1
2. MSTest.TestAdapter
3. MSTest.TestFramework
```
```
Access the submitted solution and open in Visual Studio.
```

## Running the tests

After loading and building the solution. Click on Test > Windows > Test Explorer.
Click on RUN ALL and the tests should execute without any problems.

## Implementation Summary

Basically, the ChangePassword function returns a boolean and depends on the following:
- The oldPassword and newPassword fields should not be null
- The passwords should not contain any white spaces** (Peculiar case #1)
- Old password should match with system
- New password should be a valid password
- Password is not similar to old password < 80% match.

The last three conditions correspond to the requirements given. The requirements also state that I should implement the
validation for the new password and leave the other two as mock functions returning true or false for testing purposes.

```
if (newPasswordIsValid && oldPasswordIsVerified && newPasswordIsUnique)
- This is the logic to validate the last three conditions
```
Refer to this example to check how the mock objects were incorporated into testing:

```
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
```
```
Sample Unit Test:
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
```

```
While ComparePasswords() and VerifyOldPassword() are unimplemented, the solution I went with is that I'd pass true
or false values from mock objects created in each test case into the mockIsVerified and mockCompared parameters. 

Once those methods are implemented, I can simply edit the ChangePassword function, remove the excess parameters 
and replace the mock variables with the actual methods.
```
## Peculiar Cases
For this project, I've assumed that passwords with whitespaces should be rejected right from the start.



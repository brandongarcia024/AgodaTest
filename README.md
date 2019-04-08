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
1. MSTest.TestAdapter
2. MSTest.TestFramework
```
```
Access the submitted solution and open in Visual Studio.
```
```
The excel file containing the test data has been saved to this repository and is named Test Data - Change Password.xlsx. 
```
```
@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source='D:\Brandon Garcia\Documents\Test Data - Change Password.xlsx'; Extended Properties='Excel 12.0;HDR=YES;'", "Sheet1$"

Change the data source to the path where you saved the test data spreadsheet. 
Depending on your version of Excel you may need to edit the 12.0 part above to the version of excel you're using. 
(12.0 is for excel 2010 - the version information can be readily searched through Google).
```


## Running the tests

After loading and building the solution. Click on Test > Windows > Test Explorer.
Click on RUN ALL and the tests should execute without any problems. There is a chance that errors pertaining to problems regarding
the data import may arise. These problems will only be because of the syntax of the DataSource. Please contact me so I can help troubleshoot in case you run into this error.

## Implementation Summary

Solution.cs (Agoda Test > Core) contains the PasswordManager class in which the ChangePassword method, and all related methods, are defined
UnitTest1.cs (Agoda Test > Agoda.Test.UnitTests) contains the unit tests.

Basically, the ChangePassword function returns a boolean (true = password is changed, false = password is unchanged due to incorrect input) and depends on the following:
- The oldPassword and newPassword fields should not be null
- The passwords should not contain any white spaces** (Peculiar case #1)
- Old password should match with system
- New password should be a valid password
- Password is not similar to old password < 80% match.

The last three conditions correspond to the requirements given. The requirements also state that I should implement the
validation for the new password and leave the other two as mock functions returning true or false for testing purposes.

For this project. I've implemented the password similarity checker as requested. The old password verification function is also implemented but with a mock function called GetPasswordFromDB. I added an additional parameter to ChangePassword() called isMatch.

If isMatch == True, then GetPasswordFromDB acts to make sure that the old password matches with the "DB". Else, GetPasswordFromDB makes sure that they are different, hence failing one requirement and thus making ChangePassword return false.

Lastly, three properties corresponding to the three requirements have been exposed (ReadOnly), along with the change password function. The rest are set to private to encapsulate the implementation.

## Test Case Summary:

-New password is null

-New password is valid

-New password is empty

-New password consists of only white spaces

-New password consists of white spaces in between characters

-New password is to small (length wise)

-New password is long,valid, and has repeating substrings.

-New password has multiple duplicate special characters (invalid case)

-New password has multiple duplicate uppercase letter (invalid case)

-New password has multiple lowercase letters (invalid case)

-New password has multiple numbers (invalid case)

-New password has multiple duplicate special characters (valid case)

-New password has multiple duplicate uppercase letter (valid case)

-New password has multiple lowercase letters (valid case)

-New password has multiple numbers (valid case)

-New password has invalid characters

-New password has an equal amount of numbers and other characters

-New password has a greater amount of other characters - division results in equal amount of numbers and other characters

-New password has a greater amount of other characters - division results in greater amount of other characters over the numbers

-New password has no uppercase letter

-New password has no lowercase letter

-New password has no numbers

-New password has no special characters

-New password has more than 4 special characters.

-Old Password matches with the one in the database

-Old password does not match with the one in the database

-New password is less than 80% similar

-New password is exactly 80% similar

-New password is more than 80% similar


## Peculiar Cases
For this project, I've assumed that passwords with whitespaces/null values should be rejected right from the start. The passwords do not go through any validation in those cases. They are simply rejected.

For the matching the old password with the DB, we won't be validating the old password since the assumption is that it was valid at the time the user set it up in the past.

We want the user to match the passwords directly to confirm that he is the rightful owner but then enforce the new validations once he/she sets the new password.

I used the Levenshtein Distance as the measurement in similarity between strings. I thought it would be most appropriate as it is the minimum number of single-character edits (insertions, deletions or substitutions) required to change one word into the other.


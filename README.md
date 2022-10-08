```
Author:     Cole Hanlon
Partner:    Tyler Harkness
Date:       27-Sep-2022
Course:     CS 4540, University of Utah, School of Computing
GitHub ID:  ColeHanlon, tylertank
Repo:       https://github.com/uofu-cs4540-fall2022/taapplication-webmoguls
Commit Tag: Release1
Project:    TA Application
Copyright:  CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
```
# AWS Deployments:

Cole - https://ec2-54-174-47-168.compute-1.amazonaws.com/

Tyler - https://ec2-52-204-59-4.compute-1.amazonaws.com/

# Overview of the TA Application Functionality 

We have now enabled users to be able to register and log in to our site. We have created three roles according, Applicant, Professor, and Administrator. All these different roles have custom navigation bars, with links to what these users would want to see. We also enable authorization based on users being signed in, and their role. We have restricted many pages based on the role you have, when you are logged in. There is still no functionality for actual creation of applications. However, there is a great deal of new functionality added through Authentication and Authorization.

# Comments to Evaluators:

As of submitting this assignment we are not aware of any bugs. We have decided to go with a design choice, where a user can either have 0 roles or 1 role. This means we have modified the Change_Role methods which were provided in lecture. We do not need to take in an add_remove parameter. Since we know we will remove if they have the role, and add if they don't have the role. In a case where they already have a role, we will return an erorr, then catch this error within the JavaScript function. We then force the browser to reload to resolve the error. Which will show the user their change was not put through, and enables the site to continue working. When a user role is removed there is no need to refresh, as no errors occured, and when adding the user's only role there is also no error, and no refresh. This was the most elegant solution to this complex problem in our opinion. 

# Assignment Specific Topics

Observations on Authentication and Authorization

We found Authentication and Authorization through ASP NET to be interesting. There is a ton of built in functionality, which we obviously used throughout. Some things that we found interesting are injection. The ability to pull in the UserManager and RoleManager objects into .cshtml files enables a great deal of customizing a web page. This is very simple to pull the objects in, and then find specific user information for who is currently using the site. This is how we created things like a custom navbar based on your role. Something else that is interesting is how in our AdminController, we added the UserManager object to our constructor, and the UserManager magically is pulled into into the AdminController. We then use this to assign roles, and remove roles based on the Role Management Page. 

Above and Beyond

We have implemented everything we found within the assignment details. We decided to add a little bit more of customization. For example, our home page has a main Jumbotron, this contains an apply now button for those who are signed in and who are applicants. We need to modify this once we have a database for applications. We will link this to the specific page for the user to apply. We think this will be a very nice usability feature. We also modified our Applicant List page to be updated with the jQuery DataTable style. Also, we followed tutorials for error handling in the HTTP Post JavaScript method. This then reloads the webpage, making a smooth error handling process.

Improvements

We would still like to go back and tidy things up from previous assignments, when there is a chance. We did not have time during this assignment.

# Consulted Peers:

Due to working on this assignment as a pair, there was no reason for communication
between peers outside of this partnership to complete the assignment.

# Peers Helped:

No peers approached our partnership or either of us individually for assistance in their own assignment.

# Acknowledgements:

We have sourced images through web searches, and made sure to use images within the creative
common liscensing when possible. 

    1. University of Utah Logo - https://en.wikipedia.org/wiki/File:Utah_Utes_-_U_logo.svg
    2. TA Assistance Image - https://live.staticflickr.com/8066/8244804464_4aaef63d1e_b.jpg
    3. Blank Pie Chart Image - https://www.tableau.com/sites/default/files/2021-06/DataGlossary_Icons_Pie%20Chart.jpg
    4. Created Custom favicon.io - https://favicon.io/
    5. Rice Eccles Stadium - https://s1.ticketm.net/dam/a/1a5/b2d427cc-5c54-4855-a8a4-3127503ea1a5_1342531_TABLET_LANDSCAPE_LARGE_16_9.jpg

# References:
    
    1. Pull in UserManager - https://stackoverflow.com/questions/29292582/accessing-usermanager-outside-accountcontroller#:~:text=You%20can%20get%20that%20instance%20from%20OWIN%20pipeline,code%20that%20makes%20access%20to%20the%20ApplicationUserManager%20possible%3A?adlt=strict&toWww=1&redig=282AFF5DDFE3439DAFC03994EC6524CF
    2. JavaScript Refresh - https://stackoverflow.com/questions/3715047/how-to-reload-a-page-using-javascript
    3. Microsoft Email Confirmation - https://learn.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm?view=aspnetcore-6.0&tabs=visual-studio

# Time Expenditures:

    1. Assignment One: Predicted Hours: 8 Actual Hours: 10 
    2. Assignment Two: Predicted Hours: 10 Actual Hours: 10 
    4. Assignment Four: Predicted Hours: 8 Actual Hours: 10
    
    

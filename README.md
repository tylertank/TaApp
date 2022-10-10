```
Author:     Cole Hanlon
Partner:    Tyler Harkness
Date:       7-Oct-2022
Course:     CS 4540, University of Utah, School of Computing
GitHub ID:  ColeHanlon, tylertank
Repo:       https://github.com/uofu-cs4540-fall2022/taapplication-webmoguls
Commit Tag: PS5Completed
Project:    TA Application
Copyright:  CS 4540 and Cole Hanlon, Tyler Harkness - This work may not be copied for use in Academic Coursework.
```
# AWS Deployments:

Cole - https://ec2-3-234-13-43.compute-1.amazonaws.com/

Tyler - https://ec2-52-204-59-4.compute-1.amazonaws.com/

# Overview of the TA Application Functionality 

We have now enabled applicants to create applications and submit them. When an Applicant logs in, they will either see buttons to create an application, or view their application. They can then create an application through the form and submit it. They can also view this application later on. They don't need to know their application id, as we automatically find it for them. The applicant can also edit and delete their application. The professor is able to log in, and view a list of applicants, they can then open the details for applications. They however, are not able to edit or delete applications. The admin is able to log in, and have access to a special application home page. This displays some live data about applications, which we would like to add more to. The admin is also able to view the list of applications, and details on applications. An admin also has the ability to edit and delete applications.

# Comments to Evaluators:

As of submitting this assignment we are not aware of any bugs. We have made sure to adjust all buttons and functionality according the assignment specifications. We do not believe we have implemented any different design choices than standard. We currently are not allowing file uploads. Please observe how our home page Apply Now and View your Application buttons dynamically change.

# Assignment Specific Topics

File/Image Uploads

We have not yet implemented file uploading, we only would like to do this with images, as seen in our details page. We did not complete this during this assignment.

ModificationTracking

The modification tracking code that was provided is very interesting. It is a neat way of being able to add this info to the database for Applications currently. We aren't using any built in SQL time stamps, and simply generating the data from C# and sending it to SQL. ModificationTracking is a class, which defines a CreationDate, ModificationDate, CreatedBy, and ModifiedBy data elements. Each of these are excluded from scaffolding. We can then use this class and inherit from it for any tables/objects we want tracking on. This elements redefining these 4 variables over and over. This means our Application class is inheriting from ModificationTracking. We then have the 4 elements. Upon saving changes within the db context class, we call AddTimestamps(). This method was provided to us, and does the real work. Speaking in terms of an Application, although this applies to any object which inherits. If the application is being added to the context, we define the CreationDate and CreatedBy elements. We access these through the Entity object, and cast it to the parent of ModificationTracking. Then, we must update the ModificationDate and ModifiedBy, in the case it is added or updated. Following this, the context handles adding this data into the actual database. Simply, the db context handles adding the 4 elements to an Application or other object, and then it is added to the database.

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
    
    1. Model Binding - https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding?view=aspnetcore-6.0
    2. ASP.NET Actions - https://www.tutorialspoint.com/asp.net_mvc/asp.net_mvc_actions.htm

# Time Expenditures:

    1. Assignment One: Predicted Hours: 8 Actual Hours: 10 
    2. Assignment Two: Predicted Hours: 10 Actual Hours: 10 
    4. Assignment Four: Predicted Hours: 8 Actual Hours: 10
    5. Assignment Five: Predicted Hours: 10 Actual Hours: 10
    
    

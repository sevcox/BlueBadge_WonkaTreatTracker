# :lollipop: Wonka's Treat Tracker :lollipop:
>A .NET Framework Web API that was created in mind of being an inventory tracker for employers. The users are employees who will be allowed to create inventory entries, sell the entries to different locations, track the sold inventory, generate receipts for locations, and keep an eye on inventory within their factory rooms.
## Table of contents
* [General Info](#general-Info)
* [Screenshots](#screenshots)
* [Technologies](#technologies)
* [Setup](#setup)
* [Features](#features)
* [Status](#status)
* [Resources](#resources)
* [Inspiration](#inspiration)
* [Contact](#contact)
## General Info
<p>Willy Wonka has been having security issues with people trying to reverse engineer his treats and figure out what the secret ingredient is. So he is wanting a tracking application to log and track treats throughout the factories and the stores. Considering that Willy isn’t the only employee of his factories he needs his oompa loompas to log in securely in order to help log and track the treats. </p>
<p>Oompa Loompas will create an account after orientation day with their username being their employee email and their factory id being the factory they are stationed at. After registering they will then have access to the application to begin tracking treats. </p>
<p> Oompas can create, edit, and delete inventory entries for candy and drinks inside their factory. Golden Ticket inventory entries are to be entered in separately for purposes of tracking golden tickets. Once those entries are created they can delete or sell them to a store. Stores can only buy products that are entered in with a specific quantity, however they can not buy golden ticket entries. Oompas will randomly distribute golden ticket candies in shipments and then assign them to a store in order to continue to track the golden ticket. After all, that’s the fun of it all… the element of surprise and pure luck! </p>
<p> In addition to tracking sold treats, oompas may track indentured servants (aka characters) inside of their factory. Since secret ingredients are often sought out and many are willing to pay a high price to discover them, oompas will want to keep a close eye on the sneaky employees… that is the former golden ticket winners. Wonka trusts the oompa’s with his life so he allows them to fire indentured servants if necessary.</p>

## Technologies
* Visual Studio Community 2019 
  * Web API .NET Framework - Individual Authentication
  * Entity Framework - Database Mapping using Code-First Approach
  * CSharp - Utilized for Logic throughout Application
  * Linq - Found in Service Layer to Query the SQL Database
* Postman - Utilized to test endpoints

## Setup
Open the file you want to save the project in, and open up the command line in the file explorer bar by typing **cmd** into the search bar. Next type git clone in your terminal and then copy and paste the clone url from Github. You can find the clone url by clicking on the green Code dropdown and clicking on the copy clipboard image to the right of the web url. Or copy this: https://github.com/sevcox/BlueBadge_WonkaTreatTracker.git</br>

Before opening the program go to the program file **BlueBadge_WonkaTreatTracker** and delete the bin and obj files from the *TreatTracker.Data*, *TreatTracker.Model*, *TreatTracker.Service*, and *TreatTracker.WebAPI*.</br>

Next open up the project by clicking on the sln document within the **BlueBadge_WonkaTreatTracker** file folder. When the project opens you should head to the **Package Manager Console** and type *update-database* in order to seed your tables with test data. After that you should be able to run the program by clicking on the green arrows at the top of the page.</br>

The first thing you will need to do is register a new user. Open up Postman and input *https://localhost:44310/api/Account/Register* into the browser bar, set the dropdown right next to the browser bar to *POST*. Within the body create parameters factoryId and enter in a number between 1 and 3, next input a body parameter of email and input any made up email address you would like(ideally wonka related). Next input two body parameters, one password and the other confirm password. Then input a password that is at least 7 characters long into both of those parameters ensuring that they are exact matches, you should receive a 200 OK notice in green below the parameters.</br>

Next, type into the browser bar within Postman *https://localhost:44310/token*. You will need three body parameters: a grant_type with the value of password, a username with the value being the same exact same as the email address you entered, and finally a password parameter with the value being the exact same as the password you entered in when registering the account; again you will run the program in Postman. The response should be a 200 OK, and within the body of the response there should be an item called bearer token you will copy everything inside the quotation marks of the bearer token. Under the authorization section, set the authorization type to bearer token and paste what you have copied.</br>

You can now begin testing the endpoints of the webapi. You can find those endpoints along with their explanation after running the application in visual studio and clicking on the **API** tab inside of the application.

## Features
* User can Register for an Account after Orientation
* Create inventory entries (Candy or Drink)
* See all inventory inside of Stores and Factories
* Update inventory due to a miscount or price change
* Assign inventory to a Store after being sold
* Delete inventory because of a recall or not being sold enough
* Create and assign a Golden Ticket to a Candy Entry
* Find and track Golden Tickets
* View all Stores that inventory is being sold to
* View a transaction report for each Store
* View Factories by their Id number
* View all Rooms inside of a Factory
* See Rooms by their Room Id number
* Locate Characters by the Character Id
* Locate Characters by their Name
* See which Room a Character is by using Character Id
* See which Character is within a given room using the Room Id
* Delete a Character(AKA they were eliminated… AKA they were *fired*)

## Status
Application is COMPLETE but *Under Construction* for Version **2.0**
Additional Features We Plan to Include:
* Multi Sided Application with User Roles such as Admin, Employee, and Store
* Ability for stores and oompas to interact via treat orders/invoices.(Ability to link to third party api such as Paypal,Venmo, or Square)
* Ability for stores to purchase different quantities
  * Making two explicit junction tables that include a quantity property so we can add the quantity of a given drink and quantity of given candy to a specified store
  
## Resources
Planning:

[Project Planning Document](https://docs.google.com/document/d/1mRVYnusO-n6MLj8-V1IS0uavI9YOrHXKmU0BJ59GQlo/edit)

[Trello Board](https://trello.com/b/beypNcS1/blue-badge-group-project)

[Table Layout with Relationship Mapping](https://dbdiagram.io/d/5f218c9b7543d301bf5d2c64)

[All Things Willy Wonka](https://charlieandthechocolatefactoryfilm.fandom.com/wiki/Charlie_and_the_Chocolate_Factory_Wiki:Charlie_and_the_Chocolate_Factory_Wiki)

Project Logic:

[Web API Help Page Documentation](https://docs.microsoft.com/en-us/aspnet/web-api/overview/getting-started-with-aspnet-web-api/creating-api-help-pages)

[Code-First Seed Data Via Migrations](https://docs.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-3)

[Customizing ApplicationUser Class](https://devblogs.microsoft.com/aspnet/customizing-profile-information-in-asp-net-identity-in-vs-2013-templates/)

[ElevenNote Application](https://devblogs.microsoft.com/aspnet/customizing-profile-information-in-asp-net-identity-in-vs-2013-templates/)

[Entity Framework Code-First](https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx)

[Many-to-Many](https://entityframework.net/many-to-many-relationship#:~:text=Entity%20Framework%20Many-to-Many%20Relationships.%20Many-to-Many%20Relationships.%20In%20a,are%20associated%20with%20multiple%20records%20in%20another%20table)

[Unique  Index Constraint](https://stackoverflow.com/questions/10614575/entity-framework-code-first-unique-column)

[Endpoint Routing](https://forums.asp.net/t/2100816.aspx?WebAPI+How+to+do+attribute+routing+for+Post+Put+and+Delete+verbs)

[One-to-Many](https://www.entityframeworktutorial.net/code-first/configure-one-to-many-relationship-in-code-first.aspx)

[Writing a Good ReadMe](https://bulldogjob.com/news/449-how-to-write-a-good-readme-for-your-github-project)

## Inspiration
>"There is no life I know to compare with pure imagination." *Willy Wonka*

![](https://media.giphy.com/media/xIna8nqTTk3x6/giphy.gif)

Just a bunch of avid Willy Wonka and the Chocolate Factory fans! 

## Contact
**Severa Cox** - [@sevcox](https://github.com/sevcox)

**Zach Sperka** - [@SperZ](https://github.com/SperZ)

**Tyler Klink** - [@tylerklink75](https://github.com/tylerklink75)

# OpenMindsForum

In this project, we were tasked with creating an anonymous forum using ASP.NET with the MVC pattern. The data was stored in a database (MSSQL studio 18) using Entity Framework.

## Requirements:

## Design:
* On the first page, and ideally, a header or sidebar on every page, a set of hardcoded discussion topics (e.g., school, sports, movies) is to be included.
* When topics are clicked by users, the titles of all threads in the forum should be viewable, along with a means to create a new thread (either directly on this page or through a link to a new page for thread creation).
* Clicking on a thread should result in the display of the text and all replies in the thread, along with the option to write a reply (either on this page or via a link to a new page).

## Overall:
* The validation of all user input.
* The use of partial views to maintain clean and DRY (Don't Repeat Yourself) code.
* The employment of view models to manage data passed between views.
* The ensuring of a reasonable database design.
* The adherence to sound code design principles, such as following the MVC pattern and applying separation of concerns.

## Database Design:
![Anonyma forumet](https://github.com/Abfar90/OpenMindsForum/assets/71592350/d6c7f7d4-bfa1-4abe-912b-829545a099d1)

## How to run:
There is a bak file in the db export folder that can be used to recreate the DB including the data.
There is also a script file which will create the DB tables without data.



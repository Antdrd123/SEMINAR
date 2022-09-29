# Term paper



> ASP.NET developer course final project

---

### Table of Contents
You're sections headers will be used to reference location of destination.

- [Description](#description)
- [How To Use](#how-to-use)
- [Author Info](#author-info)

---

## Description
Final project called **Algebra_Seminar_Drdic** is simple webshop with basic functions and few different roles. Application is connected with database and should be used locally on PCs.

#### Technologies

- C#
- HTML
- CSS
- Entity Framework
- .NET

[Back To The Top](#term-paper)

---

## How To Use (steps)

Application download and adjustment is easy and simple, just make sure to follow the steps.

#### Step 1:
When in GitHub clone repository by opening code with Visual Studio or if you prefer other IDE, dowlnload zip file to your PC.

##### Step 1.1 (only if you do not use Visual Studio):
Unzip your file and open Algebra_Seminar_Drdic.sln.

#### Step 2:
Open preffered database management system (Microsoft SQL Server, MySQL...) and create new database with any name</br> (ex. _Drdic_Database_). 

#### Step 3:
Open a solution in Visual Studio or preffered IDE. The solution consists of two projects(_Algebra_Seminar_Drdic_ and _API_).</br> When in project, first you have to change _DefaultSettings_ in _appsettings.json_ to your server name in **both** projects </br>(ex. _Server=localhost\\sqlexpress_). Also, you have to change database to wanted one that you created earlier</br> (ex. _Database=Drdic_Database_). If needed, leave _"TrustedConnection=true"_, depending on your local properties.

#### Step 4:
In Package Manager Console type _**update-database**_ to automatically fill your created database with built-in data.

#### Step 5:
You are now ready to start the app. :)


#### Application functions
Application has two different roles of "User" and "Admin" that have different authorization. User has to be logged in, can see ten random products and their details. Admin, on the other hand, can see everything that User can, has authorization over basic CRUD functions for category, product and account. 

#### API Reference
With the help of the REST WEB API, use of the endpoints was enabled on which 
XML or JSON format are able to access all products or
individual product by database code.
```html
    ~/api/ApiProduct
    ~/api/ApiProduct/{id}
```
[Back To The Top](#term-paper)

---





## Author Info

- GitHub - https://github.com/Antdrd123
- Mail - antoniodrdic7@gmail.com

[Back To The Top](#term-paper)
